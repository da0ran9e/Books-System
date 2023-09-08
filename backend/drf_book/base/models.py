from django.db import models

# Create your models here.

class Item(models.Model):
    name = models.CharField(max_length=200)
    description = models.CharField(max_length=500, null = True)
    created = models.DateTimeField(auto_now_add=True)

class Book(models.Model):
    index = models.AutoField(primary_key=True)
    isbn = models.CharField(max_length=20, unique=True)
    bookTitle = models.CharField(max_length=150, null=True)
    bookAuthor = models.CharField(max_length=50, null=True)
    yearOfPublication = models.IntegerField(null=True)
    publisher = models.CharField(max_length=50, null=True)
    imageURLS = models.CharField(max_length=150, null=True)
    imageURLM = models.CharField(max_length=150, null=True)
    imageURLL = models.CharField(max_length=150, null=True)

class Rating(models.Model):
    userId = models.IntegerField()
    isbn = models.CharField(max_length=20)
    bookRating = models.PositiveSmallIntegerField()
    created = models.DateTimeField(auto_now_add=True)