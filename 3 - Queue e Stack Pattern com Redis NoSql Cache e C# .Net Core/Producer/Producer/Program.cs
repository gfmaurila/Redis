using StackExchange.Redis;
using System;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = ConnectionMultiplexer.Connect("127.0.0.1:6379");

            var database = conn.GetDatabase();

            var key = "1212121";

            for (var index = 1; index < 100; index++)
            {
                database.ListLeftPush($"{key}", "{ order: " + index + "}000, value: 10000}");
                Console.WriteLine($"{DateTime.UtcNow:o} -> published {index}");
            }

            Console.WriteLine($"{DateTime.UtcNow:o} -> end");
        }
    }
}
