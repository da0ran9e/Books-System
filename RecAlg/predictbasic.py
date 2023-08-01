# -*- coding: utf-8 -*-
"""
Created on Tue Jan  3 23:18:07 2023

@author: Legion
"""

# Libraries for data preparation & visualization
import numpy as np
import pandas as pd

# Ignore printing warnings for general readability
import warnings 
warnings.filterwarnings("ignore")

# pip install scikit-surprise
# Importing libraries for model building & evaluation
from surprise import Reader, Dataset
from surprise.model_selection import train_test_split, cross_validate, GridSearchCV
from surprise import KNNBasic, KNNWithMeans, KNNWithZScore, KNNBaseline
from surprise import accuracy
import random

import readbookdataset
book = readbookdataset.book
user = readbookdataset.user
rating = readbookdataset.rating

rating_users = rating['User-ID'].value_counts().reset_index().\
               rename({'Index':'User-ID','User-ID':'Rating'}, axis=1)
rating_books = rating['ISBN'].value_counts().reset_index().\
               rename({'Index':'ISBN','ISBN':'Rating'}, axis=1)
# In order to avoid rating bias & for making good recommendations, limit the dataset to only those
# users that have made at least 100 ratings & books that have received at least 50 ratings

rating = rating[rating['User-ID'].isin(rating_users[rating_users['Rating']>=100]['index'])]
rating = rating[rating['ISBN'].isin(rating_books[rating_books['Rating']>=50]['index'])]


# For the recommendation system, it is prefered to have the book titles rather than ISBN for easier interpretation
rating = rating.merge(book, on="ISBN")[['User-ID','ISBN','Book-Rating','Book-Title']] # merging with the book dataframe

ratings_explicit=rating[rating['Book-Rating']!=0]
ratings_implicit=rating[rating['Book-Rating']==0]


# creating a surprise object

reader = Reader(rating_scale=(1, 10))
data_nonzero   = Dataset.load_from_df(ratings_explicit[['User-ID','ISBN','Book-Rating']], reader)
data  = Dataset.load_from_df(rating[['User-ID','ISBN','Book-Rating']], reader)

# Split the data into training & testing sets. 

raw_ratings_nonzero = data_nonzero.raw_ratings
random.shuffle(raw_ratings_nonzero)                 # shuffle dataset

threshold   = int(len(raw_ratings_nonzero)*0.8)

train_raw_ratings = raw_ratings_nonzero[:threshold] # 80% of data is trainset
test_raw_ratings  = raw_ratings_nonzero[threshold:] # 20% of data is testset

data_nonzero.raw_ratings = train_raw_ratings        # data is now the trainset
trainset         = data_nonzero.build_full_trainset() 
testset          = data_nonzero.construct_testset(test_raw_ratings)

# Hyperparameter tuning - KNNBasic with data_nonzero

param_grid = { 'sim_options' : {'name': ['msd','cosine','pearson','pearson_baseline'], \
                                'min_support': [1,5], \
                                'user_based': [False, True]}
             }

gridsearchKNNBasic = GridSearchCV(KNNBasic, param_grid, measures=['mae', 'rmse'], cv=5, n_jobs=-1)
                                    
gridsearchKNNBasic.fit(data_nonzero)

print(f'MAE Best Parameters:  {gridsearchKNNBasic.best_params["mae"]}')
print(f'MAE Best Score:       {gridsearchKNNBasic.best_score["mae"]}\n')

print(f'RMSE Best Parameters: {gridsearchKNNBasic.best_params["rmse"]}')
print(f'RMSE Best Score:      {gridsearchKNNBasic.best_score["rmse"]}\n')


# Model fit & prediction - KNNBasic

best_basic_sim_options = gridsearchKNNBasic.best_params["rmse"]["sim_options"]
final_model = KNNBasic(sim_options=best_basic_sim_options)

# Fitting the model on trainset & predicting on testset, printing test accuracy
pred = final_model.fit(trainset).test(testset)

print(f'\nUnbiased Testing Performance:')
print(f'MAE: {accuracy.mae(pred)}, RMSE: {accuracy.rmse(pred)}')

