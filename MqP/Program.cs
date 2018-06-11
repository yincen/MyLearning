using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace MqP
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "192.168.5.202";
            factory.UserName = "admin";
            factory.Password = "wwtx.202";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("task_queue", true, false, false, null);

                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;

                    while (true)
                    {
                        //var msg = GetMessage(args);
                        var msg = "messages " + DateTime.Now.ToString("HHmmssms");
                        var body = Encoding.UTF8.GetBytes(msg);
                        channel.BasicPublish("", "task_queue", properties, body);
                        Console.WriteLine("set " + msg);
                        //Thread.Sleep(100);
                    }
                }
            }
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
