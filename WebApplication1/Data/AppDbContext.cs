using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=NIRVANA\\SQLEXPRESS01;database=QuizAppDB; integrated security=true;TrustServerCertificate=true;")
                .EnableSensitiveDataLogging(); ;
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Exam>? Exams { get; set; }
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Option>()
                .HasOne(o => o.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(o => o.QuestionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
