using System.Threading.Tasks;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Newtonsoft.Json;

namespace AwsSkills.Common
{
    public class SNSClientAdapter : INotifier
    {
        private readonly AmazonSimpleNotificationServiceClient _snsClient;
        private string _topicArn;

        public SNSClientAdapter()
        {
            _snsClient = new AmazonSimpleNotificationServiceClient();
            CreateTopicAsync().GetAwaiter().GetResult();
        }

        private async Task<bool> CreateTopicAsync()
        {
            var topicRequest = new CreateTopicRequest
            {
                Name = "AWSSkills"
            };
            var topicResponse = await _snsClient.CreateTopicAsync(topicRequest);
            _topicArn = topicResponse.TopicArn;

            return false;
        }
        
        public async Task NotifyAsync(AlexaMessage message)
        {
            await _snsClient.PublishAsync(new PublishRequest
            {
                Message = JsonConvert.SerializeObject(message),
                TopicArn = _topicArn
            });
        }
    }
}
