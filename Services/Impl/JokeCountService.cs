using Assigment_DadJokes.Helper;
using Assigment_DadJokes.Model.Internal.DadJokeAPI.Response;
using System.Text.Json;

namespace Assigment_DadJokes.Services.Impl
{
    public class JokeCountService : IJokeCountService
    {
        public async Task<ResDadJokeCount> getJokeCountAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage

            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(Constant.API_URL_JOKE_COUNT),
                Headers =
            {
                { Constant.API_HEADER_KEY, Constant.API_KEY_VALUE },
                { Constant.API_HEADER_HOST, Constant.API_HOST_VALUE },
            },
            };
            string resultSet = null;
            var response = new HttpResponseMessage();
            ResDadJokeCount resDadJokeCount = new ResDadJokeCount();
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
                resDadJokeCount = JsonSerializer.Deserialize<ResDadJokeCount>(resultSet);
               
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
            return resDadJokeCount;
        }
    }
}
