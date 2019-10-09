using System.Collections.Generic;
using MyBank.Aplicacao.Interfaces;
using MyBank.Dominio.Interfaces;
using MyBank.Dominio.objetos;

namespace MyBank.Aplicacao
{
	public class ServicoConta : IServicoConta
	{
		private readonly IArmazenamento<Conta> _conta;
		private readonly IServico<Agencia> _agencia;
        private readonly IServico<Pessoa> _pessoa;

        public ServicoConta(IArmazenamento<Conta> conta, IServico<Agencia> agencia, IServico<Pessoa> pessoa)
		{
			_conta = conta;
			_agencia = agencia;
            _pessoa = pessoa;
        }

		public void Atualizar(Conta objetoAntigo, Conta objetoNovo)
		{
			_conta.Atualizar( objetoAntigo, objetoNovo );
		}

		public void Cadastrar(Conta objeto)
		{
			_conta.Cadastrar( objeto );
		}

		public void Remover(string nome)
		{
			_conta.Remover(nome);
		}

		public Conta Selecionar(string nome)
		{
			return _conta.Selecionar( nome );
		}

		public Agencia SelecionarAgencia(string nome)
		{
			return _agencia.Selecionar(nome);
		}

		public List<Conta> SelecionarTudo()
		{
			return _conta.SelecionarTudo();
		}
	}
}
