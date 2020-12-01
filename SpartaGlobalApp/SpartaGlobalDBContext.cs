﻿using System;
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

        public virtual DbSet<CategoriesTable> CategoriesTables { get; set; }
        public virtual DbSet<QuestionsTable> QuestionsTables { get; set; }
        public virtual DbSet<TraineeAnswersTable> TraineeAnswersTables { get; set; }
        public virtual DbSet<TraineeTable> TraineeTables { get; set; }
        public virtual DbSet<TrainerTable> TrainerTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SpartaGlobalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriesTable>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Categori__19093A2B479B5CFC");

                entity.ToTable("CategoriesTable");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CategoryID")
                    .IsFixedLength(true);

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestionsTable>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__Question__0DC06F8C0D5A11C1");

                entity.ToTable("QuestionsTable");

                entity.Property(e => e.QuestionId)
                    .ValueGeneratedNever()
                    .HasColumnName("QuestionID");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CategoryID")
                    .IsFixedLength(true);

                entity.Property(e => e.ModelAnswer)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Question)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.QuestionsTables)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Questions__Categ__4316F928");
            });

            modelBuilder.Entity<TraineeAnswersTable>(entity =>
            {
                entity.HasKey(e => e.ResponseId)
                    .HasName("PK__TraineeA__1AAA640CFA13A7E3");

                entity.ToTable("TraineeAnswersTable");

                entity.Property(e => e.ResponseId)
                    .ValueGeneratedNever()
                    .HasColumnName("ResponseID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.Response)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TraineeId).HasColumnName("TraineeID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TraineeAnswersTables)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__TraineeAn__Quest__48CFD27E");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeAnswersTables)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK__TraineeAn__Train__49C3F6B7");
            });

            modelBuilder.Entity<TraineeTable>(entity =>
            {
                entity.HasKey(e => e.TraineeId)
                    .HasName("PK__TraineeT__3BA911AAF5CE4045");

                entity.ToTable("TraineeTable");

                entity.Property(e => e.TraineeId)
                    .ValueGeneratedNever()
                    .HasColumnName("TraineeID");

                entity.Property(e => e.Course)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TraineeName)
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
                    .HasConstraintName("FK__TraineeTa__Train__45F365D3");
            });

            modelBuilder.Entity<TrainerTable>(entity =>
            {
                entity.HasKey(e => e.TrainerId)
                    .HasName("PK__TrainerT__366A1B9C416CAF63");

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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}