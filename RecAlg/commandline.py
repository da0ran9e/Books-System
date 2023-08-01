# -*- coding: utf-8 -*-
"""
Created on Tue Jan  3 23:28:21 2023

@author: Legion
"""

from predictbasic import similarities, printRecommendations

user_id = input("\nEnter user ID to get recommendation: ")
print(printRecommendations(similarities, int(user_id), 40, 10))