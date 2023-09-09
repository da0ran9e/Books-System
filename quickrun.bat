@echo off
echo Quick run the system.
echo -----------------------------
start cmd /c "pip install -r requirements.txt && python backend\drf_book\manage.py migrate && python backend\drf_book\manage.py runserver && pause"
start cmd /c "src\WinForms\bin\Release\net6.0-windows\Winforms.exe&& pause"
echo -----------------------------
pause
