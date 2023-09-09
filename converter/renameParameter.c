#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_LINE_LENGTH 1000 // Độ dài tối đa của một dòng trong file

// Hàm thay thế một từ cũ thành một từ mới trong một chuỗi
void replaceWord(char *str, const char *oldWord, const char *newWord) {
    char *pos, temp[MAX_LINE_LENGTH];
    int index = 0;
    int oldWordLength = strlen(oldWord);

    while ((pos = strstr(str, oldWord)) != NULL) {
        strcpy(temp, str);
        index = pos - str;
        str[index] = '\0';
        strcat(str, newWord);
        strcat(str, temp + index + oldWordLength);
    }
}

int main() {
    FILE *file;
    char filename[100];
    char oldWord[100], newWord[100];
    char line[MAX_LINE_LENGTH];

    printf("Nhập tên file SQL: ");
    scanf("%s", filename);

    // Mở file để đọc
    file = fopen(filename, "r");
    if (file == NULL) {
        printf("Không thể mở file. Hãy kiểm tra lại tên file.\n");
        return 1;
    }

    printf("Nhập từ cần thay thế: ");
    scanf("%s", oldWord);

    printf("Nhập từ mới: ");
    scanf("%s", newWord);

    // Đọc từng dòng trong file
    while (fgets(line, MAX_LINE_LENGTH, file) != NULL) {
        // Thay thế từ cũ thành từ mới trong dòng
        replaceWord(line, oldWord, newWord);
        printf("%s", line); // In dòng đã được thay thế

        // Lưu dòng đã thay thế vào file mới
        FILE *newFile = fopen("new_file.sql", "a");
        if (newFile == NULL) {
            printf("Không thể tạo file mới.\n");
            return 1;
        }
        fputs(line, newFile);
        fclose(newFile);
    }

    fclose(file);
    printf("Quá trình thay thế đã hoàn thành.\n");

    return 0;
}
