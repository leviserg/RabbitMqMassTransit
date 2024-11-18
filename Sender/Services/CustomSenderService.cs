
using MassTransit;
using MessageContract;

namespace Sender.Services
{
    public class CustomSenderService : ICustomSenderService
    {
        private readonly IBus _bus;

        public CustomSenderService(IBus bus)
        {
            _bus = bus;
        }

        public async Task SendMessageAsync(CustomMessage message)
        {
            await _bus.Publish(message);
        }
    }

}
