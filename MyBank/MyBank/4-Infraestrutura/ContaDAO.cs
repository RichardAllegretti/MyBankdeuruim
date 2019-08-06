using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Dominio.OBJ;
using MyBank.Infraestrutura.Interface;

namespace MyBank.Infraestrutura
{
	public class ContaDAO : IArmazenamento<Conta>
	{
		List<Conta> contas = new List<Conta>();

		public void Atualizar(Conta objetoAntigo, Conta objetoNovo)
		{
			Conta conta = contas.Find( a => a.Id == objetoAntigo.Id );
			conta.Nome = objetoNovo.Nome;
			conta.Pessoa = objetoNovo.Pessoa;
			conta.DataAbertura = objetoNovo.DataAbertura;
			conta.Agencia = objetoNovo.Agencia;
		}

		public void Cadastrar(Conta objeto)
		{
			contas.Add( objeto );
		}

		public void Remover(Conta objeto)
		{
			contas.Remove( objeto );
		}

		public Conta Selecionar(string nome)
		{
			return contas.Find( a => a.Nome == nome );
		}

		public List<Conta> SelecionarTudo()
		{
			return contas;
		}
	}
}
