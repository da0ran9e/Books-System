from django.urls import path
from . import views

urlpatterns = [
    path('', views.getData),
    path('add/', views.addItem),
    path('addbook/', views.addBook),
    path('rate/', views.addRating),
    path('recommendations/<int:user_id>/', views.recommendations, name='recommendations')
]
