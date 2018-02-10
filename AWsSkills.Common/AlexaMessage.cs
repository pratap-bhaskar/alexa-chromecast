using System;
using System.Collections.Generic;

namespace AwsSkills.Common
{
    public class AlexaMessage
    {
        public string Command { get; set; }
        public DateTime TimeStamp { get; set; }
        public IDictionary<string,string> Parameters { get; set; }

        public static AlexaMessage CreateMessage(string command, IDictionary<string,string> parameters = null)
        {
            return new AlexaMessage
            {
                Command = command,
                TimeStamp = DateTime.UtcNow,
                Parameters = parameters
            };
        }
    }
}
