from rest_framework.response import Response
from rest_framework.decorators import api_view
from django.http import JsonResponse
from base.recommendation_module import (
    get_user_ratings_and_books,
    load_and_preprocess_data,
    recommend_books_for_user,
)
from base.models import Item, Book, Rating
from .serializers import (
    ItemSerializer,
    BookSerializer,
    RatingSerializer,
    UserRecommendationSerializer,
)
from rest_framework import status

# GET request to retrieve data for all items
@api_view(['GET'])
def getData(request):
    """
    Get a list of all items in the database.

    Args:
        request: HTTP GET request object.

    Returns:
        Response: JSON response containing serialized items.
    """
    item = Item.objects.all()
    serialzer = ItemSerializer(item, many = True)
    return Response(serialzer.data)

# POST request to add a new item
@api_view(['POST'])
def addItem(request):
    """
    Add a new item to the database.

    Args:
        request: HTTP POST request object containing item data.

    Returns:
        Response: JSON response containing the serialized item or validation errors.
    """
    serializer = ItemSerializer(data=request.data)
    if serializer.is_valid():
        serializer.save()
    return Response(serializer.data)

# POST request to add a new book
@api_view(['POST'])
def addBook(request):
    """
    Add a new book to the database.

    Args:
        request: HTTP POST request object containing book data.

    Returns:
        Response: JSON response containing the serialized book or validation errors.
    """
    serializer = BookSerializer(data=request.data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_201_CREATED)
    return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

# POST request to add a new rating
@api_view(['POST'])
def addRating(request):
    """
    Add a new rating to the database.

    Args:
        request: HTTP POST request object containing rating data.

    Returns:
        Response: JSON response containing the serialized rating or validation errors.
    """
    serializer = RatingSerializer(data=request.data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_201_CREATED)
    return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

# GET request to get user recommendations
@api_view(['GET'])
def get_user_recommendations(request):
    """
    Get user recommendations based on user ratings and books.

    Args:
        request: HTTP GET request object containing user ID.

    Returns:
        Response: JSON response containing user data, ratings, and books, or an error message.
    """
    serializer = UserRecommendationSerializer(data=request.data)
    if serializer.is_valid():
        user_id = serializer.validated_data['userId']
        user_data = get_user_ratings_and_books(user_id)

        if 'error' in user_data:
            return Response({'error': user_data['error']}, status=400)

        ratings = [rating.bookRating for rating in user_data['ratings']]
        books = [book.bookTitle for book in user_data['books']]

        response_data = {
            'userId': user_id,
            'ratings': ratings,
            'books': books,
        }

        return Response(response_data)
    return Response(serializer.errors, status=400)

# GET request to provide book recommendations for a specific user
@api_view(['GET'])
def recommendations(request, user_id):
    """
    Get book recommendations for a specific user.

    Args:
        request: HTTP GET request object.
        user_id: User ID for which recommendations are requested.

    Returns:
        JsonResponse: JSON response containing recommended ISBNs or an error message.
    """
    # Load and preprocess the data
    book, user, rating, matrix_norm, user_similarity_matrix = load_and_preprocess_data()

    # Call the recommend_books_for_user function
    recommended_isbns = recommend_books_for_user(user_id, book, user, rating, matrix_norm, user_similarity_matrix)

    if isinstance(recommended_isbns, list):
        # Return the recommended ISBNs as JSON
        return JsonResponse({'recommended_isbns': recommended_isbns})
    else:
        return JsonResponse({'error': recommended_isbns})
