using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TodoApp.API.Models.User;

namespace TodoApp.API.Data
{
    public partial class TodoDBContext : IdentityDbContext<TodoUser>
    {
        public TodoDBContext()
        {
        }

        public TodoDBContext(DbContextOptions<TodoDBContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Todo> Todos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.TodoUserId)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Id = "0268a4f7-6947-4a3a-b257-f44c6b6eef75"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "6af8f92e-1e9c-4160-9517-562cf32524dd"
                });

            var hasher = new PasswordHasher<TodoUser>();

            modelBuilder.Entity<TodoUser>().HasData(
                new TodoUser
                {
                    Id = "6b2e4166-1722-400a-9fe1-f651ef15e852",
                    Email = "admin@Todo.com",
                    NormalizedEmail = "ADMIN@TODO.COM",
                    UserName = "admin@Todo.com",
                    NormalizedUserName = "ADMIN@TODO.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                },
                new TodoUser
                {
                    Id = "dfa78716-7bdd-4929-b15d-8617337b9f52",
                    Email = "user@Todo.com",
                    NormalizedEmail = "USER@TODO.COM",
                    UserName = "user@Todo.com",
                    NormalizedUserName = "USER@TODO.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "0268a4f7-6947-4a3a-b257-f44c6b6eef75",
                    UserId = "6b2e4166-1722-400a-9fe1-f651ef15e852"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "6af8f92e-1e9c-4160-9517-562cf32524dd",
                    UserId = "dfa78716-7bdd-4929-b15d-8617337b9f52"
                });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
