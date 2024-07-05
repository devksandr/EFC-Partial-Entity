using EFC_Partial_Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC_Partial_Entity.Database
{
    public class DataContextPartial : DbContext
    {
        public DbSet<PersonPartial> People { get; set; } = null!;

        public DataContextPartial(DbContextOptions<DataContextPartial> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
