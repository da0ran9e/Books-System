#include <iostream>
#include <fstream>
#include <sstream>
#include <map>
#include <vector>
#include <cstdlib> // Để sử dụng hàm std::atoi

struct RatingData {
    int totalRating = 0;
    int count = 0;
};

void processLine(const std::string& line, std::map<std::string, RatingData>& bookData) {
    std::stringstream ss(line);
    std::string userId, isbn, ratingStr;
    std::getline(ss, userId, ';');
    std::getline(ss, isbn, ';');
    std::getline(ss, ratingStr, ';');

    int rating = 0; // Giá trị mặc định nếu có lỗi

    try {
        rating = std::atoi(ratingStr.c_str());
    } catch (const std::exception& e) {
        // Xử lý lỗi ở đây, ví dụ: rating = 0;
    }

    if (rating != 0) {
        bookData[isbn].totalRating += rating;
        bookData[isbn].count++;
    }
}

int main() {
    std::map<std::string, RatingData> bookData; // Lưu trữ dữ liệu đánh giá theo mã số sách
    std::ifstream inputFile("BX-Book-Ratings.csv"); // Đổi tên file dữ liệu thật

    if (!inputFile.is_open()) {
        std::cout << "Không thể mở file dữ liệu!" << std::endl;
        return 1;
    }

    // Bỏ qua dòng đầu tiên chứa tiêu đề cột
    std::string line;
    std::getline(inputFile, line);

    while (std::getline(inputFile, line)) {
        processLine(line, bookData);
    }

    inputFile.close();

    std::ofstream outputFile("output_data.csv");

    if (!outputFile.is_open()) {
        std::cout << "Không thể mở file kết quả!" << std::endl;
        return 1;
    }

    int id = 0;
    outputFile << "\"ID\";\"ISBN\";\"AVR\";\"COUNT\"" << std::endl;

    for (const auto& entry : bookData) {
        const std::string& isbn = entry.first;
        const RatingData& data = entry.second;

        if (data.count > 0) {
            double averageRating = static_cast<double>(data.totalRating) / data.count;
            outputFile << id << ";\"" << isbn << "\";" << averageRating << ";" << data.count << std::endl;
            id++;
        }
    }

    outputFile.close();

    std::cout << "Xong! Kết quả đã được ghi vào file output_data.csv" << std::endl;

    return 0;
}
