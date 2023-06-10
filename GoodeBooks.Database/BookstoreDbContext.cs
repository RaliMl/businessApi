using GoodeBooks.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Database
{
    public class BookstoreDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Bookshelf> Bookshelves { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<VolumeInfo> VolumeInfos { get; set; }
        public DbSet<SearchInfo> SearchInfos { get; set; }
        public DbSet<SaleInfo> SaleInfos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> dbContextOptionsBuilder) : base(dbContextOptionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<SaleInfo>(s => s.HasOne(o => o.Volume).WithOne(v => v.SaleInfo).HasForeignKey<SaleInfo>(f => f.Id));
            //modelBuilder.Entity<SearchInfo>(s => s.HasOne(o => o.Volume).WithOne(v => v.SearchInfo).HasForeignKey<SearchInfo>(f => f.Id));
            //modelBuilder.Entity<VolumeInfo>(s => s.HasOne(o => o.Volume).WithOne(v => v.VolumeInfo).HasForeignKey<VolumeInfo>(f => f.Id));
            modelBuilder.Entity<VolumeInfo>(s => s.HasMany(m => m.Authors).WithMany(m => m.VolumeInfos));
            modelBuilder.Entity<Bookshelf>(b => b.HasMany(m => m.Volumes).WithMany(m => m.Bookshelves));

            modelBuilder.Entity<Volume>()
                .HasOne(v => v.SearchInfo)
                .WithMany() // No navigation property on SearchInfo entity
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<IdentityUserLogin<string>>()
        .HasKey(login => new { login.LoginProvider, login.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>()
        .HasKey(userRole => new { userRole.UserId, userRole.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>()
        .HasKey(userToken => new { userToken.UserId, userToken.LoginProvider, userToken.Name });

            base.OnModelCreating(modelBuilder);

            //SeedRoles(modelBuilder);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            string[] roleNames = { "Admin", "Employee", "User" };

            foreach (var roleName in roleNames)
            {
                modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                });
            }
        }

    }
}
