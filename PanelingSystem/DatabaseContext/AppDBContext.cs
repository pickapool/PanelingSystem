using PanelingSystem.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace PanelingSystem.DatabaseContext
{
    public class AppDBContext : DbContext
    {
        public DbSet<UserAccountModel> Accounts { get; set; }
        public DbSet<MembersModel> Members { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccountModel>().ToTable("Accounts");
            modelBuilder.Entity<GroupModel>().ToTable("Groups");
            modelBuilder.Entity<MembersModel>().ToTable("Members");
            modelBuilder.Entity<FileModel>().ToTable("Files");
        }
    }
}
