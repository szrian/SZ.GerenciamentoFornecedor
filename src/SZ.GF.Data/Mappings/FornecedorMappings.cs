using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SZ.GF.Business.Models;

namespace SZ.GF.Data.Mappings
{
	public class FornecedorMappings : IEntityTypeConfiguration<Fornecedor>
	{
		public void Configure(EntityTypeBuilder<Fornecedor> builder)
		{
			builder.HasKey(f => f.Id);

			builder.Property(f => f.Nome)
				.IsRequired()
				.HasColumnType("varchar(200)");

			builder.Property(f => f.Documento)
				.IsRequired()
				.HasColumnType("varchar(14)");

			// 1 : 1 => Fornecedor : Endereco

			builder.HasOne(f => f.Endereco)
				.WithOne(p => p.Fornecedor);

			// 1 : N => Fornecedor : Produtos

			builder.HasMany(f => f.Produtos)
				.WithOne(p => p.Fornecedor)
				.HasForeignKey(p => p.FornecedorId);

			builder.ToTable("Fornecedores");
		}
	}
}