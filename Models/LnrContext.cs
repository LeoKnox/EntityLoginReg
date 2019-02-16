using Microsoft.EntityFrameworkCore;

namespace LoginRegistration.Models
{
    public class LnrContext : DbContext
    {
        public LnrContext(DbContextOptions<LnrContext> options) : base(options) {}

        public DbSet<MyModel> MyModel {get; set;}
    }
}