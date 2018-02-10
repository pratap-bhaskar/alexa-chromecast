using System;
using System.Threading.Tasks;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace AwsSkills.Lambda.IntentHandlers
{
    public interface IIntentHandler
    {
        Task<Tuple<ICard, IOutputSpeech, Reprompt>> HandleAsync(Intent intent);
    }
}
