using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpBasicsApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://fakestoreapi.com/products");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Status Code: {response.StatusCode}");
                Console.WriteLine("Response Body: ");
                Console.WriteLine(responseBody);
            }
        }
    }
}