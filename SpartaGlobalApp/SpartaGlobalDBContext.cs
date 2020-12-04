using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SpartaGlobalAppModel
{
    public partial class SpartaGlobalDBContext : DbContext
    {
        public SpartaGlobalDBContext()
        {
        }

        public SpartaGlobalDBContext(DbContextOptions<SpartaGlobalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<QuestionsTable> QuestionsTables { get; set; }
        public virtual DbSet<TraineeAnswersTable> TraineeAnswersTables { get; set; }
        public virtual DbSet<TraineeTable> TraineeTables { get; set; }
        public virtual DbSet<TrainerTable> TrainerTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SpartaGlobalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionsTable>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__Question__0DC06F8CBCC56CEE");

                entity.ToTable("QuestionsTable");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Question)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TrainerId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TrainerID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.QuestionsTables)
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK__Questions__Categ__22751F6C");
            });

            modelBuilder.Entity<TraineeAnswersTable>(entity =>
            {
                entity.HasKey(e => e.ResponseId)
                    .HasName("PK__TraineeA__1AAA640C2B25CF15");

                entity.ToTable("TraineeAnswersTable");

                entity.Property(e => e.ResponseId).HasColumnName("ResponseID");

                entity.Property(e => e.Feedback)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.Response)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TraineeId).HasColumnName("TraineeID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TraineeAnswersTables)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__TraineeAn__Quest__282DF8C2");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeAnswersTables)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK__TraineeAn__Train__29221CFB");
            });

            modelBuilder.Entity<TraineeTable>(entity =>
            {
                entity.HasKey(e => e.TraineeId)
                    .HasName("PK__TraineeT__3BA911AA78B47E1D");

                entity.ToTable("TraineeTable");

                entity.Property(e => e.TraineeId).HasColumnName("TraineeID");

                entity.Property(e => e.Course)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TraineeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TraineePassword)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TraineeUsername)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TrainerId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TrainerID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TraineeTables)
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK__TraineeTa__Train__25518C17");
            });

            modelBuilder.Entity<TrainerTable>(entity =>
            {
                entity.HasKey(e => e.TrainerId)
                    .HasName("PK__TrainerT__366A1B9C46727FAF");

                entity.ToTable("TrainerTable");

                entity.Property(e => e.TrainerId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TrainerID")
                    .IsFixedLength(true);

                entity.Property(e => e.Course)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TrainerName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TrainerPassword)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TrainerUsername)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
