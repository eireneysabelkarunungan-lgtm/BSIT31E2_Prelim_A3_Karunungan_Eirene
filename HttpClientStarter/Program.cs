
using var client = new HttpClient();

var requestBody = new StringContent("{\r\n  \"id\": 100,\r\n  \"name\": \"Jane Doe\",\r\n  \"username\": \"janedoe\",\r\n  \"email\": \"jane@example.com\",\r\n  \"isActive\": true,\r\n  \"roles\": [\"admin\", \"editor\"],\r\n  \"address\": {\r\n    \"street\": \"123 Main St\",\r\n    \"city\": \"Metropolis\",\r\n    \"zipcode\": \"12345\"\r\n  }\r\n}");

var response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts/1xx", requestBody);

// ✅ Show response details
Console.WriteLine($"Status Code: {(int)response.StatusCode}");
Console.WriteLine($"Status: {response.StatusCode}");
Console.WriteLine($"Is Success: {response.IsSuccessStatusCode}");
Console.WriteLine($"Raw response: {response}");

var body = await response.Content.ReadAsStringAsync();
Console.WriteLine(body);