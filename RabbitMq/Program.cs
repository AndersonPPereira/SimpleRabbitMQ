using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMq
{
    class Program
    {
        private static readonly string _message = "Publicou a mensagem";
        private static readonly string _queueName = "filaRabbitMq";

        static void Main(string[] args)
        {
            var connectionFactory = GetConnectionFactory();
            var connection = CreateConnection(connectionFactory);
            var fila = CreateQueue(_queueName, connection);
            var retorno = WriteMessageOnQueue(_message, _queueName, connection);

            if(retorno)
                Console.WriteLine("Mensagem inserida com sucesso!");
            else
                Console.WriteLine("Erro!");

            Console.ReadLine();
        }

        public static ConnectionFactory GetConnectionFactory()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            return connectionFactory;
        }

        public static IConnection CreateConnection(ConnectionFactory connectionFactory)
        {
            return connectionFactory.CreateConnection();
        }

        public static QueueDeclareOk CreateQueue(string queueName, IConnection connection)
        {
            QueueDeclareOk queue;
            using (var channel = connection.CreateModel())
            {
                queue = channel.QueueDeclare(queueName, false, false, false, null);
            }
            return queue;
        }

        public static bool WriteMessageOnQueue(string message, string queueName, IConnection connection)
        {
            using (var channel = connection.CreateModel())
            {
                channel.BasicPublish(string.Empty, queueName, null, Encoding.ASCII.GetBytes(message));
            }

            return true;
        }

        public string RetrieveSingleMessage(string queueName, IConnection connection)
        {
            BasicGetResult data;
            using (var channel = connection.CreateModel())
            {
                data = channel.BasicGet(queueName, true);
            }
            return data != null ? System.Text.Encoding.UTF8.GetString(data.Body) : null;
        }
    }
}
