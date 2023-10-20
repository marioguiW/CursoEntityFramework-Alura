
using Microsoft.EntityFrameworkCore;
using System;

namespace CursoEntityFrameworkCore___Alura;
public class LojaContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LojaDB;Trusted_Connection=true;TrustServerCertificate=true;");
    }
}
