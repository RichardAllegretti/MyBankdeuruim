using MyBank.Dominio.objetos;

namespace MyBank.Aplicacao.Interfaces
{
	public interface IServicoConta : IServico<Conta>
	{
		Agencia SelecionarAgencia(string nome);
	}
}