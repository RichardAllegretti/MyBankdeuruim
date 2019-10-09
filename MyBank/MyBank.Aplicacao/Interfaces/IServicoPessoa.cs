using MyBank.Dominio.objetos;

namespace MyBank.Aplicacao.Interfaces
{
	public interface IServicoPessoa : IServico<Pessoa>
	{
		Agencia SelecionarAgencia(string nome);
		Conta SelecionarConta(string nome);
	}
}
