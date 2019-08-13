using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank._3_Dominio.OBJ;
using MyBank._4_Infraestrutura.Interface;
using MyBank.Infraestrutura.Interface;

namespace MyBank.Infraestrutura
{
	public class PessoaDAO : IArmazenamento<Pessoa>
	{
		List<Pessoa> pessoas = new List<Pessoa>();

		public void Atualizar(Pessoa objetoAntigo, Pessoa objetoNovo)
		{
			Pessoa pessoa = pessoas.Find( a => a.Id == objetoAntigo.Id );
			pessoa.Nome = objetoNovo.Nome;
			pessoa.Tipo = objetoNovo.Tipo;
			pessoa.CpfCnpj = objetoNovo.CpfCnpj;
			pessoa.CEP = objetoNovo.CEP;
			pessoa.DataNascOp = objetoNovo.DataNascOp;
			pessoa.NumeroEndereco = objetoNovo.NumeroEndereco;
			pessoa.Conta = objetoNovo.Conta;
			pessoa.Agencia = objetoNovo.Agencia;
		}

		public void Cadastrar(Pessoa objeto)
		{
			pessoas.Add( objeto );
		}

		public void Remover(Pessoa objeto)
		{
			pessoas.Remove( objeto );
		}

		public Pessoa Selecionar(string nome)
		{
			return pessoas.Find( a => a.Nome == nome );
		}

		public List<Pessoa> SelecionarTudo()
		{
			return pessoas;
		}
	}
}
