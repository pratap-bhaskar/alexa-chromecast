using System;
using System.Threading.Tasks;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace AwsSkills.Lambda.IntentHandlers
{
    public class FallbackIntentHandler : IIntentHandler
    {
        public async Task<Tuple<ICard, IOutputSpeech, Reprompt>> HandleAsync(Intent intent)
        {
            return ResponseBuilder.BuildResponse($"No handler for {intent.Name}");
        }
    }
}
