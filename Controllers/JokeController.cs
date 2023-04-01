using Assigment_DadJokes.Helper;
using Assigment_DadJokes.Model.Response;
using Assigment_DadJokes.Services;
using Assigment_DadJokes.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Assigment_DadJokes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JokeController : Controller
    {
        private readonly ILogger<JokeController> logger; //To be propageted further as per requirement.
        private readonly IJokeCountService jokeCountService;
        private readonly AppSettings appSettings;

        public JokeController(ILogger<JokeController> logger, IOptions<AppSettings> options)
        {
            this.logger = logger;
            appSettings = options.Value;
            jokeCountService = new JokeCountService(appSettings);
        }
        [HttpGet]
        [Route("count")]
        public async Task<ActionResult<JokeCount>> getJokeCount()
        {
            try
            {
                var data = await jokeCountService.getJokeCountAsync();
                JokeCount jokeCount = new JokeCount();
                if (data != null)
                {
                    jokeCount.Success = data.success;
                    jokeCount.Count = data.body;
                    jokeCount.Error = string.Empty;
                }

                return jokeCount;
            }catch (Exception ex)
            {
                JokeCount jokeCount = new JokeCount();
                jokeCount.Error = ex.Message;
                jokeCount.Success = false;
                return jokeCount
;            }
            
        }
    }
}
