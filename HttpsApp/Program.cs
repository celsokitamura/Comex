using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpsApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://fakestoreapi.com/products";
                if(url.StartsWith("https://"))
                {
                    Console.WriteLine("A URL utiliza o protocolo HTTPS.");
                }
                else
                {
                    Console.WriteLine("A URL não utiliza o protocolo HTTPS.");
                    return;
                }

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Status Code: {response.StatusCode}");
                Console.WriteLine("Response Body: ");
                Console.WriteLine(responseBody);

            }
        }
    }
}
