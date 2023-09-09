#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_LINE_LENGTH 1000 // Maximum line length in the file

// Function to replace an old word with a new word in a string
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

    printf("Enter the SQL file name: ");
    scanf("%s", filename);

    // Open the file for reading
    file = fopen(filename, "r");
    if (file == NULL) {
        printf("Unable to open the file. Please check the file name.\n");
        return 1;
    }

    printf("Enter the word to replace: ");
    scanf("%s", oldWord);

    printf("Enter the new word: ");
    scanf("%s", newWord);

    // Read each line in the file
    while (fgets(line, MAX_LINE_LENGTH, file) != NULL) {
        // Replace the old word with the new word in the line
        replaceWord(line, oldWord, newWord);
        printf("%s", line); // Print the line with replacements

        // Save the replaced line to a new file
        FILE *newFile = fopen("new_file.sql", "a");
        if (newFile == NULL) {
            printf("Unable to create a new file.\n");
            return 1;
        }
        fputs(line, newFile);
        fclose(newFile);
    }

    fclose(file);
    printf("Replacement process completed.\n");

    return 0;
}
