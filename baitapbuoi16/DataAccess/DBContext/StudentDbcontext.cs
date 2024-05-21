using baitapbuoi16.Models;
using Microsoft.EntityFrameworkCore;

namespace baitapbuoi16.DataAccess.DBContext
{
    public class StudentDbcontext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-PBSFM7Q;Initial Catalog=Baitapbuoi16;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True");
        }
        public DbSet<Student>students { get; set; }
    }
}
