using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Dominio.OBJ;
using MyBank.Infraestrutura;
using MyBank.Infraestrutura.Interface;

namespace MyBank._2_Aplicação.Interface
{
	public class ServicoConta : IServicoConta
	{
		private IArmazenamento<Conta> _conta;
		private IServico<Agencia> _agencia;
		private IServico<Pessoa> _pessoa;

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

		public void Remover(Conta objeto)
		{
			_conta.Remover(objeto);
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
