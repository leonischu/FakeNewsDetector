using AutoMapper;
using Backend.DTOs;
using Backend.Repository;
using Backend.Services;

public class FakeNewsService : IFakeNewsService
{
    private readonly AIModelService _ai;
    private readonly INewsRepository _repo;
    private readonly IMapper _mapper;

    public FakeNewsService(
        AIModelService ai,
        INewsRepository repo,
        IMapper mapper)
    {
        _ai = ai;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<NewsResponseDto> AnalyzeAsync(string text)
    {
        var result = await _ai.Predict(text);

        var history = new NewsHistory
        {
            ArticleText = text,
            Prediction = result.prediction,
            Confidence = result.confidence,
            Explanation = "Prediction generated using NLP model"
        };

        await _repo.SaveAsync(history);

        var response = _mapper.Map<NewsResponseDto>(history);

        return response;
    }
}