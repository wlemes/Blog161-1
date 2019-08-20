using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogWendel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class BlogWendelContext : IdentityDbContext<User>
{
    public BlogWendelContext(DbContextOptions<BlogWendelContext> options)
        : base(options)
    {
    }

    public DbSet<User> BlogUsers { get; set; }

    public DbSet<BlogWendel.Models.Mensagem> Mensagem { get; set; }

    public DbSet<BlogWendel.Models.Comentario> Comentario { get; set; }

    public DbSet<BlogWendel.Models.Categoria> Categoria { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
