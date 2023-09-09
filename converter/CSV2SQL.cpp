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

    // Prompt the user to enter the CSV file name
    cout << "Enter the CSV file name: ";
    cin >> inputFileName;

    // Prompt the user to enter the SQL output file name
    cout << "Enter the SQL output file name: ";
    cin >> outputFileName;

    ifstream inputFile(inputFileName);
    ofstream outputFile(outputFileName);

    // Check if the CSV file can be opened
    if (!inputFile.is_open()) {
        cout << "Unable to open the CSV file." << endl;
        return 1;
    }

    // Check if the SQL output file can be created
    if (!outputFile.is_open()) {
        cout << "Unable to create the SQL file." << endl;
        return 1;
    }

    string line;
    while (getline(inputFile, line)) {
        // Split the CSV line into columns
        vector<string> columns = splitString(line, ';');

        if (columns.size() > 0) {
            // Generate an SQL insert statement for the row and write it to the output file
            outputFile << "INSERT INTO [books] ([isbn],[bookTitle],[bookAuthor],[yearOfPublication],[publisher],[imageURLS],[imageURLM],[imageURLL]) "
                          "VALUES (N'" + removeQuotes(escapeSingleQuotes(columns[0])) + "', N'" +
                          removeQuotes(escapeSingleQuotes(columns[1])) + "', N'" +
                          removeQuotes(escapeSingleQuotes(columns[2])) + "', '" +
                          removeQuotes(escapeSingleQuotes(columns[3])) + "', N'" +
                          removeQuotes(escapeSingleQuotes(columns[4])) + "', N'" +
                          removeQuotes(escapeSingleQuotes(columns[5])) + "', N'" +
                          removeQuotes(escapeSingleQuotes(columns[6])) + "', N'" +
                          removeQuotes(escapeSingleQuotes(columns[7])) + "');\n";
        }
    }

    // Close the input and output files
    inputFile.close();
    outputFile.close();

    cout << "Conversion completed successfully." << endl;

    return 0;
}
