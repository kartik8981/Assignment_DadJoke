using Assigment_DadJokes.Model.Internal.DadJokeAPI.Response;

namespace Assigment_DadJokes.Services
{
    public interface IJokeCountService
    {
        Task<ResDadJokeCount> getJokeCountAsync();
    }
}
