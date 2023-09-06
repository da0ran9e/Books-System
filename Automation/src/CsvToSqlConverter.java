import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class CsvToSqlConverter {
    public static List<String> splitString(String str, char delimiter) {
        List<String> result = new ArrayList<>();
        String[] parts = str.split(String.valueOf(delimiter));
        for (String part : parts) {
            result.add(part);
        }
        return result;
    }

    public static String removeQuotes(String str) {
        if (str.length() >= 2 && str.charAt(0) == '"' && str.charAt(str.length() - 1) == '"') {
            return str.substring(1, str.length() - 1);
        }
        return str;
    }

    public static String escapeSingleQuotes(String str) {
        StringBuilder result = new StringBuilder();
        for (char c : str.toCharArray()) {
            if (c == '\'') {
                result.append("''");
            } else {
                result.append(c);
            }
        }
        return result.toString();
    }

    public static void main(String[] args) {
        String inputFileName, outputFileName;

        System.out.print("Nhập tên file CSV: ");
        inputFileName = System.console().readLine();

        System.out.print("Nhập tên file SQL đầu ra: ");
        outputFileName = System.console().readLine();

        try (BufferedReader inputFile = new BufferedReader(new FileReader(inputFileName));
             BufferedWriter outputFile = new BufferedWriter(new FileWriter(outputFileName))) {

            String line;
            while ((line = inputFile.readLine()) != null) {
                List<String> columns = splitString(line, ';');

                if (columns.size() > 0) {
                    outputFile.write("insert into [books] ([isbn],[bookTitle],[bookAuthor],[yearOfPublication],[publisher],[imageURLS],[imageURLM],[imageURLL]) VALUES (N'"
                            + removeQuotes(escapeSingleQuotes(columns.get(0))) + "', N'" + removeQuotes(escapeSingleQuotes(columns.get(1))) + "', N'" + removeQuotes(escapeSingleQuotes(columns.get(2))) + "', '"
                            + removeQuotes(escapeSingleQuotes(columns.get(3))) + "', N'" + removeQuotes(escapeSingleQuotes(columns.get(4))) + "', N'" + removeQuotes(escapeSingleQuotes(columns.get(5))) + "', N'"
                            + removeQuotes(escapeSingleQuotes(columns.get(6))) + "', N'" + removeQuotes(escapeSingleQuotes(columns.get(7))) + "');\n");
                }
            }

            System.out.println("Chuyển đổi thành công.");

        } catch (IOException e) {
            System.err.println("Xảy ra lỗi khi đọc/ghi file.");
            e.printStackTrace();
        }
    }
}
