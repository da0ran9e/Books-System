#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>

using namespace std;

// Function to split a string into columns based on a delimiter
vector<string> splitString(const string &str, char delimiter) {
    vector<string> result;
    stringstream ss(str);
    string item;

    while (getline(ss, item, delimiter)) {
        result.push_back(item);
    }

    return result;
}

// Function to remove double quotes from the beginning and end of a string
string removeQuotes(const string &str) {
    if (str.size() >= 2 && str.front() == '"' && str.back() == '"') {
        return str.substr(1, str.size() - 2);
    }
    return str;
}

// Function to escape single quotes in a string for SQL
string escapeSingleQuotes(const string &str) {
    string result = str;
    size_t pos = result.find("'");
    while (pos != string::npos) {
        result.replace(pos, 1, "''");
        pos = result.find("'", pos + 2); // Start searching from the position after the single quote
    }
    return result;
}

int main() {
    string inputFileName, outputFileName;

    cout << "Enter the CSV file name: ";
    cin >> inputFileName;

    cout << "Enter the SQL output file name: ";
    cin >> outputFileName;

    ifstream inputFile(inputFileName);
    ofstream outputFile(outputFileName);

    if (!inputFile.is_open()) {
        cout << "Unable to open the CSV file." << endl;
        return 1;
    }

    if (!outputFile.is_open()) {
        cout << "Unable to create the SQL file." << endl;
        return 1;
    }

    string line;
    while (getline(inputFile, line)) {
        vector<string> columns = splitString(line, ';');

        if (columns.size() > 0) {
            outputFile << "INSERT INTO [ratings] ([userId], [isbn], [bookRating]) VALUES ("
                       << removeQuotes(escapeSingleQuotes(columns[0])) << ", N'"
                       << removeQuotes(escapeSingleQuotes(columns[1])) << "', "
                       << removeQuotes(escapeSingleQuotes(columns[2])) << ");\n";
            cout << "INSERT INTO [ratings] ([userId], [isbn], [bookRating]) VALUES ("
                       << removeQuotes(escapeSingleQuotes(columns[0])) << ", N'"
                       << removeQuotes(escapeSingleQuotes(columns[1])) << "', "
                       << removeQuotes(escapeSingleQuotes(columns[2])) << ");\n";
        }
    }

    inputFile.close();
    outputFile.close();

    cout << "Conversion completed successfully." << endl;

    return 0;
}
