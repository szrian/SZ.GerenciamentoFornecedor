using SZ.GF.Business.Models;

namespace SZ.GF.Business.Interfaces
{
	public interface IEnderecoRepository : IRepository<Endereco>
	{
		Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
	}
}
