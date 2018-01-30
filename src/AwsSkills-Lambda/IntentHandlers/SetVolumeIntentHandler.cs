using System;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace AwsSkills.Lambda.IntentHandlers
{
    public class SetVolumeIntentHandler : IIntentHandler
    {
        public Tuple<ICard, IOutputSpeech, Reprompt> Handle(Intent intent)
        {
            //TODO: to push the data over the SNS
            var volumeSlot = intent.Slots["volume"];
            int volume = 0;
            if (!int.TryParse(volumeSlot.Value, out volume))
            {
                return ResponseBuilder.BuildResponse("Sorry, you can only set the volume between 0 and 10.",
                    "Chromecast", "Try using 'set volume to 5'");
            }
            else
            {
                return ResponseBuilder.BuildResponse("Ok", $"Chromecast - Volume set to {volume}");
            }
        }
    }
}
