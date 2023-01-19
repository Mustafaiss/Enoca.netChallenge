using Enoca.netChallenge.Entities;
using Microsoft.EntityFrameworkCore;

namespace Enoca.netChallenge.Data
{
    public class DataContext:DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        //Modellerimizi temsil edecek datacontex sınıfımız
        public DbSet<Firma> Firma { get; set; }
        public DbSet<Urunler> Urunler { get; set; }
        public DbSet<Siparis> Siparis { get; set; }

    }
}
