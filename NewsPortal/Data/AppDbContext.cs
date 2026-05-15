using Microsoft.EntityFrameworkCore;
using NewsPortal.Models;

namespace NewsPortal.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<News> AllNews { get; set; }
}
