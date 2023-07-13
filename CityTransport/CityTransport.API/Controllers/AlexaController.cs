using Alexa.NET.Request;
using Alexa.NET.Response;
using CityTransport.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CityTransport.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlexaController : ControllerBase
    {
        private readonly IMetropolitanAreasRepository _metropolitanAreaRepo;

        public AlexaController(IMetropolitanAreasRepository metropolitanAreaRepo)
        {
            _metropolitanAreaRepo = metropolitanAreaRepo;
        }

        [HttpPost, Route("/process")]
        public async Task<SkillResponse> ProcessAsync(SkillRequest input)
        {
            SkillResponse output= new SkillResponse();
            output.Version = "1.0";
            output.Response = new ResponseBody();
            var areas = await _metropolitanAreaRepo.GetMetropolitanAreasAsync();
            var list = JsonConvert.SerializeObject(areas);
            output.Response.OutputSpeech = new PlainTextOutputSpeech($" metropolitan arrea {list}");
            return output;
        }
    }
}
