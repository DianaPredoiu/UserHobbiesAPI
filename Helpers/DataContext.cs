using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        //PROPERTIES
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Hobby> Hobbies { get; set; }

        public DbSet<User_Hobby> User_Hobbies { get; set; }

    }//CLASS DataContext

}//NAMESPACE WebApi.Helpers