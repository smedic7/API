using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ispit.Models
{
    public partial class TodoapiContext : DbContext
    {
        public TodoapiContext()
        {
        }

        public TodoapiContext(DbContextOptions<TodoapiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TodoList> TodoLists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=HRZAGWN11723142\\SQLEXPRESS;Database=Todoapi;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoList>(entity =>
            {
                entity.ToTable("TodoList");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
