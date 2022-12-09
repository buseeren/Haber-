using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace App.Models.Models
{
    public partial class NewsDBContext : DbContext
    {
        public NewsDBContext()
        {
        }

        public NewsDBContext(DbContextOptions<NewsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=NewsDB;Integrated Security=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsId).HasColumnName("NewsID");

                entity.Property(e => e.NewsCreateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Writer>(entity =>
            {
                entity.ToTable("Writer");

                entity.Property(e => e.WriterId).HasColumnName("WriterID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
