using Microsoft.EntityFrameworkCore;
using SZ.GF.Business.Interfaces;
using SZ.GF.Business.Models;
using SZ.GF.Data.Context;

namespace SZ.GF.Data.Repository
{
	public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
	{
		public FornecedorRepository(MeuDbContext db) : base(db)
		{
		}

		public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
		{
			return await Db.Fornecedores.AsNoTracking().Include(e => e.Endereco).FirstOrDefaultAsync(f => f.Id == id);
		}

		public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
		{
			return await Db.Fornecedores.AsNoTracking().Include(f => f.Produtos).Include(e => e.Endereco).FirstOrDefaultAsync(f => f.Id == id);
		}
	}
}
