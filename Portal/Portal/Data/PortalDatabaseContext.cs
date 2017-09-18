using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Portal.Data
{
    public partial class PortalDatabaseContext : DbContext
    {

        public PortalDatabaseContext(DbContextOptions<PortalDatabaseContext> options) : base(options)
        {

        }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<MenuItems> MenuItems { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<PostProject> PostProject { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<ProjectCategoreis> ProjectCategoreis { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<StaffAwesome> StaffAwesome { get; set; }
        public virtual DbSet<SystemConfig> SystemConfig { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PortalDatabase;User ID=Chang.otvina;pwd=secret;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Alias).HasMaxLength(200);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ImageIcon).HasMaxLength(200);

                entity.Property(e => e.MetaDescription).HasColumnType("nchar(10)");

                entity.Property(e => e.MetaKeyword).HasMaxLength(200);

                entity.Property(e => e.MetaTitle).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MenuItems>(entity =>
            {
                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.DataJson).HasColumnType("text");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Type).HasMaxLength(200);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MenuItems_Menus");
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Pages>(entity =>
            {
                entity.Property(e => e.Alias).HasMaxLength(200);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(100);

                entity.Property(e => e.Descaption).HasColumnType("nchar(500)");

                entity.Property(e => e.MetaKeyword).HasMaxLength(500);

                entity.Property(e => e.MetaTitle).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(100);
            });

            modelBuilder.Entity<PostProject>(entity =>
            {
                entity.Property(e => e.Alias).HasMaxLength(200);

                entity.Property(e => e.CreadeBy).HasMaxLength(100);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Descaption).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.MetaKeyword).HasMaxLength(500);

                entity.Property(e => e.MoreImage).HasColumnType("xml");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(100);

                entity.HasOne(d => d.ProjectCategory)
                    .WithMany(p => p.PostProject)
                    .HasForeignKey(d => d.ProjectCategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PostProject_ProjectCategoreis");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.PostProject)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PostProject_Review");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.Alias).HasMaxLength(256);

                entity.Property(e => e.BodyContent).HasColumnType("text");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(100);

                entity.Property(e => e.Descaption).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Posts_Categories");
            });

            modelBuilder.Entity<ProjectCategoreis>(entity =>
            {
                entity.Property(e => e.Alias).HasMaxLength(200);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Descaption).HasMaxLength(500);

                entity.Property(e => e.ImageIcon).HasMaxLength(200);

                entity.Property(e => e.MetaKeyword).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Content).HasColumnType("text");
            });

            modelBuilder.Entity<StaffAwesome>(entity =>
            {
                entity.Property(e => e.Descaption).HasMaxLength(500);

                entity.Property(e => e.Facebook).HasMaxLength(200);

                entity.Property(e => e.GooglePlus).HasMaxLength(200);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Twitter).HasMaxLength(200);
            });

            modelBuilder.Entity<SystemConfig>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            });
        }
    }
}
