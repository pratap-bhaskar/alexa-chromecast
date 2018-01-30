using System;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace AwsSkills.Lambda.IntentHandlers
{
    public interface IIntentHandler
    {
        Tuple<ICard, IOutputSpeech, Reprompt> Handle(Intent intent);
    }
}
