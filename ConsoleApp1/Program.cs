using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            ////var task = Task.Run(() => ReadContent("https://www.youtube.com/watch?v=kDUDX3VJFEc&list=PL4n1Qos4Tb6SWPbJNpiznp-Ok4A8J_23l&index=40&ab_channel=Metigator%7C%D8%B9%D8%B5%D8%A7%D9%85%D8%B9%D8%A8%D8%AF%D8%A7%D9%84%D9%86%D8%A8%D9%8A"));
            ////var awaiter = task.GetAwaiter();
            ////awaiter.OnCompleted(()=> Console.WriteLine(awaiter.GetResult()));
            
            //var content = ReadContentAsync("https://www.youtube.com/watch?v=kDUDX3VJFEc&list=PL4n1Qos4Tb6SWPbJNpiznp-Ok4A8J_23l&index=40&ab_channel=Metigator%7C%D8%B9%D8%B5%D8%A7%D9%85%D8%B9%D8%A8%D8%AF%D8%A7%D9%84%D9%86%D8%A8%D9%8A");
            //Console.WriteLine(content.Result);
            //Console.ReadKey();
            CancellationTokenSource cts = new CancellationTokenSource();
            await DoCheck01(cts);
        }

        static async Task DoCheck01(CancellationTokenSource cts) {
            Task.Run(() => {
                var input = Console.ReadKey();
                if (input.Key == (ConsoleKey.Q)) { 
                    cts.Cancel();
                    Console.WriteLine("Cancellation requested.!!!!!!!!!!!!!");
                }
                
            
            });

            while (true) {
                cts.Token.ThrowIfCancellationRequested();
                Console.WriteLine("Working...");
                await Task.Delay(7000);
                Console.WriteLine($"Completed at {DateTime.Now}");
                Console.WriteLine("Press Q to cancel");

            }

            Console.WriteLine("--------------Terminated--------------");
            cts.Dispose();
        }

        static Task<string> ReadContent(string url) {
            var client = new HttpClient();
            var task = client.GetStringAsync(url);

            return task;
        }
        static async Task<string> ReadContentAsync(string url)
        {
            var client = new HttpClient();
            var content =await client.GetStringAsync(url);

            return content;
        }


        static void longRunningTask()
        {
            showThreadInfo(System.Threading.Thread.CurrentThread);
            System.Threading.Thread.Sleep(3000);

        }
        static void showThreadInfo(System.Threading.Thread th)
        {
            Console.WriteLine(th.ManagedThreadId + " ---- POOLED:" + th.IsThreadPoolThread
                + " ---- is background:" + th.IsBackground); // Fixed formatting issue here
        }

        static List<int> calculatePrimeNumbersWithRange(int innerbound, int upperbound)
        {
            List<int> primeNumbers = new List<int>();

            for (int k = innerbound; k <= upperbound; k++)
            {
                Boolean isprime = true;
                for (int m = 2; m < k; m++)
                {
                    if (k % m == 0)
                    {
                        isprime = false; break;
                    }

                }
                if (isprime)
                {
                    primeNumbers.Add(k);
                }
            }

           return primeNumbers;
        }
    }
}
