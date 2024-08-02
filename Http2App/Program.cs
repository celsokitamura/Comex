using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Http2App
{
    class Program
    {
        static async Task Main(string[] args) 
        { 
            using (HttpClient client = new HttpClient()) 
            {
                //client.DefaultRequestVersion = new Version(2, 0);
                client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
                Stopwatch stopwatch = Stopwatch.StartNew();
                HttpResponseMessage response = await client.GetAsync("https://http2.akamai.com/demo");
                stopwatch.Stop();

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Status Code: {response.StatusCode}");
                Console.WriteLine($"Protocol Version: {response.Version}");
                Console.WriteLine($"Response Time: {stopwatch.ElapsedMilliseconds} ms");
                Console.WriteLine("Response Body: ");
                Console.WriteLine(responseBody);
            }
        }
    }
}