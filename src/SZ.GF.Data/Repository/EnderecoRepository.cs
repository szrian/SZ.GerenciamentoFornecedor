using Microsoft.EntityFrameworkCore;
using SZ.GF.Business.Interfaces;
using SZ.GF.Business.Models;
using SZ.GF.Data.Context;

namespace SZ.GF.Data.Repository
{
	public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
	{
		public EnderecoRepository(MeuDbContext db) : base(db)
		{
		}

		public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
		{
			return await Db.Enderecos.AsNoTracking().FirstOrDefaultAsync(e => e.FornecedorId == fornecedorId);
		}
	}
}
