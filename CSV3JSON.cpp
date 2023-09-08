#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <iomanip> // For proper JSON formatting

using namespace std;

// Hàm tách chuỗi thành các cột dựa trên dấu phân tách
vector<string> splitString(const string &str, char delimiter) {
    vector<string> result;
    stringstream ss(str);
    string item;

    while (getline(ss, item, delimiter)) {
        result.push_back(item);
    }

    return result;
}

string removeQuotes(const string &str) {
    if (str.size() >= 2 && str.front() == '"' && str.back() == '"') {
        return str.substr(1, str.size() - 2);
    }
    return str;
}

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

    cout << "Nhập tên file CSV: ";
    cin >> inputFileName;

    cout << "Nhập tên file JSON đầu ra: ";
    cin >> outputFileName;

    ifstream inputFile(inputFileName);
    ofstream outputFile(outputFileName);

    if (!inputFile.is_open()) {
        cout << "Không thể mở file CSV." << endl;
        return 1;
    }

    if (!outputFile.is_open()) {
        cout << "Không thể tạo file JSON." << endl;
        return 1;
    }

    string line;
    outputFile << "["; // Start of JSON array

    while (getline(inputFile, line)) {
        vector<string> columns = splitString(line, ';');

        if (columns.size() > 0) {
            outputFile << "{"
                       << "\"userId\": \"" << escapeJsonString(removeQuotes(columns[0])) << "\", "
                       << "\"isbn\": \"" << escapeJsonString(removeQuotes(columns[1])) << "\", "
                       << "\"bookRating\": \"" << escapeJsonString(removeQuotes(columns[2])) << "\", "
                       << "},\n";
        }
    }

    inputFile.close();

    // Remove the trailing comma and newline character
    outputFile.seekp(-2, outputFile.end);
    outputFile << "\n]"; // End of JSON array
    outputFile.close();

    cout << "Chuyển đổi thành công." << endl;

    return 0;
}
