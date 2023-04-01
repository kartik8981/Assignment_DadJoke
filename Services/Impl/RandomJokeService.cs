using Assigment_DadJokes.Helper;
using Assigment_DadJokes.Model.Internal.DadJokeAPI.Response;
using Assigment_DadJokes.Model.Response;
using System.IO;
using System.Text.Json;

namespace Assigment_DadJokes.Services.Impl
{
    public class RandomJokeService : IRandomJokeService
    {
        private readonly AppSettings appSettings;
        public RandomJokeService(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }
        public async Task<ResDadJokeRandomJoke> getRandomJokeListAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(this.appSettings.ApiRandomJokeUrl),
                Headers =
            {
                { this.appSettings.ApiHeaderKey, this.appSettings.ApiKeyValue },
                { this.appSettings.ApiHeaderHost, this.appSettings.ApiHostValue },
            },
            };
            string resultSet = null;
            var response = new HttpResponseMessage();
            ResDadJokeRandomJoke resDadJokeRandom = new ResDadJokeRandomJoke();
            try
            {
                response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    resultSet = await response.Content.ReadAsStringAsync();

                }
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(response.StatusCode.ToString());
                }
                resDadJokeRandom = JsonSerializer.Deserialize<ResDadJokeRandomJoke>(resultSet);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
                request.Dispose();
                response.Dispose();
            }
            return resDadJokeRandom;
        }       
    }
}
