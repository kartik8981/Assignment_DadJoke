using Assigment_DadJokes.Model.Internal.DadJokeAPI.Response;
using Assigment_DadJokes.Model.Response;
using Assigment_DadJokes.Services;
using Assigment_DadJokes.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Assigment_DadJokes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RandomController : ControllerBase
    {
        private readonly ILogger<RandomController> logger; //To be propageted further as per requirement.
        private readonly IRandomJokeService randomJokeService;

        public RandomController(ILogger<RandomController> logger)
        {
            this.logger = logger;
            randomJokeService = new RandomJokeService();
        }

        [HttpGet]
        [Route("joke")]
        public async Task<ActionResult<RandomJoke>> getRandomJoke()
        {
            try
            {
                var data = await randomJokeService.getRandomJokeListAsync();
                RandomJoke randomJoke = new RandomJoke();
                Joke joke;
                if (data != null)
                {
                    foreach (var item in data.body)
                    {
                        joke = new Joke(item);
                        randomJoke.JokeList.Add(joke);
                        randomJoke.Error = string.Empty;
                    }
                }
                return randomJoke;
            }
            catch (Exception ex)
            {
                RandomJoke randomJoke = new RandomJoke();
                randomJoke.Error = ex.Message;
                return randomJoke
;
            }

           
        }
    }
}