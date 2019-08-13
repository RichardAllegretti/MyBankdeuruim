using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank._3_Dominio.OBJ;
using MyBank.Infraestrutura.Interface;

namespace MyBank._4_Infraestrutura
{
	public class FuncionarioDAO : IArmazenamento<Funcionario>
	{
		List<Funcionario> funcionarios = new List<Funcionario>();

		public void Atualizar(Funcionario objetoAntigo, Funcionario objetoNovo)
		{
			Funcionario funcionario = funcionarios.Find( a => a.Id == objetoAntigo.Id );
			funcionario.Nome = objetoNovo.Nome;
			funcionario.Tipo = objetoNovo.Tipo;
			funcionario.CpfCnpj = objetoNovo.CpfCnpj;
			funcionario.CEP = objetoNovo.CEP;
			funcionario.DataNascOp = objetoNovo.DataNascOp;
			funcionario.NumeroEndereco = objetoNovo.NumeroEndereco;
			funcionario.Conta = objetoNovo.Conta;
			funcionario.Agencia = objetoNovo.Agencia;
			funcionario.DataAdmissao = objetoNovo.DataAdmissao;
			funcionario.Funcao = objetoNovo.Funcao;
			funcionario.Salario = objetoNovo.Salario;
		}

		public void Cadastrar(Funcionario objeto)
		{
			funcionarios.Add(objeto);
		}

		public void Remover(Funcionario objeto)
		{
			funcionarios.Remove( objeto );
		}

		public Funcionario Selecionar(string nome)
		{
			return funcionarios.Find( a => a.Nome == nome );
		}

		public List<Funcionario> SelecionarTudo()
		{
			return funcionarios;
		}
	}
}
