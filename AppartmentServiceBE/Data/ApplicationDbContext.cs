using AppartmentServiceBE.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AppartmentServiceBE.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<flatDetails> ApartMentDetails { get; set; }
        public DbSet<UserDetails> UserTable { get; set; }
        public DbSet<complexDetails>ComplexDetails{ get; set; }
    }
}
