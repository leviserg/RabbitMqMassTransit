using MessageContract;

namespace Sender.Services
{
    public interface ICustomSenderService
    {
        Task SendMessageAsync(CustomMessage message);
    }
}
