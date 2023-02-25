using SZ.GF.Business.Notificacoes;

namespace SZ.GF.Business.Interfaces
{
	public interface INotificador
	{
		bool TemNotificacao();
		List<Notificacao> ObterNotificacoes();
		void Handle(Notificacao notificacao);
	}
}
