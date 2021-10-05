using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}] - Início Programa de Soma");

            Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}] - Chamando Soma Síncrona");
            AdditionSync(5, 5);

            Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}] - Chamando Soma Síncrona");
            AdditionSync(6, 6);

            Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}] - Chamando Soma assíncrona");
            await AdditionAsync(5, 5);

            Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}] - Chamando Soma assíncrona");
            await AdditionAsync(6, 6);

            Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}] - Chamando Soma assíncrona");
            await AdditionAsync(7, 7);

            Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}] - Fim Programa de Soma");

            Console.ReadLine();
        }

        private static int AdditionSync(int no1, int no2)
        {
            var res = no1 + no2;
            Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}] - {no1} + {no2} = {res}");
            return res;
        }

        private static Task<int> AdditionAsync(int no1, int no2)
            => Task.Run(() => {
                var res = no1 + no2;
                Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}] - {no1} + {no2} = {res}");
                return res;
            });
    }
}
