using System;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace AwsSkills.Lambda
{
    public class ResponseBuilder
    {
        public static Tuple<ICard, IOutputSpeech, Reprompt> BuildResponse(string text, string title = "", string repromt = "")
        {
            return new Tuple<ICard, IOutputSpeech, Reprompt>(
                new SimpleCard { Title = title, Content = text },
                new PlainTextOutputSpeech { Text = text },
                new Reprompt { OutputSpeech = new PlainTextOutputSpeech { Text = string.IsNullOrEmpty(repromt) ? text : repromt } }
                );
        }
    }
}
