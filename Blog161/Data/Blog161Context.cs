using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog161.Models;

    public class Blog161Context : DbContext
    {
        public Blog161Context (DbContextOptions<Blog161Context> options)
            : base(options)
        {
        }

        public DbSet<Mensagem> Mensagem { get; set; }

        public DbSet<Comentario> Comentario { get; set; }

        public DbSet<Categoria> Categoria { get; set; }
    }
