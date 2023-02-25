using Microsoft.AspNetCore.Mvc;
using SZ.GF.Business.Interfaces;

namespace SZ.GF.Site.Controllers
{
	public class BaseController : Controller
	{
		private readonly INotificador _notificador;

		public BaseController(INotificador notificador)
		{
			_notificador = notificador;
		}

		protected bool OperacaoValida()
		{
			return !_notificador.TemNotificacao();
		}
	}
}
