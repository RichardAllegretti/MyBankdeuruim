using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank._2_Aplicação.Interface;
using MyBank.Dominio.OBJ;
using MyBank.Infraestrutura;
using MyBank.Infraestrutura.Interface;

namespace MyBank._2_Aplicação
{
	public class ServicoPessoa : IServicoPessoa
	{
		private IArmazenamento<Pessoa> _pessoa;
		private IServico<Agencia> _agencia;
		private IServico<Conta> _conta;

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

		public void Cadastrar(Pessoa objeto)
		{
			_pessoa.Cadastrar(objeto);
		}

		public void Remover(Pessoa objeto)
		{
			_pessoa.Remover(objeto);
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
