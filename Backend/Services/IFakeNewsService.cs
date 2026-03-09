using Backend.DTOs;

namespace Backend.Services
{
    public interface IFakeNewsService
    {
        Task<NewsResponseDto> AnalyzeAsync(string text);

    }
}
