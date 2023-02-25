using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using SZ.GF.Business.Interfaces;
using SZ.GF.Business.Models;
using SZ.GF.Data.Context;

namespace SZ.GF.Data.Repository
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
	{
		protected readonly MeuDbContext Db;
		protected readonly DbSet<TEntity> DbSet;

		public Repository(MeuDbContext db)
		{
			Db = db;
			DbSet = db.Set<TEntity>();
		}

		public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
		{
			return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
		}

		public async Task<TEntity> ObterPorId(Guid id)
		{
			return await DbSet.FindAsync(id);
		}

		public async Task<List<TEntity>> ObterTodos()
		{
			return await DbSet.ToListAsync();
		}

		public async Task Adicionar(TEntity entity)
		{
			DbSet.Add(entity);
			await SaveChanges();
		}

		public async Task Atualizar(TEntity entity)
		{
			DbSet.Update(entity);
			await SaveChanges();
		}

		public async Task Remover(Guid id)
		{
			var obj = new TEntity { Id = id };
			DbSet.Remove(obj);

			await SaveChanges();
		}

		public async Task<int> SaveChanges()
		{
			return await Db.SaveChangesAsync();
		}

		public void Dispose()
		{
			Db?.Dispose();
		}
	}
}
