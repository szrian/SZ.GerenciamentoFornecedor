using Microsoft.AspNetCore.Mvc.DataAnnotations;
using SZ.GF.Business.Interfaces;
using SZ.GF.Business.Notificacoes;
using SZ.GF.Business.Services;
using SZ.GF.Data.Context;
using SZ.GF.Data.Repository;
using SZ.GF.Site.Extensions;

namespace SZ.GF.Site.Configurations
{
	public static class DependencyInjectionConfig
	{
		public static IServiceCollection ResolveDependencies(this IServiceCollection services)
		{
			services.AddScoped<MeuDbContext>();

			services.AddScoped<IProdutoRepository, ProdutoRepository>();
			services.AddScoped<IFornecedorRepository, FornecedorRepository>();
			services.AddScoped<IEnderecoRepository, EnderecoRepository>();
			services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

			services.AddScoped<INotificador, Notificador>();
			services.AddScoped<IFornecedorService, FornecedorService>();
			services.AddScoped<IProdutoService, ProdutoService>();

			return services;
		}
	}
}
