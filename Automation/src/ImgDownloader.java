import java.io.BufferedReader;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import org.jsoup.Connection;
import org.jsoup.Jsoup;

/**
 * A utility class for downloading images from URLs specified in a CSV file.
 */
public class ImgDownloader {

    /**
     * Splits a string into a list of substrings using a specified delimiter.
     *
     * @param str       The input string to split.
     * @param delimiter The character to use as a delimiter.
     * @return A list of substrings.
     */
    public static List<String> splitString(String str, char delimiter) {
        return List.of(str.split(String.valueOf(delimiter)));
    }

    /**
     * Removes leading and trailing double quotes from a string, if present.
     *
     * @param str The input string.
     * @return The string with leading and trailing double quotes removed.
     */
    public static String removeQuotes(String str) {
        if (str.length() >= 2 && str.charAt(0) == '"' && str.charAt(str.length() - 1) == '"') {
            return str.substring(1, str.length() - 1);
        }
        return str;
    }

    /**
     * Escapes single quotes in a string by doubling them.
     *
     * @param str The input string.
     * @return The string with single quotes escaped.
     */
    public static String escapeSingleQuotes(String str) {
        return str.replace("'", "''");
    }

    /**
     * Downloads an image from a URL and saves it to a destination file.
     *
     * @param imageUrl        The URL of the image to download.
     * @param destinationFile The path to the destination file where the image will be saved.
     * @return The size of the downloaded image in bytes, or -1 if an error occurs.
     */
    public static int downloadImage(String imageUrl, String destinationFile) {
        try {
            if (Files.exists(Paths.get(destinationFile))) {
                System.out.println("File already exists: " + destinationFile);
                return 0; // Return 0 to indicate that the file was not downloaded
            }

            Connection.Response response = Jsoup.connect(imageUrl).ignoreContentType(true).execute();
            try (InputStream inputStream = response.bodyStream();
                 FileOutputStream outputStream = new FileOutputStream(destinationFile)) {
                byte[] buffer = new byte[1024];
                int bytesRead;
                int size = 0;
                while ((bytesRead = inputStream.read(buffer)) != -1) {
                    outputStream.write(buffer, 0, bytesRead);
                    size += bytesRead;
                }
                System.out.println("Image downloaded " + size + " successfully to: " + destinationFile);
                return size;
            } catch (IOException e) {
                System.err.println("Error downloading the image: " + e.getMessage());
                return -1; // Return -1 to indicate an error
            }
        } catch (IOException e) {
            System.err.println("Error connecting to the image URL: " + e.getMessage());
            return -1; // Return -1 to indicate an error
        }
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the CSV file name: ");
        String inputFileName = scanner.next();

        try (BufferedReader inputFile = new BufferedReader(new FileReader(inputFileName))) {
            String line;
            while ((line = inputFile.readLine()) != null) {
                List<String> columns = splitString(line, ';');
                String imageUrl = removeQuotes(escapeSingleQuotes(columns.get(7)));
                String destination = "img/" + removeQuotes(escapeSingleQuotes(columns.get(0))) + ".jpg";

                try {
                    int size = downloadImage(imageUrl, destination);
                    if (size >= 0) {
                        if (size < 100) {
                            downloadImage(removeQuotes(escapeSingleQuotes(columns.get(6))),
                                    "img/" + removeQuotes(escapeSingleQuotes(columns.get(0))) + ".jpg");
                        }
                    }
                } catch (RuntimeException e) {
                    System.err.println("Error: " + e);
                }
            }
            System.out.println("Conversion successful.");
        } catch (IOException e) {
            System.err.println("Error reading/writing the file: " + e);
        }
    }
}