set_userID = set([i[0] for i in train_raw_ratings])
def generate_recommendationsKNN(similarity_matrix, userID=13552, like_recommend=40, get_recommend =10):
    if (userID not in set_userID) or type(userID) is not int:
        print("User id should be a valid integer from this list : \n\n {}".format(sorted(set_userID)))
        return []
    ''' This function generates "get_recommend" number of book recommendations using 
        KNNWithMeans & item based filtering. The function needs as input three 
        different parameters:
        (1) userID i.e., userID for which recommendations need to be generated 
        (2) like_recommend i.e., number of top recommendations for the userID to be 
        considered for making recommendations 
        (3) get_recommend i.e., number of recommendations to generate for the userID
        Default values are: userID=13552, like_recommend=5, get_recommend=10
    '''
    
    userID      = trainset.to_inner_uid(userID)    # converts the raw userID to innerID
    userRatings = trainset.ur[userID]              # method .ur takes user innerID & 
                                                   # returns back user ratings
    
    
    # userRatings is a list of tuples [(,),(,),(,)..]. Each tuple contains item & rating
    # given by the user for that item. Next, the tuples will be sorted within the list 
    # in decreasing order of rating. Then top 'like_recommend' items & ratings are extracted
    
    temp_df = pd.DataFrame(userRatings).sort_values(by=1, ascending=False).\
              head(like_recommend)
    userRatings = temp_df.to_records(index=False) 
    
    # for each (item,rating) in top like_recommend user items, multiply the user rating for
    # the item with the similarity score (later is obtained from item similarity_matrix) for
    # all items. This helps calculate the weighted rating for all items. The weighted ratings 
    # are added & divided by sum of weights to estimate rating the user would give an item
    
    recommendations   = {}

    for user_top_item, user_top_item_rating  in userRatings:

        all_item_indices          =   list(pd.DataFrame(similarity_matrix)[user_top_item].index)
        all_item_weighted_rating  =   list(pd.DataFrame(similarity_matrix)[user_top_item].values*\
                                          user_top_item_rating)
        
        all_item_weights          =   list(pd.DataFrame(similarity_matrix)[user_top_item].values)
        
        
        # All items & final estimated ratings are added to a dictionary called recommendations
        
        for index in range(len(all_item_indices)):
            if index in recommendations:
                # sum of weighted ratings
                recommendations[index] += all_item_weighted_rating[index]        
            else:                        
                recommendations[index]  = all_item_weighted_rating[index]

    
    for index in range(len(all_item_indices)):                               
            if all_item_weights[index]  !=0:
                # final ratings (sum of weighted ratings/sum of weights)
                recommendations[index]   =recommendations[index]/\
                                          (all_item_weights[index]*like_recommend)
                      

    # convert dictionary recommendations to a be a list of tuples [(,),(,),(,)]
    # with each tuple being an item & estimated rating user would give that item
    # sort the tuples within the list to be in decreasing order of estimated ratings

    temp_df = pd.Series(recommendations).reset_index().sort_values(by=0, ascending=False)
    recommendations = list(temp_df.to_records(index=False))
    
    # return get_recommend number of recommedations (only return items the user 
    # has not previously rated)
    
    final_recommendations = []
    count = 0
    
    for item, score in recommendations:
        flag = True
        for userItem, userRating in trainset.ur[userID]:
            if item == userItem: 
                flag = False       # If item in recommendations has not been rated by user, 
                break              # add to final_recommendations
        if flag == True:
            final_recommendations.append(trainset.to_raw_iid(item)) 
            count +=1              # trainset has the items stored as inner id,  
                                   # convert to raw id & append 
            
        if count > get_recommend:  # Only get 'get_recommend' number of recommendations
            break
    
    return(final_recommendations)


def printRecommendations(similarity_matrix, user_id, k, get_top):
    recommendationsKNN = generate_recommendationsKNN(similarity_matrix, userID=user_id, like_recommend=k, get_recommend=get_top)

    print("\nRecommended Books for user {0} (item-based):".format(user_id))
    red = pd.DataFrame(recommendationsKNN,columns = ['ISBN'])
    red_ = red.merge(book, on="ISBN")[['ISBN','Book-Title']]
    return red_

# Set the user and other values
base_user_id = 13552
base_k = 40
base_recommend = 10


# Compute item based similarity matrix
# KNNBasic
best_basic_sim_options['user_based'] = False
similarities = KNNBasic(sim_options = best_basic_sim_options).fit(trainset).\
                    compute_similarities() 

# print(printRecommendations(similarities, base_user_id, base_k, base_recommend))
