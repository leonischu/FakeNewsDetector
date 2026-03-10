using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Backend.Services
{
    public class AIModelService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public AIModelService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
        }

        public async Task<(string prediction, double confidence)> Predict(string text)
        {
            var apiUrl = "https://router.huggingface.co/hf-inference/models/jy46604790/Fake-News-Bert-Detect";

            var token = _config["HuggingFace:Token"];

            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);

            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
          
            //This converts your text into JSON.
            
            request.Content = new StringContent(
                JsonConvert.SerializeObject(new { inputs = text }),
                Encoding.UTF8,
                "application/json"
            );

            //This sends the request to Hugging Face servers.
            var response = await _http.SendAsync(request);

            //Reading the response
            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine("RAW RESPONSE: " + json);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"AI API Error: {json}");

            var data = JArray.Parse(json);  //This converts JSON into a JArray object.
            var results = data[0] as JArray;


            //Extracting the result
            // Find the label with the HIGHEST score
            var best = results!
                .OrderByDescending(x => (double)x["score"]!)
                .First();

            var label = best["label"]!.ToString();
            var score = (double)best["score"]!;

            return (label, score);
        }
    }
}