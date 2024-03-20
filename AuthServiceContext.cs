using EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Cms;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AuthorizationService.Contexts
{
    public class AuthServiceContext : DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<FileXML> FileXMLs { get; set; }

        public AuthServiceContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
     

            optionsBuilder.LogTo(Console.WriteLine).UseMySQL
           ("Server=localhost:3306;Database=Banks;uid=root;pwd=25062002;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(u => u.Id).HasName("bankkey");
                entity.ToTable("Banks");
                entity.HasIndex(u => u.Name).IsUnique();
                entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
                entity.Property(u => u.FileXMLs).IsRequired();
             
            });

            modelBuilder.Entity<FileXML>(entity =>
            {
                entity.HasKey(p => p.Id).HasName("FileXMLkey");
                entity.ToTable("FileXML");
                entity.HasIndex(e => e.File).IsUnique();
                entity.Property(e => e.File).IsRequired().HasMaxLength(500);
                entity.Property(u => u.CreatedDate).IsRequired();
                entity.Property(u => u.ModDate).IsRequired();
                entity.HasOne(u => u.Banks).WithMany().HasForeignKey(u => u.IdBank);

            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
