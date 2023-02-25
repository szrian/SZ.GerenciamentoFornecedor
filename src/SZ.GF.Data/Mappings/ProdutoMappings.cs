using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SZ.GF.Business.Models;

namespace SZ.GF.Data.Mappings
{
	public class ProdutoMappings : IEntityTypeConfiguration<Produto>
	{
		public void Configure(EntityTypeBuilder<Produto> builder)
		{
			builder.HasKey(p => p.Id);

			builder.Property(p => p.Nome)
				.IsRequired()
				.HasColumnType("varchar(200)");

			builder.Property(p => p.Descricao)
				.IsRequired()
				.HasColumnType("varchar(1000)");

			builder.Property(p => p.Imagem)
				.IsRequired()
				.HasColumnType("varchar(100)");

			builder.ToTable("Produtos");
		}
	}
}