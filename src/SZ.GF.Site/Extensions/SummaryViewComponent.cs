using Microsoft.AspNetCore.Mvc;
using SZ.GF.Business.Interfaces;

namespace SZ.GF.Site.Extensions
{
	public class SummaryViewComponent : ViewComponent
	{
		private readonly INotificador _notificador;

		public SummaryViewComponent(INotificador notificador)
		{
			_notificador = notificador;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());

			notificacoes.ForEach(p => ViewData.ModelState.AddModelError(string.Empty, p.Mensagem));

			return View();
		}
	}
}
