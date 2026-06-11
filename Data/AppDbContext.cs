using System.Security.Cryptography.X509Certificates;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext (DbContextOptions options): DbContext(options)
    {
       public DbSet<AppUser> Users { get; set; }
       public DbSet<Member> Members { get; set; }   
       public DbSet<Photo> Photos { get; set; }
       
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);
           
           // Configure AppUser -> Member relationship (1:1)
           modelBuilder.Entity<AppUser>()
               .HasOne(u => u.Member)
               .WithOne(m => m.User)
               .HasForeignKey<Member>(m => m.ID);
           
           // Configure Member -> Photo relationship (1:many)
           modelBuilder.Entity<Member>()
               .HasMany(m => m.Photos)
               .WithOne(p => p.Member)
               .HasForeignKey(p => p.MemberId);
       }
    }
}