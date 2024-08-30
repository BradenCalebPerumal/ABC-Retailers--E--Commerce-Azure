using Azure.Storage.Queues;
using System.Text.Json;
using System.Threading.Tasks;
using CLDV6211_ST10287165_POE_P1.Models;

namespace CLDV6211_ST10287165_POE_P1.Services
{
    public class QueueService
    {
        private readonly QueueClient _queueClient;

        public QueueService(string connectionString, string queueName)
        {
            _queueClient = new QueueClient(connectionString, queueName);
            _queueClient.CreateIfNotExists();  // Ensure the queue exists
        }

        public async Task SendMessageAsync(OrderQueueMessage orderMessage)
        {
            var messageJson = JsonSerializer.Serialize(orderMessage);
            await _queueClient.SendMessageAsync(messageJson);
        }
    }
}
//done
