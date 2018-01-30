using System;
using System.Collections.Generic;
using System.Text;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace AwsSkills.Lambda.IntentHandlers
{
    public class HelpIntentHandler : IIntentHandler
    {
        public Tuple<ICard, IOutputSpeech, Reprompt> Handle(Intent intent)
        {
            //TODO : publish SNS to a local server
            return ResponseBuilder.BuildResponse(@"I can control your Chromecast, " +
                    "Tell me a video name, or to pause, resume, or turn the volume to numbers 1 through 10", "Chromecast");
        }
    }
}
