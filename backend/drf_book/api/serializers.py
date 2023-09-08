from rest_framework import serializers
from base.models import Item
from base.models import Book
from base.models import Rating

class ItemSerializer(serializers.ModelSerializer):
    class Meta:
        model = Item
        fields = '__all__'

class BookSerializer(serializers.ModelSerializer):
    class Meta:
        model = Book
        fields = '__all__'

class RatingSerializer(serializers.ModelSerializer):
    class Meta:
        model = Rating
        fields = '__all__'

class UserRecommendationSerializer(serializers.Serializer):
    userId = serializers.IntegerField()
    ratings = serializers.ListField(child=serializers.FloatField())
    books = serializers.ListField(child=serializers.CharField())