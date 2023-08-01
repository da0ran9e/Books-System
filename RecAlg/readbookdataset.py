# -*- coding: utf-8 -*-
"""
@author: Legion
"""

# Fix the &amp; and other HTML escape sequences
import pandas as pd
import html
import os
print(os.getcwd())

raw_book_path = "./dataset/BX-Books"
book_path = "./dataset/BX-Books-HTMLfixed" 

# If file isn't fixed yet
if not os.path.isfile(f'{book_path}.csv'):
    with open(f'{raw_book_path}.csv', 'r', encoding='latin-1') as f, open(f'{book_path}.csv', 'w') as g:
        content = html.unescape(f.read())
        g.write(content)
        print("Fixed file {0}.csv".format(raw_book_path))

# Loading the dataset 
def loaddata(filename):
    df = pd.read_csv(f'{filename}.csv', sep=';', encoding='latin-1', escapechar='\\',\
                     on_bad_lines='warn')
    return df

book   = loaddata(book_path)
user   = loaddata("./dataset/BX-Users")
rating = loaddata("./dataset/BX-Book-Ratings")