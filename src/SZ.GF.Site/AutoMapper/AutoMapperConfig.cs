using AutoMapper;
using SZ.GF.Business.Models;
using SZ.GF.Site.ViewModels;

namespace SZ.GF.Site.AutoMapper
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
			CreateMap<Produto, ProdutoViewModel>().ReverseMap();
			CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
		}
	}
}
