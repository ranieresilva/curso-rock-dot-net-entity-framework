﻿using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CpmPedidos.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CategoriaProduto> CategoriasProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PromocaoProduto> PromocoesProdutos { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}