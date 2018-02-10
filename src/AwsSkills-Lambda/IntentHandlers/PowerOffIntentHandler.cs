using System;
using System.Threading.Tasks;
using AwsSkills.Common;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace AwsSkills.Lambda.IntentHandlers
{
    public class PowerOffIntentHandler : IntentHandlerBase, IIntentHandler
    {
        public PowerOffIntentHandler(INotifier notifier) : base(notifier)
        {
        }

        public override async Task<Tuple<ICard, IOutputSpeech, Reprompt>> HandleAsync(Intent intent)
        {
            await _notifier.NotifyAsync(AlexaMessage.CreateMessage(Commands.PowerOffCommand));
            return ResponseBuilder.BuildResponse("Ok");
        }
    }
}
