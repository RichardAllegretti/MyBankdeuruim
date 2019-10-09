using System;
using System.Collections.Generic;
using MyBank.Aplicacao.Interfaces;
using MyBank.Dominio.Interfaces;
using MyBank.Dominio.objetos;

namespace MyBank.Aplicacao
{
	public class ServicoPessoa : IServicoPessoa
	{
		private readonly IArmazenamento<Pessoa> _pessoa;
		private readonly IServico<Agencia> _agencia;
		private readonly IServico<Conta> _conta;

		public ServicoPessoa(IArmazenamento<Pessoa> pessoa, IServico<Agencia> agencia, IServico<Conta> conta)
		{
			_pessoa = pessoa;
			_agencia = agencia;
			_conta = conta;
		}

		public void Atualizar(Pessoa objetoAntigo, Pessoa objetoNovo)
		{
			_pessoa.Atualizar(objetoAntigo, objetoNovo);
		}

        public void Remover(string nome)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Pessoa objeto)
		{
			_pessoa.Cadastrar(objeto);
		}

		public void Remover(Pessoa objeto)
		{
			_pessoa.Remover("teste");
		}

		public Pessoa Selecionar(string nome)
		{
			return _pessoa.Selecionar( nome );
		}

		public Agencia SelecionarAgencia(string nome)
		{
			return _agencia.Selecionar( nome );
		}

		public Conta SelecionarConta(string nome)
		{
			return _conta.Selecionar( nome );
		}

		public List<Pessoa> SelecionarTudo()
		{
			return _pessoa.SelecionarTudo();
		}
	}
}
