using MassTransit;
using MessageContract;
using System.Net.NetworkInformation;

namespace Receiver.Receivers
{
    public class CustomReceiverService : IConsumer<CustomMessage>
    {
        private readonly ILogger<CustomReceiverService> _logger;

        public CustomReceiverService(ILogger<CustomReceiverService> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<CustomMessage> context)
        {
            //var btn = context.Message.Button;
            var msg = context.Message;
            _logger.LogInformation(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
