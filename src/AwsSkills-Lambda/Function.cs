using System;
using Amazon.Lambda.Core;
using AwsSkills.Lambda.IntentHandlers;
using Newtonsoft.Json;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Requests.RequestTypes;
using Slight.Alexa.Framework.Models.Responses;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AwsSkills.Lambda
{
    public class Function
    {

        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var log = context.Logger;
            var output = new SkillResponse();
            var response = new Response(); 
            IOutputSpeech innerResponse = null;
            response.ShouldEndSession = true;

            output.Response = response;

            Tuple<ICard, IOutputSpeech, Reprompt> responseBody = null;

            log.LogLine(JsonConvert.SerializeObject(input));

            if (input.GetRequestType() == typeof(ILaunchRequest))
            {
                log.LogLine($"Default launch request made: 'Alexa open chromecast menu'");
                responseBody = new HelpIntentHandler().Handle(null);

            }
            else if (input.GetRequestType() == typeof(IIntentRequest))
            {
                var intentRequest = input.Request as IIntentRequest;
                IIntentHandler intentHandler = null;

                switch (intentRequest.Intent.Name)
                {
                    case "PowerOff":
                        intentHandler = new PowerOffIntentHandler();
                        break;
                    case "AMAZON.PauseIntent":
                        intentHandler = new PauseIntentHandler();
                        break;
                    case "AMAZON.ResumeIntent":
                        intentHandler = new ResumeIntentHandler();
                        break;
                    case "AMAZON.StopIntent":
                        intentHandler = new StopIntentHandler();
                        break;
                    case "AMAZON.HelpIntent":
                        intentHandler = new HelpIntentHandler();
                        break;
                    default:
                        intentHandler = new FallbackIntentHandler();
                        break;
                }
                responseBody = intentHandler.Handle(intentRequest.Intent);
            }

            output.Response.Card = responseBody.Item1;
            output.Response.OutputSpeech = responseBody.Item2;
            output.Response.Reprompt = responseBody.Item3;
            return output;
        }
    }
}
