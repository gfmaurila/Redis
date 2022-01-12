using StackExchange.Redis;
using System;
using System.Threading;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = ConnectionMultiplexer.Connect("127.0.0.1:6379");

            var database = conn.GetDatabase();

            var key = "1212121";

            while (true)
            {
                var data = database.ListLeftPop(key);

                Console.WriteLine($"{DateTime.UtcNow:o} => {data}");
                Thread.Sleep(100);
            }

        }
    }
}
