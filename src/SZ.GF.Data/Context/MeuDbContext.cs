using Microsoft.EntityFrameworkCore;
using SZ.GF.Business.Models;

namespace SZ.GF.Data.Context
{
	public class MeuDbContext : DbContext
	{
		public MeuDbContext(DbContextOptions options) : base(options)
		{
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			ChangeTracker.AutoDetectChangesEnabled = false;
		}

		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Fornecedor> Fornecedores { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

			base.OnModelCreating(modelBuilder);
		}
	}
}
