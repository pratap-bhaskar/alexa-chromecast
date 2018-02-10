using System;
using System.Threading.Tasks;
using AwsSkills.Common;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace AwsSkills.Lambda.IntentHandlers
{
    public abstract class IntentHandlerBase : IIntentHandler
    {
        protected readonly INotifier _notifier;

        public IntentHandlerBase(INotifier notifier)
        {
            _notifier = notifier;
        }

        public abstract Task<Tuple<ICard, IOutputSpeech, Reprompt>> HandleAsync(Intent intent);
    }
}
