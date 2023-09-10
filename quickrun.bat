@echo off
echo Quick run the system.
echo -----------------------------
start cmd /c "pip install -r requirements.txt && python backend\drf_book\manage.py migrate && python backend\drf_book\manage.py runserver && pause"
start cmd /c "cd src\WinForms\bin\Release\net6.0-windows && Winforms.exe && pause"
echo -----------------------------
echo System may have optimal recommendations on these user
echo smarnes71          z5lM&i
echo hnussen52          d6o0YMqd
echo tkerwine2          q5O4L.lY0
pause
