import org.jsoup.Connection;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class PostJsonRequest {
    public static void main(String[] args) {
        try {
            // Specify the URL of the local host API endpoint
            String apiUrl = "http://localhost:8080/addbook/"; // Replace with your API URL

            // Open and read the JSON file line by line
            try (BufferedReader br = new BufferedReader(new FileReader("Book.txt"))) {
                String line;
                while ((line = br.readLine()) != null) {
                    // Create a Jsoup connection to the API URL
                    Connection connection = Jsoup.connect(apiUrl);

                    // Set the request method to POST
                    connection.method(Connection.Method.POST);

                    // Set the request body to the current JSON line
                    connection.requestBody(line);

                    // Execute the POST request and get the response
                    Connection.Response response = connection.execute();

                    // Check the response status code
                    int statusCode = response.statusCode();
                    if (statusCode == 200) {
                        // Successful response
                        System.out.println("POST request successful");
                        System.out.println("Response body: " + response.body());
                    } else {
                        // Handle error response
                        System.out.println("POST request failed with status code: " + statusCode);
                        System.out.println("Error message: " + response.body());
                    }
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
