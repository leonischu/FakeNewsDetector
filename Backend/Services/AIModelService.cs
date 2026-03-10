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
            var apiUrl = "https://router.huggingface.co/hf-inference/models/mrm8488/bert-tiny-finetuned-fake-news-detection";

            var token = _config["HuggingFace:Token"];

            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);

            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            request.Content = new StringContent(
                JsonConvert.SerializeObject(new { inputs = text }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"AI API Error: {json}");

            var data = JArray.Parse(json);

            var label = data[0][0]["label"].ToString();
            var score = (double)data[0][0]["score"];

            return (label, score);
        }
    }
}