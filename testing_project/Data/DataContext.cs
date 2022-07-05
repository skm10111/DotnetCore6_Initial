using Microsoft.EntityFrameworkCore;
using testing_project.Enitity;

namespace testing_project.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserEntity> User { get; set; } 
    }
}
