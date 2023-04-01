using Assigment_DadJokes.Model.Response;
using Assigment_DadJokes.Services;
using Assigment_DadJokes.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Assigment_DadJokes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JokeController : Controller
    {
        private readonly ILogger<JokeController> logger; //To be propageted further as per requirement.
        private readonly IJokeCountService jokeCountService;

        public JokeController(ILogger<JokeController> logger)
        {
            this.logger = logger;
            jokeCountService = new JokeCountService();
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
