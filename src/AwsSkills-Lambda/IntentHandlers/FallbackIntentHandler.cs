using System;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace AwsSkills.Lambda.IntentHandlers
{
    public class FallbackIntentHandler : IIntentHandler
    {
        public Tuple<ICard, IOutputSpeech, Reprompt> Handle(Intent intent)
        {
            return ResponseBuilder.BuildResponse($"No handler for {intent.Name}");
        }
    }
}
