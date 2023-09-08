from rest_framework.response import Response
from rest_framework.decorators import api_view
from .recommendation_module import get_user_ratings_and_books
from rest_framework import status
from base.models import Item
from base.models import Book
from base.models import Rating

from .serializers import ItemSerializer
from .serializers import BookSerializer
from .serializers import RatingSerializer
from .serializers import UserRecommendationSerializer

@api_view(['GET'])
def getData(request):
    item = Item.objects.all()
    serialzer = ItemSerializer(item, many = True)
    return Response(serialzer.data)

@api_view(['POST'])
def addItem(request):
    serializer = ItemSerializer(data=request.data)
    if serializer.is_valid():
        serializer.save()
    return Response(serializer.data)

@api_view(['POST'])
def addBook(request):
    serializer = BookSerializer(data=request.data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_201_CREATED)
    return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

@api_view(['POST'])
def addRating(request):
    serializer = RatingSerializer(data=request.data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_201_CREATED)
    return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

@api_view(['GET'])
def get_user_recommendations(request):
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