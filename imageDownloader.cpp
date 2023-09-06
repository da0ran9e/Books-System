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
    

    if (!inputFile.is_open()) {
        cout << "Không thể mở file CSV." << endl;
        return 1;
    }
    int cnt=0;
    string line;
    getline(inputFile, line);
    while (getline(inputFile, line)) {
        int offset = 1000;
        ofstream outputFile(outputFileName+std::to_string(cnt/1000)+".txt");


        while(offset--){
            cnt++;
            

            vector<string> columns = splitString(line, ';');

            if (columns.size() > 0) {
                outputFile << "if (Test-Path -Path img/"+ removeQuotes(escapeSingleQuotes(columns[0])) +".jpg) {} else {    Invoke-WebRequest -Uri "+ removeQuotes(escapeSingleQuotes(columns[7])) +" -OutFile img/"+ removeQuotes(escapeSingleQuotes(columns[0])) +".jpg }\n";
            }
            getline(inputFile, line);
        }
        outputFile.close();
        
    }

    inputFile.close();
    

    cout << "Chuyển đổi thành công." << endl;

    return 0;
}
