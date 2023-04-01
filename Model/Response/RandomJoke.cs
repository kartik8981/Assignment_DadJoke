using static Assigment_DadJokes.Model.Internal.DadJokeAPI.Response.ResDadJokeRandomJoke;

namespace Assigment_DadJokes.Model.Response
{
    public class RandomJoke
    { 
        List<Joke> jokeList;
        public List<Joke> JokeList { get { return jokeList; } set { jokeList = value; }  }
        public string Error { get; set; }
        public RandomJoke()
        {
            jokeList = new List<Joke>();
           
        }

    }
    public class Joke
    {
        public string id { get; set; }
        public string Setup { get; set; }
        public string PunchLine { get; set; }
        public string type { get; set; }
        public Joke(Body body)
        {
            id = body._id;
            Setup = body.setup;
            PunchLine = body.punchline;
            type = body.type;
        }
        
    }
    
}
