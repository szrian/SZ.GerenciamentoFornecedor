using System.Linq.Expressions;
using SZ.GF.Business.Models;

namespace SZ.GF.Business.Interfaces
{
	public interface IRepository<TEntity> : IDisposable where TEntity : Entity
	{

		Task Adicionar(TEntity entity);
		Task<TEntity> ObterPorId(Guid id);
		Task<List<TEntity>> ObterTodos();
		Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
		Task Atualizar(TEntity entity);
		Task Remover(Guid id);
		Task<int> SaveChanges();
	}
}
