using ArticleApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArticleApi.Persistence
{
    public class ArticleApiDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<Author> Authors { get; set; }

        public ArticleApiDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
