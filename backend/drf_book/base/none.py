import pandas as pd
import numpy as np
from scipy import sparse
from sklearn.metrics.pairwise import cosine_similarity

# Define data loading and preprocessing as a function
def load_and_preprocess_data():
    # Load the necessary data (you can reuse the data loading code)
    def load_data(filename):
        df = pd.read_csv(f'{filename}.csv',sep=';',encoding='latin-1',on_bad_lines='skip')
        return df

    book = load_data("./dataset/BX-Books-HTMLfixed")
    user = load_data("./dataset/BX-Users")
    rating = load_data("./dataset/BX-Book-Ratings")

    # Preprocess data and rename columns (you can reuse the data preprocessing code)
    book = book[['ISBN', 'Book-Title', 'Book-Author', 'Year-Of-Publication', 'Publisher']]
    book.rename(columns={'Book-Title':'title', 'Book-Author':'author', 'Year-Of-Publication':'year', 'Publisher':'publisher'}, inplace=True)
    user.rename(columns={'User-ID':'user_id', 'Location':'location', 'Age':'age'}, inplace=True)
    rating.rename(columns={'User-ID':'user_id', 'Book-Rating':'rating'}, inplace=True)


    # Filter users and books based on minimum ratings
    rating_users = rating['user_id'].value_counts().reset_index().rename(columns={'index':'user_id', 'user_id':'rating'})
    rating_books = rating['ISBN'].value_counts().reset_index().rename(columns={'index':'ISBN', 'ISBN':'rating'})

    rating = rating[rating['user_id'].isin(rating_users[rating_users['rating']>200]['user_id'])]
    rating = rating[rating['ISBN'].isin(rating_books[rating_books['rating']> 50]['ISBN'])]

    # Merge rating data with book data
    rating = rating.merge(book, on="ISBN")[['user_id', 'title', 'rating', 'ISBN']]

    # Remove duplicate entries
    rating.drop_duplicates(inplace=True)

    # Create user-item matrix
    book_pivot = rating.pivot_table(columns='ISBN', index='user_id', values="rating")

    # Normalize user-item matrix
    matrix_norm = book_pivot.subtract(book_pivot.mean(1), axis=1)

    # Fill NaN values with 0
    matrix_norm.fillna(0, inplace=True)

    # Compute user similarity matrix using cosine similarity
    user_similarity_matrix = pd.DataFrame(cosine_similarity(matrix_norm), index=matrix_norm.T.columns, columns=matrix_norm.T.columns)


    return book, user, rating, matrix_norm, user_similarity_matrix

# Define the recommend_books_for_user function
def recommend_books_for_user(user_id, book, user, rating, user_item_matrix, user_similarity_matrix):
    # Set the number of similar users and pick a target user
    k = 40

    # Check if the provided user ID exists in the data
    if user_id not in user_item_matrix.index:
        return "User ID not found in the dataset."

    # Get top k similar users for the provided user ID
    similar_user = user_similarity_matrix[user_id].sort_values(ascending=False)[1:k+1]

    # Find books that similar users have read but the target user has not
    similar_user_books = user_item_matrix.loc[similar_user.index].sum()
    picked_user_read = user_item_matrix.loc[user_id]
    
    # Remove the read books from the book list
    similar_user_unread_books = similar_user_books[picked_user_read == 0]

    # Calculate item scores for each book
    item_score = {}

    for i in similar_user_unread_books.index:
        total = 0
        divide = 0
        for u in similar_user.index:
            if u != user_id and not pd.isna(user_item_matrix.loc[u, i]):
                score = user_similarity_matrix.loc[user_id, u] * user_item_matrix.loc[u, i]
                total += score
                divide += 1
        item_score[i] = total / (divide + 1e-8)

    # Top N recommended books
    m = 10
    item_score = pd.Series(item_score)
    ranked_books = item_score.sort_values(ascending=False).head(m)

    # Return the recommended ISBNs
    recommended_isbns = ranked_books.index.tolist()
    
    return recommended_isbns

user_id = 13552
# Load and preprocess the data
book, user, rating, matrix_norm, user_similarity_matrix = load_and_preprocess_data()

    # Call the recommend_books_for_user function
recommended_isbns = recommend_books_for_user(user_id, book, user, rating, matrix_norm, user_similarity_matrix)

if isinstance(recommended_isbns, list):
        # Return the recommended ISBNs as JSON
    print(recommended_isbns)
else:
    print("none")