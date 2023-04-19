using Microsoft.EntityFrameworkCore;
using MuffinCrud.Models;

namespace MuffinCrud.DataAccess
{
    public class MuffinDbContext : DbContext
    {
        public DbSet<Muffin> Muffins { get; set; }
        public MuffinDbContext(DbContextOptions<MuffinDbContext> options) : base(options)
        {

        }
    }
}
