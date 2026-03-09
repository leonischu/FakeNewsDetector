

namespace Backend.Repository
{
    public interface INewsRepository
    {
        Task SaveAsync(NewsHistory news);

        Task<IEnumerable<NewsHistory>> GetAllAsync();
    }
}
