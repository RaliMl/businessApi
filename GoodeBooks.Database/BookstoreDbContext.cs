using GoodeBooks.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Database
{
    public class BookstoreDbContext : DbContext
    {
        public DbSet<Bookshelf> Bookshelves { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<VolumeInfo> VolumeInfos { get; set; }
        public DbSet<SearchInfo> SearchInfos { get; set; }
        public DbSet<SaleInfo> SaleInfos { get; set; }
        public DbSet<User> Users { get; set; }

        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> dbContextOptionsBuilder) : base(dbContextOptionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleInfo>(s => s.HasOne(o => o.Volume).WithOne(v => v.SaleInfo).HasForeignKey<SaleInfo>(f => f.Id));
            modelBuilder.Entity<SearchInfo>(s => s.HasOne(o => o.Volume).WithOne(v => v.SearchInfo).HasForeignKey<SearchInfo>(f => f.Id));
            modelBuilder.Entity<VolumeInfo>(s => s.HasOne(o => o.Volume).WithOne(v => v.VolumeInfo).HasForeignKey<VolumeInfo>(f => f.Id));
            //modelBuilder.Entity<VolumeInfo>(s => s.HasMany(m => m.Authors).WithMany(m => m.Volumes));
        }
    }
}
