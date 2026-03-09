using Newtonsoft.Json;
using System.Text;

namespace Backend.Services
{
    public class AIModelService
    {
        private readonly HttpClient _http;

        public AIModelService(HttpClient http)
        {
            _http = http;
        }

        public async Task<(string prediction, double confidence)> Predict(string text)
        {
            var apiUrl = "https://api-inference.huggingface.co/models/roberta-base-openai-detector";

            var requestBody = new
            {
                inputs = text
            };

            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);

            request.Headers.Add("Authorization", "Bearer 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");

            request.Content = new StringContent(
                JsonConvert.SerializeObject(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();

            // Debug if API fails
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"AI API Error: {json}");
            }

            dynamic data = JsonConvert.DeserializeObject(json);

            string label = data[0].label;
            double score = data[0].score;

            return (label, score);
        }
    }
}