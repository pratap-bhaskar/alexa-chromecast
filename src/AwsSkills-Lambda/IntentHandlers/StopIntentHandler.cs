using System;
using System.Threading.Tasks;
using AwsSkills.Common;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace AwsSkills.Lambda.IntentHandlers
{
    public class StopIntentHandler : IntentHandlerBase, IIntentHandler
    {
        public StopIntentHandler(INotifier notifier) : base(notifier)
        {
        }

        public override async Task<Tuple<ICard, IOutputSpeech, Reprompt>> HandleAsync(Intent intent)
        {
            await _notifier.NotifyAsync(AlexaMessage.CreateMessage(Commands.StopCommand));
            return ResponseBuilder.BuildResponse("Ok", "ChromeCast - Video stopped");
        }
    }
}
