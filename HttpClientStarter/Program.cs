
using var client = new HttpClient();

var requestBody = new StringContent("{\r\n  \"id\": 100,\r\n  \"name\": \"Jane Doe\",\r\n  \"username\": \"janedoe\",\r\n  \"email\": \"jane@example.com\",\r\n  \"isActive\": true,\r\n  \"roles\": [\"admin\", \"editor\"],\r\n  \"address\": {\r\n    \"street\": \"123 Main St\",\r\n    \"city\": \"Metropolis\",\r\n    \"zipcode\": \"12345\"\r\n  }\r\n}");

var response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts/1xx", requestBody);

while (true)
{
    Console.WriteLine("\nSelect Action:\n\nA - Get\nB - Post\nC - Put\nD - Delete");
    Console.Write("\nEnter choice: ");

    string choice = Console.ReadLine();


    if (choice == "A")
    {
        response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1");

        Console.WriteLine($"\nStatus Code: {(int)response.StatusCode}");
        Console.WriteLine($"Status: {response.StatusCode}");
        Console.WriteLine($"Is Success: {response.IsSuccessStatusCode}");
        Console.WriteLine("\nRetrieved forecast:\n");

    }
    else if (choice == "B")
    {
        response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", requestBody);

        Console.WriteLine($"\nStatus Code: {(int)response.StatusCode}");
        Console.WriteLine($"Status: {response.StatusCode}");
        Console.WriteLine($"Is Success: {response.IsSuccessStatusCode}");
        Console.WriteLine("\nAdded info:");


    }
    else if (choice == "C")
    {
        response = await client.PutAsync("https://jsonplaceholder.typicode.com/posts/1", requestBody);

        Console.WriteLine($"\nStatus Code: {(int)response.StatusCode}");
        Console.WriteLine($"Status: {response.StatusCode}");
        Console.WriteLine($"Is Success: {response.IsSuccessStatusCode}");
        Console.WriteLine("\nUpdated info:");

    }
    else if (choice == "D")
    {
        response = await client.DeleteAsync("https://jsonplaceholder.typicode.com/posts/1");

        Console.WriteLine($"\nStatus Code: {(int)response.StatusCode}");
        Console.WriteLine($"Status: {response.StatusCode}");
        Console.WriteLine($"Is Success: {response.IsSuccessStatusCode}");
        Console.WriteLine("\nDeleted.");
    }
    else
    {
        Console.WriteLine("Invalid choice.");
        return;
    }

    // ✅ Show response details

    //Console.WriteLine($"Raw response: {response}");


    var body = await response.Content.ReadAsStringAsync();
    Console.WriteLine(body);

}
