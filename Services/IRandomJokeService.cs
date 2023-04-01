using Assigment_DadJokes.Model.Internal.DadJokeAPI.Response;
using Assigment_DadJokes.Model.Response;

namespace Assigment_DadJokes.Services
{
    public interface IRandomJokeService
    {
        Task<ResDadJokeRandomJoke> getRandomJokeListAsync();
    }
}
