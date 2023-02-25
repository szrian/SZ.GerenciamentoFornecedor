using SZ.GF.Business.Models;

namespace SZ.GF.Business.Interfaces
{
	public interface IProdutoService : IDisposable
	{
		Task Adicionar(Produto produto);
		Task Atualizar(Produto produto);
		Task Remover(Guid id);
	}
}
