using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                MainAsync().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }

        static async Task MainAsync()
        {
            var syncUrl = "https://localhost:44383/api/AsyncSync/sync/";
            var asyncUrl = "https://localhost:44383/api/AsyncSync/async/";

            int times = 0;
            times = Environment.ProcessorCount;
            Console.WriteLine($" Synchronous time for {times} connections: {await RunTest(syncUrl, times)}");

            times = Environment.ProcessorCount + 1;
            Console.WriteLine($" Synchronous time for {times} connections: {await RunTest(syncUrl, times)}");

            times = Environment.ProcessorCount;
            Console.WriteLine($"Asynchronous time for {times} connections: {await RunTest(asyncUrl, times)}");

            times = 200;
            Console.WriteLine($"Asynchronous time for {times} connections: {await RunTest(asyncUrl, times)}");

            Console.ReadLine();
        }

        static async Task<TimeSpan> RunTest(string url, int concurrentConnections)
        {
            var sw = new Stopwatch();
            var client = new HttpClient();

            sw.Start();
            await Task.WhenAll(Enumerable.Range(0, concurrentConnections).Select(i => client.GetStringAsync($"{url}{i}")));
            sw.Stop();

            return sw.Elapsed;
        }
    }
}
