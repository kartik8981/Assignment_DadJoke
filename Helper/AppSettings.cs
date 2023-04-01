using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assigment_DadJokes.Helper
{
    public class AppSettings:PageModel
    {
        
        public string ApiKeyValue { get; set; }
        public string ApiHostValue { get; set; }
        public string ApiHeaderKey { get; set; }
        public string ApiHeaderHost { get; set; }
        public string ApiJokeCountUrl { get; set; }
        public string ApiRandomJokeUrl { get; set; }

        //public string ApiKeyValue = "API_KEY_VALUE";
        //public string ApiHostValue = "API_HOST_VALUE";
        //public string ApiHeaderKey = "API_HEADER_KEY";
        //public string ApiHeaderHost = "API_HEADER_HOST";
        //public string ApiJokeCountUrl = "API_URL_JOKE_COUNT";
        //public string ApiRandomJokeUrl = "API_URL_RANDOM_JOKE";
    }
}
