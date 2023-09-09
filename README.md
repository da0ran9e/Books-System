# Books-System
A library management software
![MainForm 2023-09-08 15-21-12](https://github.com/da0ran9e/Books-System/assets/98570451/63761e59-f59a-4a01-a0c1-cea236c197d2)


## Setup
### Install [packages](https://github.com/da0ran9e/Books-System/blob/main/requirements.txt)
```bash
pip install -r requirements.txt
```
Packages were used in my project:
- [Django](https://github.com/django/django) `version 4.2.5`
- [djangorestframework](https://github.com/encode/django-rest-framework) `version 3.14.0 `
- [matplotlib](https://github.com/matplotlib/matplotlib) `version 3.7.2`
- [mpmath](https://github.com/mpmath/mpmath) `version 1.3.0`
- [numpy](https://github.com/numpy/numpy) `version 1.25.0`
- [pandas](https://github.com/pandas-dev/pandas)`version 1.4.4`
- [Pillow](https://github.com/python-pillow/Pillow) `version 10.0.0`
- [scikit-learn](https://github.com/scikit-learn/scikit-learn)`version 1.3.0`
- [torch](https://github.com/torch/torch7) `version 2.0.1`
- [sqlparse](https://github.com/andialbrecht/sqlparse) `version 0.4.4`
> [!IMPORTANT]  
> Project cannot run on Pandas version of 2.0.0 and higher! <br />

### Run Django server
```bash
python backend/drf_book/manage.py migrate
python backend/drf_book/manage.py runserver
```

## C# Windows Forms .NET <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/>   

A Windows Form C# application utilizing the .NET framework. It leverages the data source and algorithms previously developed from a prior [project](https://github.com/da0ran9e/Book-Recommendation-System).<br />


##  Python backend algorithm <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/python/python-original.svg" alt="python" width="40" height="40"/> <img src="https://raw.githubusercontent.com/devicons/devicon/2ae2a900d2f041da66e950e4d48052658d850630/icons/pandas/pandas-original.svg" alt="pandas" width="40" height="40"/>  <img src="https://upload.wikimedia.org/wikipedia/commons/0/05/Scikit_learn_logo_small.svg" alt="scikit_learn" width="40" height="40"/>
See the explaination from earlier [project](https://github.com/da0ran9e/Book-Recommendation-System) documents [here](https://github.com/da0ran9e/Book-Recommendation-System/blob/main/Final_Report_Book_Rec.pdf)!
- Functions for Recommendation:

`get_user_ratings_and_books(user_id)`: Retrieves user ratings and associated books based on a provided user ID. It returns a dictionary containing ratings and books or an error message if an exception occurs.

`load_and_preprocess_data()`: Loads and preprocesses data for a recommendation system. It includes loading data from CSV files, renaming columns, filtering users and books, merging data, and creating a user-item matrix and user similarity matrix.

`recommend_books_for_user(user_id, book, user, rating, user_item_matrix, user_similarity_matrix)`: Generates book recommendations for a specific user based on user similarity. It considers user ratings and book data to provide a list of recommended ISBNs.

[Python code](/backend/drf_book/base/recommendation_module.py) for a book recommendation system using collaborative filtering. It leverages the BX dataset for data loading, preprocessing, and user similarity calculations. The system suggests books to users based on their preferences and the preferences of similar users. <br />
[# Create user-item matrix](https://github.com/da0ran9e/Books-System/blob/88fcad1d5682debac559cfef3459acb3780f7382/backend/drf_book/base/recommendation_module.py#L62-L72)

## Python Django Rest Framework API <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/python/python-original.svg" alt="python" width="40" height="40"/> <img src="https://cdn.worldvectorlogo.com/logos/django.svg" alt="django" width="40" height="40"/>  
- Recommendations Function:

`recommendations(request, user_id)`: Handles a GET request to provide book recommendations for a specific user. It loads and preprocesses data, including user ratings and similarity matrices, then calls the recommend_books_for_user function to get book recommendations for the user. It returns recommended ISBNs as JSON.
- API Url:
```
/recommendations/<UID>
```
[@api_view(['GET'])](https://github.com/da0ran9e/Books-System/blob/88fcad1d5682debac559cfef3459acb3780f7382/backend/drf_book/api/views.py#L67-L79)

## Java Image downloader <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/java/java-original.svg" alt="java" width="40" height="40"/> <a href="https://github.com/jhy/jsoup/"><img src="https://github.com/da0ran9e/Books-System/assets/98570451/74eeea65-2985-432c-a814-f7405ad5e7b1" alt="jsoup" width="30" height="30" /> </a>

Using [JSoup](https://github.com/da0ran9e/Books-System/blob/main/Automation/jsoup-1.15.4.jar) java library to make HTTP protocol <br />
Downloading images from URLs specified in a CSV file.
- CSV Processing:

The program reads the name of a CSV file from the user, which contains data with semicolon-separated values.
- String Manipulation:

It includes utility methods to split strings, remove leading and trailing quotes, and escape single quotes. These methods help in processing CSV data.
- Image Download:

The program uses the Jsoup library to connect to URLs specified in the CSV file and download images.
It checks if the destination file already exists and skips downloading if it does.
The image download progress is monitored, and the size of the downloaded image is displayed.
- Main Logic:

The main logic reads each line from the CSV file, extracts URLs from specific columns, and downloads images to a specified destination.
It includes conditions to skip downloading images based on their size.
- Error Handling:

The program handles exceptions related to URL parsing, image downloading, and file I/O.
Informative error messages are displayed in case of errors.
- User Interaction:

The program interacts with the user by requesting the input CSV file name and providing status messages.

## C/C++ CSV/SQL converter <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/c/c-original.svg" alt="c" width="40" height="40"/> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/cplusplus/cplusplus-original.svg" alt="cplusplus" width="40" height="40"/>   
Reading data from a CSV file and generates SQL insert statements for a database table. 
- Input:
  The program prompts the user to input the names of the CSV file and the SQL output file.

- CSV Processing:

The code defines three functions for string manipulation: `splitString`, `removeQuotes`, and `escapeSingleQuotes`.
splitString separates a string into columns using a specified delimiter (in this case, `;`).
`removeQuotes` removes double quotes from the beginning and end of a string if they exist.
`escapeSingleQuotes` replaces single quotes within a string with two single quotes to escape them for SQL.
- File Handling:

The program opens the input and output files using ifstream and ofstream.
It checks if the files can be opened successfully and reports errors if they cannot.
- CSV to SQL Conversion:

The code reads each line from the CSV file and splits it into columns.
It constructs SQL insert statements by formatting the column values and appends them to the output file.

[CSV to SQL converter](https://github.com/da0ran9e/Books-System/blob/main/CSV2SQL.cpp)

## SQL Server Database, SQLite backend <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="40" height="40"/> <img src="https://www.vectorlogo.zone/logos/sqlite/sqlite-icon.svg" alt="sqlite" width="40" height="40"/> 
See original dataset in my old project [here](https://github.com/da0ran9e/Book-Recommendation-System)!<br />
An addition `users` table data is designed to store user information, including personal details, login credentials, and profile-related data:
- `id`: An auto-incremented integer primary key.
- `firstName`: A nullable NVARCHAR (Unicode) column for the user's first name (up to 50 characters).
- `lastName`: A nullable NVARCHAR (Unicode) column for the user's last name (up to 50 characters).
- `username`: A VARCHAR column for the username (up to 50 characters), which is not nullable and has a unique constraint.
- `password`: A VARCHAR column for the user's password (up to 50 characters), which is not nullable.
- `email`: A nullable VARCHAR column for the user's email address (up to 150 characters).
- `phone`: A nullable VARCHAR column for the user's phone number (up to 20 characters).
- `gender`: A nullable TINYINT (tiny integer) column, which can represent gender information.
- `birthDate`: A nullable DATE column for the user's date of birth.
- `profileImage`: A nullable VARCHAR column for the path or URL to the user's profile image (up to 350 characters).
- `age`: A nullable integer column for the user's age.
- `location`: A nullable VARCHAR column for the user's location (up to 50 characters).
- `nation`: A nullable VARCHAR column for the user's nationality (up to 50 characters).
The table has a `primary key` constraint on the `id` column and a `unique` constraint on the `username` column to ensure that each `username` is `unique` within the table.
## Assets
![image](https://github.com/da0ran9e/Books-System/assets/98570451/c8cbc5a2-c0bb-444c-a888-e4daa79291db)
Almost application's background were generated by [Stable Diffusion WebUI](https://github.com/AUTOMATIC1111/stable-diffusion-webui) `version 1.5.2` 
Icons from [flaticon](https://www.flaticon.com/) <img src="[https://raw.githubusercontent.com/devicons/devicon/master/icons/c/c-original.svg](https://media.flaticon.com/dist/min/img/logo/flaticon_negative.svg)" alt="flaticon" width="40" height="40"/> 

## Languages and Tools:
  <a href="https://github.com/da0ran9e/Books-System#readme/## C/C++ CSV/SQL converter" target="_blank" rel="noreferrer"> 
    <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/c/c-original.svg" alt="c" width="40" height="40"/> 
  </a> 
  <a href="https://github.com/da0ran9e/Books-System#readme/## C/C++ CSV/SQL converter" target="_blank" rel="noreferrer"> 
    <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/cplusplus/cplusplus-original.svg" alt="cplusplus" width="40" height="40"/> 
  </a> 
  <a href="https://github.com/da0ran9e/Books-System#readme/## C# Windows Forms .NET" target="_blank" rel="noreferrer"> 
    <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> 
  </a> 
  <a href="https://github.com/da0ran9e/Books-System#readme/## Java Image downloader" target="_blank" rel="noreferrer"> 
    <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/java/java-original.svg" alt="java" width="40" height="40"/> 
  </a> 
  <a href="https://github.com/da0ran9e/Books-System#readme/## Python backend algorithm" target="_blank" rel="noreferrer"> 
    <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/python/python-original.svg" alt="python" width="40" height="40"/> 
  </a> 
  <a href="https://github.com/da0ran9e/Books-System#readme/" target="_blank" rel="noreferrer"> 
    <img src="https://cdn.worldvectorlogo.com/logos/django.svg" alt="django" width="40" height="40"/> 
  </a>
  <a href="https://github.com/da0ran9e/Books-System#readme/" target="_blank" rel="noreferrer"> 
    <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/> 
  </a> 
  <a href="https://github.com/da0ran9e/Books-System#readme/" target="_blank" rel="noreferrer"> 
    <img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" alt="git" width="40" height="40"/> 
  </a> 
  <a href="https://github.com/da0ran9e/Books-System#readme/" target="_blank" rel="noreferrer"> 
    <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="40" height="40"/> 
  </a> 
  <a href="https://github.com/da0ran9e/Books-System#readme/## Python backend algorithm" target="_blank" rel="noreferrer"> 
    <img src="https://raw.githubusercontent.com/devicons/devicon/2ae2a900d2f041da66e950e4d48052658d850630/icons/pandas/pandas-original.svg" alt="pandas" width="40" height="40"/> 
  </a> 
  <a href="https://github.com/da0ran9e/Books-System#readme/## Python backend algorithm" target="_blank" rel="noreferrer"> 
    <img src="https://upload.wikimedia.org/wikipedia/commons/0/05/Scikit_learn_logo_small.svg" alt="scikit_learn" width="40" height="40"/> 
  </a> 
  <a href="https://github.com/da0ran9e/Books-System#readme/" target="_blank" rel="noreferrer"> 
    <img src="https://www.vectorlogo.zone/logos/sqlite/sqlite-icon.svg" alt="sqlite" width="40" height="40"/> 
  </a> 
  <a href="https://github.com/da0ran9e/Books-System#readme/" target="_blank" rel="noreferrer"> 
    <img src="https://www.vectorlogo.zone/logos/gnu_bash/gnu_bash-icon.svg" alt="bash" width="40" height="40"/> 
  </a> 
