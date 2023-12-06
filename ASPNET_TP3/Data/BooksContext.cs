using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPNET_TP3.Models;

namespace ASPNET_TP3.Data
{
    public class BooksContext : DbContext
    {
        public BooksContext (DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public DbSet<ASPNET_TP3.Models.Autor> Autor { get; set; } = default!;
        public DbSet<ASPNET_TP3.Models.Genero>? Genero { get; set; }
        public DbSet<ASPNET_TP3.Models.Livro>? Livro { get; set; }
    }
}
