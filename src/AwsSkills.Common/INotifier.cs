using System.Threading.Tasks;

namespace AwsSkills.Common
{
    public interface INotifier
    {
        Task NotifyAsync(AlexaMessage message);
    }
}
