using System;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace AwsSkills.Lambda.IntentHandlers
{
    public class PowerOffIntentHandler : IIntentHandler
    {
        public Tuple<ICard, IOutputSpeech, Reprompt> Handle(Intent intent)
        {
            //TODO : publish SNS to a local server
            return ResponseBuilder.BuildResponse("Ok");
        }
    }
}
