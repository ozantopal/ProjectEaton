using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.ProjectEaton.Common.Services
{
    public class MessageQueueService : IMessageQueueService
    {
        private readonly string hostName; // = "localhost";
        private readonly string userName; // = "admin";
        private readonly string password; // = "123456";

        public MessageQueueService(string hostName, string userName, string password)
        {
            this.hostName = hostName;
            this.userName = userName;
            this.password = password;
        }

        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = hostName,
                UserName = userName,
                Password = password
            };

            return factory.CreateConnection();
        }
    }
}
