using System.Collections.Generic;
using MyBank._2_Aplicação.Interface;
using MyBank._3_Dominio.OBJ;
using MyBank.Dominio.OBJ;
using MyBank.Infraestrutura.Interface;

namespace MyBank._2_Aplicação
{
	public class ServicoFuncionario : IServicoFuncionario
	{
		private IArmazenamento<Funcionario> _funcionario;
		private IServico<Agencia> _agencia;
		private IServico<Conta> _conta;

		public ServicoFuncionario(IArmazenamento<Funcionario> funcionario, IServico<Agencia> agencia, IServico<Conta> conta) 
		{
			_funcionario = funcionario;
			_agencia = agencia;
			_conta = conta;
		}

		public void Atualizar(Funcionario objetoAntigo, Funcionario objetoNovo)
		{
			_funcionario.Atualizar( objetoAntigo, objetoNovo );
		}

		public void Cadastrar(Funcionario objeto)
		{
			_funcionario.Cadastrar(objeto);
		}

		public void Remover(Funcionario objeto)
		{
			_funcionario.Remover(objeto);
		}

		public Funcionario Selecionar(string nome)
		{
			return _funcionario.Selecionar(nome);
		}

		public Agencia SelecionarAgencia(string nome)
		{
			return _agencia.Selecionar( nome );
		}

		public Conta SelecionarConta(string nome)
		{
			return _conta.Selecionar(nome);
		}

		public List<Funcionario> SelecionarTudo()
		{
			return _funcionario.SelecionarTudo();
		}
	}
}
