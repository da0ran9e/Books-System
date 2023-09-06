#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <dirent.h>

void executePowerShellCommands(const char *commands) {
    // Lệnh để mở Powershell
    const char* powershellCmd = "powershell.exe";
    
    // Sử dụng hàm popen() để mở Powershell và tạo một pipe
    FILE* powershellPipe = popen(powershellCmd, "w");
    if (!powershellPipe) {
        printf("Không thể mở Powershell.\n");
        return;
    }

    // Gửi chuỗi lệnh vào Powershell
    fprintf(powershellPipe, "%s\n", commands);
    fflush(powershellPipe);

    // Đóng pipe và kiểm tra kết quả
    if (pclose(powershellPipe) == -1) {
        printf("Lỗi khi đóng Powershell.\n");
        return;
    }
}

char* readTxtFileToString(const char* filename) {
    FILE* file = fopen(filename, "r");
    if (file == NULL) {
        printf("Không thể mở tệp tin %s\n", filename);
        return NULL;
    }

    // Đo kích thước tệp tin
    fseek(file, 0, SEEK_END);
    long file_size = ftell(file);
    rewind(file);

    // Tạo một chuỗi để lưu nội dung của tệp tin
    char* buffer = (char*)malloc(file_size + 1);

    if (buffer == NULL) {
        printf("Không đủ bộ nhớ để đọc tệp tin.\n");
        fclose(file);
        return NULL;
    }

    // Đọc nội dung của tệp tin vào chuỗi
    size_t result = fread(buffer, 1, file_size, file);
    if (result != file_size) {
        printf("Lỗi khi đọc tệp tin.\n");
        fclose(file);
        free(buffer);
        return NULL;
    }

    // Kết thúc chuỗi
    buffer[file_size] = '\0';

    // Đóng tệp tin và trả về chuỗi đọc được
    fclose(file);
    return buffer;
}

// Hàm thực thi một câu lệnh PowerShell
void executePowerShellCommand(const char *command) {
    char fullCommand[512];
    sprintf(fullCommand, "powershell.exe -Command \"%s\"", command);
    system(fullCommand);
}

int main() {
    // Đường dẫn đến thư mục chứa các tệp tin .txt
    const char *folderPath = "ps1";

    // Mở thư mục
    DIR *dir;
    struct dirent *entry;

    if ((dir = opendir(folderPath)) != NULL) {
        while ((entry = readdir(dir)) != NULL) {
            // Kiểm tra nếu tệp tin là tệp tin .txt
            if (strstr(entry->d_name, ".txt") != NULL) {
                char filePath[256];
                sprintf(filePath, "%s\\%s", folderPath, entry->d_name);

                // Mở tệp tin
                // FILE *file = fopen(filePath, "r");
                // if (file != NULL) {
                //     char line[256];
                //     while (fgets(line, sizeof(line), file) != NULL) {
                //         // Thực thi câu lệnh từ tệp tin .txt
                //         executePowerShellCommand(line);
                //     }
                //     fclose(file);
                // } else {
                //     printf("Không thể mở tệp tin %s\n", filePath);
                // }
                executePowerShellCommands(readTxtFileToString(filePath));
            }
        }
        closedir(dir);
    } else {
        perror("Không thể mở thư mục");
        return EXIT_FAILURE;
    }

    return EXIT_SUCCESS;
}
