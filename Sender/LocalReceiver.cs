using MassTransit;

namespace Sender
{
    public class LocalReceiver : IConsumer<Ping>
    {
        private readonly ILogger<LocalReceiver> _logger;

        public LocalReceiver(ILogger<LocalReceiver> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Ping> context)
        {
            var btn = context.Message.Button;
            _logger.LogInformation("Received event from btn pressed {Button}", btn);
            return Task.CompletedTask;
        }
    }
}
