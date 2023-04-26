using System;
using System.Collections.Generic;
using BookAppBlazor.Shared;
using Microsoft.EntityFrameworkCore;

namespace BookAppBlazor.Server.Models;

public partial class BookDbContext : DbContext
{
    public BookDbContext()
    {
    }

    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("defaultConnection"));

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.IdBook).HasName("PK__Books__A4CEA0759B7DA0F2");

            entity.Property(e => e.IdBook).HasColumnName("id_Book");
            entity.Property(e => e.Author)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("author");
            entity.Property(e => e.Editorial)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("editorial");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.PublishDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("publish_date");
            entity.Property(e => e.Title)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
