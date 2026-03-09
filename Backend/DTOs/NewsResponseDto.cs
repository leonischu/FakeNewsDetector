namespace Backend.DTOs
{
    public class NewsResponseDto
    {
        public string Prediction {  get; set; } 

        public double Confidence { get; set; }  

        public string Explanation { get; set; } 

    }
}
