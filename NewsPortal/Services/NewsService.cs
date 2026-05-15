using NewsPortal.Data;
using NewsPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace NewsPortal.Services
{
    public class NewsService
    {
        private readonly AppDbContext _context;

        public NewsService(AppDbContext context) => _context = context;

        // Получение всех новостей для главной страницы
        public async Task<List<News>> GetAllNewsAsync()
        {
            return await _context.AllNews.ToListAsync();
        }
        public async Task<News?> GetNewsByIdAsync(int id)
        {
            return await _context.AllNews.FindAsync(id);
        }

        // Метод для добавления новости
        public async Task AddNewsAsync(News news)
        {
            _context.AllNews.Add(news);
            await _context.SaveChangesAsync();
        }

        // Метод для удаления новости
        public async Task DeleteNewsAsync(int id)
        {
            var news = await _context.AllNews.FindAsync(id);
            if (news != null)
            {
                _context.AllNews.Remove(news);
                await _context.SaveChangesAsync();
            }
        }
    }
}