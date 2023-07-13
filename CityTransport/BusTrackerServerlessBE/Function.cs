using Amazon.Lambda.Core;
using Alexa.NET.Response;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Newtonsoft.Json;
using Alexa.NET;
using Alexa.NET.Response.Ssml;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace BusTrackerServerlessBE
{
    public class Function
    {
        public async Task<SkillResponse> FunctionHandlerAsync(SkillRequest input, ILambdaContext context)
        {
            ILambdaLogger log = context.Logger;
            log.LogLine($"Skill Request Object:" + JsonConvert.SerializeObject(input));

            Session session = input.Session;
            if (session.Attributes == null)
                session.Attributes = new Dictionary<string, object>();

            Type requestType = input.GetRequestType();
            if (input.GetRequestType() == typeof(LaunchRequest))
            {
                
                string speech = "Welcome to BusTracker! What do you want to know";
                Reprompt rp = new Reprompt("Please ask for information");
                
                return ResponseBuilder.Ask(speech, rp, session);

            }
            else if (input.GetRequestType() == typeof(SessionEndedRequest))
            {
                return ResponseBuilder.Tell("Goodbye!");
            }
            else if (input.GetRequestType() == typeof(IntentRequest))
            {
                var intentRequest = (IntentRequest)input.Request;
                switch (intentRequest.Intent.Name)
                {
                    case "AMAZON.CancelIntent":
                    case "AMAZON.StopIntent":
                        return ResponseBuilder.Tell("Goodbye!");
                    case "AMAZON.HelpIntent":
                        {

                            Reprompt rp = new Reprompt("What's next?");
                            return ResponseBuilder.Ask("Here's some help. What's next?", rp, session);
                        }
                    case "GetMetropolitanAreaIntent":
                        {
                            // Make an HTTP request to the API endpoint
                            using (var client = new HttpClient())
                            {
                                var response = await client.GetAsync("https://dfru7lhdkl.execute-api.eu-central-1.amazonaws.com/Prod/api/metropolitanareas");
                                var json = await response.Content.ReadAsStringAsync();
                                var metropolitanAreas = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

                                var areaNames = metropolitanAreas.Select(m => m["name"]);
                                string content = $"The metropolitan area is {areaNames.ElementAt(0)}";
                                // Return a response to Alexa with the data from the API
                                
                                 Reprompt rp = new Reprompt(content);
                                return ResponseBuilder.Ask(content, null, session);

                            }
                           

                        }
                    default:
                        {
                            log.LogLine($"Unknown intent: " + intentRequest.Intent.Name);
                            string speech = "I didn't understand - try again?";
                            Reprompt rp = new Reprompt(speech);
                            return ResponseBuilder.Ask(speech, rp, session);
                        }
                }
            }
            return ResponseBuilder.Tell("Goodbye!");
        }

    }
}
