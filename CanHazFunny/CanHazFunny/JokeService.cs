using System;
using System.Net.Http;
using System.Text.Json;

namespace CanHazFunny
{
    public class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            string json = HttpClient.GetStringAsync(new Uri("https://geek-jokes.sameerkumar.website/api?format=json")).Result;
            var test = JsonSerializer.Deserialize<JokeModel>(json);
            if (test != null)
            {
                return test.joke;
            }

            return "";
        }
    }
}
