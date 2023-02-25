using SZ.GF.Business.Models;

namespace SZ.GF.Business.Interfaces
{
	public interface IFornecedorRepository : IRepository<Fornecedor>, IDisposable
	{
		Task<Fornecedor> ObterFornecedorEndereco(Guid id);
		Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
	}
}
