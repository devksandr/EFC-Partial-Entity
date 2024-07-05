using EFC_Partial_Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC_Partial_Entity.Database
{
    public class DataContextFull : DbContext
    {
        public DbSet<PersonFull> People { get; set; } = null!;

        public DataContextFull(DbContextOptions<DataContextFull> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
