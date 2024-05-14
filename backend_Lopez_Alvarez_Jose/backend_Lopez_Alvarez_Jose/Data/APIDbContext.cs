using Microsoft.EntityFrameworkCore;
using backend_Lopez_Alvarez_Jose.Models;

namespace backend_Lopez_Alvarez_Jose.Data
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options){ }
        public DbSet<Sede> sede {  get; set; }
    }
}
