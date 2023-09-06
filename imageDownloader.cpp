#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <curl/curl.h>

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

// Callback function to write received data to a file
size_t WriteData(void* buffer, size_t size, size_t nmemb, void* userData) {
    std::ofstream* file = static_cast<std::ofstream*>(userData);
    if (file->is_open()) {
        file->write(static_cast<char*>(buffer), size * nmemb);
        return size * nmemb;
    }
    return 0;
}

bool DownloadImageFromURL(const char* url, const char* outputFileName) {
    CURL* curl = curl_easy_init();
    if (!curl) {
        std::cerr << "Failed to initialize libcurl." << std::endl;
        return false;
    }

    std::ofstream outputFile(outputFileName, std::ios::binary);
    if (!outputFile.is_open()) {
        std::cerr << "Failed to open the output file for writing." << std::endl;
        curl_easy_cleanup(curl);
        return false;
    }

    curl_easy_setopt(curl, CURLOPT_URL, url);
    curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, WriteData);
    curl_easy_setopt(curl, CURLOPT_WRITEDATA, &outputFile);

    CURLcode res = curl_easy_perform(curl);
    if (res != CURLE_OK) {
        std::cerr << "Failed to fetch the image: " << curl_easy_strerror(res) << std::endl;
        curl_easy_cleanup(curl);
        outputFile.close();
        return false;
    }

    curl_easy_cleanup(curl);
    outputFile.close();

    std::cout << "Image downloaded successfully." << std::endl;
    return true;
}

int main() {
    string inputFileName, outputFileName;
    
    cout << "Nhập tên file CSV: ";
    cin >> inputFileName;

    cout << "Nhập tên file text đầu ra: ";
    cin >> outputFileName;

    ifstream inputFile(inputFileName);
    ofstream outputFile(outputFileName);

    if (!inputFile.is_open()) {
        cout << "Không thể mở file CSV." << endl;
        return 1;
    }

    if (!outputFile.is_open()) {
        cout << "Không thể tạo file text." << endl;
        return 1;
    }
    string line;
    while (getline(inputFile, line)) {
        vector<string> columns = splitString(line, ';');

        if (columns.size() > 0) {
            if (DownloadImageFromURL(removeQuotes(escapeSingleQuotes(columns[7])), removeQuotes(escapeSingleQuotes(columns[0]))+".jpg")) {
                cout << "Ảnh đã được lưu xuống đĩa." << endl;
            } else {
                cerr << "Lỗi khi tải ảnh từ URL." << endl;
            }
            
        }
    }



    inputFile.close();
    outputFile.close();

    cout << "Chuyển đổi thành công." << endl;

    return 0;
}
