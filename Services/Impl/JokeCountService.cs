using Assigment_DadJokes.Helper;
using Assigment_DadJokes.Model.Internal.DadJokeAPI.Response;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Assigment_DadJokes.Services.Impl
{
    public class JokeCountService : IJokeCountService
    {
        private readonly AppSettings appSettings;
        public JokeCountService(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        public async Task<ResDadJokeCount> getJokeCountAsync()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage

            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(this.appSettings.ApiJokeCountUrl),
                Headers =
            {
                { this.appSettings.ApiHeaderKey, this.appSettings.ApiKeyValue },
                { this.appSettings.ApiHeaderHost, this.appSettings.ApiHostValue },
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
