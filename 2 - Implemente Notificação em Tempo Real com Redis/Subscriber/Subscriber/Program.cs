using StackExchange.Redis;
using System;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            var subscriber = connection.GetSubscriber();

            subscriber.Subscribe("order", (channel, message) =>
            {
                Console.WriteLine($"{DateTime.UtcNow:o} => {message}");
            }, CommandFlags.None);

            Console.ReadLine();
        }
    }
}
