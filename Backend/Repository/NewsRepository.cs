using Dapper;                      
using Backend.Models;
using System.Data;
using Backend.Data;

namespace Backend.Repository
{
    public class NewsRepository:INewsRepository
    {
        private readonly DapperContext _context;
        public NewsRepository( DapperContext context )
        {
            _context = context;
        }
        public async Task SaveAsync(NewsHistory news)
        {
            var sql = @"INSERT INTO NewsHistory (ArticleText, Prediction, Confidence , Explanation) 
                        VALUES 
                        (@ArticleText,@Prediction,@Confidence,@Explanation)";
            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(sql, news);

        }
        public async Task<IEnumerable<NewsHistory>> GetAllAsync()
        {
            var sql = "SELECT * FROM NewsHistory ORDER BY CreatedDate DESC";

            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<NewsHistory>(sql);
        }


    }
}
