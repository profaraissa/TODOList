using Microsoft.EntityFrameworkCore;
using TODOList.Models;
namespace TODOList
{
    public class Context : DbContext
    {
        private readonly IConfiguration _configuration;
        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = _configuration.GetSection("ConnectionStrings").GetSection("default").Value;
            optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
