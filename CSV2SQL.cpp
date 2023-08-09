#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>

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

string escapeSingleQuotes(const string &str) {
    string result = str;
    size_t pos = result.find("'");
    while (pos != string::npos) {
        result.replace(pos, 1, "''");
        pos = result.find("'", pos + 2); // Bắt đầu tìm kiếm từ vị trí sau dấu '
    }
    return result;
}

int main() {
    string inputFileName, outputFileName;
    
    cout << "Nhập tên file CSV: ";
    cin >> inputFileName;

    cout << "Nhập tên file SQL đầu ra: ";
    cin >> outputFileName;

    ifstream inputFile(inputFileName);
    ofstream outputFile(outputFileName);

    if (!inputFile.is_open()) {
        cout << "Không thể mở file CSV." << endl;
        return 1;
    }

    if (!outputFile.is_open()) {
        cout << "Không thể tạo file SQL." << endl;
        return 1;
    }

    string line;
    while (getline(inputFile, line)) {
        vector<string> columns = splitString(line, ';');

        if (columns.size() > 0) {
            outputFile << "insert into [books] ([isbn],[bookTitle],[bookAuthor],[yearOfPublication],[publisher],[imageURLS],[imageURLM],[imageURLL]) VALUES (N'"
                                  + removeQuotes(escapeSingleQuotes(columns[0])) + "', N'" + removeQuotes(escapeSingleQuotes(columns[1])) + "', N'" + removeQuotes(escapeSingleQuotes(columns[2])) + "', '"
                                  + removeQuotes(escapeSingleQuotes(columns[3])) + "', N'" + removeQuotes(escapeSingleQuotes(columns[4])) + "', N'" + removeQuotes(escapeSingleQuotes(columns[5])) + "', N'"
                                  + removeQuotes(escapeSingleQuotes(columns[6])) + "', N'" + removeQuotes(escapeSingleQuotes(columns[7])) + "');\n";
        }
    }

    inputFile.close();
    outputFile.close();

    cout << "Chuyển đổi thành công." << endl;

    return 0;
}
