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
        public DbSet<CapstoneFileModel> CapstoneFiles { get; set; }
        public DbSet<GradeModel> Grades { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<ScheduleModel> Schedules { get; set; }
        public DbSet<PanelistModel> Panels { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccountModel>().ToTable("Accounts");
            modelBuilder.Entity<GroupModel>().ToTable("Groups");
            modelBuilder.Entity<MembersModel>().ToTable("Members");
            modelBuilder.Entity<FileModel>().ToTable("Files");
            modelBuilder.Entity<CapstoneFileModel>().ToTable("CapstoneFiles");
            modelBuilder.Entity<GradeModel>().ToTable("Grades");
            modelBuilder.Entity<CommentModel>().ToTable("Comments");
            modelBuilder.Entity<PanelistModel>().ToTable("Panels");
        }
    }
}
