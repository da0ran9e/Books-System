import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.io.*;
import java.net.*;
import java.util.Scanner;
import org.jsoup.Connection;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.nio.file.Files;
import java.nio.file.Paths;

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

    public static int downloadImage(String imageUrl, String destinationFile) throws IOException {

        if (Files.exists(Paths.get(destinationFile))) {
            System.out.println("File already exists: " + destinationFile);
            return 0; // Return 0 to indicate that the file was not downloaded
        }

        Connection.Response response = Jsoup.connect(imageUrl).ignoreContentType(true).execute();
        InputStream inputStream = response.bodyStream();
        int size =0;
        try (FileOutputStream outputStream = new FileOutputStream(destinationFile)) {
            byte[] buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = inputStream.read(buffer)) != -1) {
                outputStream.write(buffer, 0, bytesRead);
                size += bytesRead;
            }
            System.out.println("Image downloaded "+ size +" successfully to: " + destinationFile);
        } catch (IOException e) {
            System.err.println("Error downloading the image: " + e.getMessage());
        }
        return size;
    }

    public static void main(String[] args) {
        String inputFileName, outputFileName;

        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhập tên file CSV: ");

        inputFileName = scanner.next();

        try (BufferedReader inputFile = new BufferedReader(new FileReader(inputFileName));
             ) {

            String line;
            while ((line = inputFile.readLine()) != null) {
                List<String> columns = splitString(line, ';');
                System.out.println(removeQuotes(escapeSingleQuotes(columns.get(7))));
                try {
                    if(downloadImage(removeQuotes(escapeSingleQuotes(columns.get(7))),"img/" + removeQuotes(escapeSingleQuotes(columns.get(0)))+".jpg")<100){
                        if(downloadImage(removeQuotes(escapeSingleQuotes(columns.get(6))),"img/" + removeQuotes(escapeSingleQuotes(columns.get(0)))+".jpg")<500){
                        downloadImage(removeQuotes(escapeSingleQuotes(columns.get(5))),"img/" + removeQuotes(escapeSingleQuotes(columns.get(0)))+".jpg");

                    }
                    }
                } catch (IllegalArgumentException e) {
                    System.out.println(e);
                }

            }

            System.out.println("Chuyển đổi thành công.");

        } catch (IOException e) {
            System.err.println("Xảy ra lỗi khi đọc/ghi file.");
        }
    }
}
