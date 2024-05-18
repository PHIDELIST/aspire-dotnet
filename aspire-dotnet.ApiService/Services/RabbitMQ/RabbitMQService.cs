using RabbitMQ.Client;
using System;
using System.Text;
using Microsoft.Extensions.Configuration;

public class RabbitMQService : IRabbitMQService
{
    private readonly IConfiguration _configuration;

    public RabbitMQService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendMessage(string message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = _configuration["RabbitMQ:Hostname"],
            Port = int.Parse(_configuration["RabbitMQ:Port"]?? "5672"),
            UserName = _configuration["RabbitMQ:Username"],
            Password = _configuration["RabbitMQ:Password"],
            VirtualHost = _configuration["RabbitMQ:VirtualHost"]
        };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "my_queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "my_queue",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }
    }
}
