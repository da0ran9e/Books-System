# Book Recommending System 
A book Book Recommendation System which recommends the users a selection of books. Using memory-based collaborative filtering to offer relevant items (books) to the users based on their taste or previous choices.

## Environment
- Anaconda : (link download https://www.anaconda.com/ )
- Jupyter Notebook
- Python: 3.10.8
- Pandas: 1.5.2

Installing required packages with `conda` in the terminal or an Anaconda Prompt (recommended):
```
conda env create -f environment.yml
conda activate book_rec_env
conda update --all
```

If you're not using `conda` (surprise package may not install):
```
pip install notebook
pip install -r requirements.txt
```
The file `requirements.txt` was created with [`pipreqs`](https://anaconda.org/conda-forge/pipreqs) package.

<br />

To start Jupyter Notebook:
```
jupyter notebook
```

## The dataset
[The Book-Crossing Dataset](http://www2.informatik.uni-freiburg.de/~cziegler/BX/) contains 278,858 users (anonymized but with demographic information) providing 1,149,780 ratings (explicit & implicit) about 271,379 books.
The Book-Crossing dataset comprises of 3 tables.
- BX-Users : Contains the users.
- BX-Books : Books are identified by their respective ISBN. Invalid ISBNs have already been removed from the dataset. Moreover, some content-based information is given (`Book-Title`, `Book-Author`, `Year-Of-Publication`, `Publisher`),URLs linking to cover images are also given, appearing in three different sizes (`Image-URL-S`, `Image-URL-M`, `Image-URL-L`),
- BX-Book-Ratings : Contains the book rating information. Ratings (`Book-Rating`) are either explicit, expressed on a scale from 1-10 (higher values denoting higher appreciation), or implicit, expressed by 0.


## Using the program
To predict the books that one user might like based on their preferences,
you can use the following command to run the program in command-line:
```
python commandline.py
```
The value `user ID` will correspond to the first column in BX-Users file. The program will fail if the user selected hasn't rated enough book to make relevant prediction (> 100 ratings).
In that case, the system will instead provide a list of valid `user ID` that can be inputted.
The command-line program here uses KNNBasic algorithm from [`SystemUsingSurprise-Sklearn.ipynb`](SystemUsingSurprise-Sklearn.ipynb) jupyter notebook


## Libraries 
### Import libraries for dataset 
- numpy 
- seaborn
- pandas
- matplotlib (installed by seaborn)
```python
import numpy as np
import seaborn as sns
import pandas as pd
import matplotlib.pyplot as plt
```

### Import libraries for building system and evaluation 
- sklearn
- surprise 
```python
from surprise import Reader, Dataset
from surprise.model_selection import train_test_split, cross_validate, GridSearchCV
from surprise import KNNBasic, KNNWithMeans, KNNWithZScore, KNNBaseline
from surprise import accuracy
import random
from sklearn.neighbors import NearestNeighbors
import sklearn
```

## Load Data
While importing libraries and load datasets. while loading the file we have some problems like:
- The values in the CSV file are separated by semicolons, not by a comma.
- There are some lines which not work like we cannot import it with pandas and It throws an error because python is Interpreted language

So while loading data we have to handle these exceptions and after running the below code you may get some warning and it will show which lines have an error that we have skipped while loading.
```python
import warnings 
warnings.filterwarnings("ignore")
```

Need to know the path of data to use and load
```python
def loaddata(filename):
    df = pd.read_csv(f'{filename}.csv', sep=';', encoding='latin-1', escapechar='\\',\
                     on_bad_lines='warn')
    return df

book   = loaddata("./dataset/BX-Books")
user   = loaddata("./dataset/BX-Users")
rating = loaddata("./dataset/BX-Book-Ratings")
```

## User-Guide using Surprise ([docs](https://surprise.readthedocs.io/en/stable/prediction_algorithms.html))
You just need to pass a sim_options argument at the creation of an algorithm. This argument is a dictionary with the following (all optional) keys:
- 'name' : ['cosine' , 'pearson', 'pearson_baseline', 'msd']
		   The name of the similarity to use, as defined in the [similarities module](https://surprise.readthedocs.io/en/stable/similarities.html). Default is 'MSD'.
- 'min-support' : [1,5]
- 'user_based' : [True, False]
				 Whether similarities will be computed between users or between items. Default is 'True'.


