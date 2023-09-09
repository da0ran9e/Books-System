#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <iomanip> // For proper JSON formatting

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

// Function to escape special characters in a JSON string
string escapeJsonString(const string &str) {
    ostringstream escaped;
    for (char c : str) {
        if (c == '"' || c == '\\' || ('\x00' <= c && c <= '\x1f')) {
            escaped << "\\u" << setw(4) << setfill('0') << hex << static_cast<int>(c);
        } else {
            escaped << c;
        }
    }
    return escaped.str();
}

int main() {
    string inputFileName, outputFileName;

    cout << "Enter the CSV file name: ";
    cin >> inputFileName;

    cout << "Enter the JSON output file name: ";
    cin >> outputFileName;

    ifstream inputFile(inputFileName);
    ofstream outputFile(outputFileName);

    if (!inputFile.is_open()) {
        cout << "Unable to open the CSV file." << endl;
        return 1;
    }

    if (!outputFile.is_open()) {
        cout << "Unable to create the JSON file." << endl;
        return 1;
    }

    string line;
    outputFile << "["; // Start of JSON array

    while (getline(inputFile, line)) {
        vector<string> columns = splitString(line, ';');

        if (columns.size() > 0) {
            outputFile << "{"
                       << "\"isbn\": \"" << escapeJsonString(removeQuotes(columns[0])) << "\", "
                       << "\"bookTitle\": \"" << escapeJsonString(removeQuotes(columns[1])) << "\", "
                       << "\"bookAuthor\": \"" << escapeJsonString(removeQuotes(columns[2])) << "\", "
                       << "\"yearOfPublication\": \"" << escapeJsonString(removeQuotes(columns[3])) << "\", "
                       << "\"publisher\": \"" << escapeJsonString(removeQuotes(columns[4])) << "\", "
                       << "\"imageURLS\": \"" << escapeJsonString(removeQuotes(columns[5])) << "\", "
                       << "\"imageURLM\": \"" << escapeJsonString(removeQuotes(columns[6])) << "\", "
                       << "\"imageURLL\": \"" << escapeJsonString(removeQuotes(columns[7])) << "\""
                       << "},\n";
        }
    }

    inputFile.close();

    // Remove the trailing comma and newline character
    outputFile.seekp(-2, outputFile.end);
    outputFile << "\n]"; // End of JSON array
    outputFile.close();

    cout << "Conversion completed successfully." << endl;

    return 0;
}
