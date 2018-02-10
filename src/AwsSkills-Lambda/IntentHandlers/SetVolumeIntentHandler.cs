using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwsSkills.Common;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace AwsSkills.Lambda.IntentHandlers
{
    public class SetVolumeIntentHandler : IntentHandlerBase, IIntentHandler
    {
        public SetVolumeIntentHandler(INotifier notifier) : base(notifier)
        {
        }

        public override async Task<Tuple<ICard, IOutputSpeech, Reprompt>> HandleAsync(Intent intent)
        {
            
            var volumeSlot = intent.Slots["volume"];
            int volume = 0;
            if (!int.TryParse(volumeSlot.Value, out volume))
            {
                await _notifier.NotifyAsync(AlexaMessage.CreateMessage(Commands.SetVolumeCommand, 
                    new Dictionary<string, string> { {"Volume", volume.ToString() } }));
                return ResponseBuilder.BuildResponse("Sorry, you can only set the volume between 0 and 10.",
                    "Chromecast", "Try using 'set volume to 5'");
            }
            else
            {
                return ResponseBuilder.BuildResponse($"Volume set to {volume}", $"Chromecast - Volume set to {volume}");
            }
        }
    }
}
