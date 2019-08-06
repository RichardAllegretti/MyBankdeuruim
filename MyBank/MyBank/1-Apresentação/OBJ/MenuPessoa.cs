using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Dominio.OBJ;
using MyBank.Infraestrutura.Interface;

namespace MyBank.Apresentação.OBJ
{
	public class MenuPessoa : IMenuCadastro<Pessoa>
	{
		public void Inicio(Menu menu, IArmazenamento<Pessoa> dao)
		{
			Console.WriteLine( "Bem vindo ao menu de Agencias." );
			Console.WriteLine( "Digite a opção desejada: \n Cadastrar Conta: F1 \n Atualizar Conta: F2 \n Remover Conta: F3 \n Selecionar todas as Conta: F4 \n Voltar ao Inicio: F5" );
			var opcao = Console.ReadKey();

			switch (opcao.Key) {
				case ConsoleKey.F1:
					Cadastrar( dao );
					break;
				case ConsoleKey.F2:
					Atualizar( dao );
					break;
				case ConsoleKey.F3:
					Remover( dao );
					break;
				case ConsoleKey.F4:
					SelecionarTudo( dao );
					break;
				case ConsoleKey.F5:
					menu.Inicio();
					break;
				default:
					Console.WriteLine( "Opção Inválida." );
					break;
			}
		}

		public void Atualizar(IArmazenamento<Pessoa> dao)
		{
			Console.Clear();

			Console.WriteLine( "Atualizar Pessoa:" );

			Console.WriteLine( "Nome da Pessoa a ser atualizada:" );
			string nomePessoa = Console.ReadLine();

			Pessoa pessoaAntiga = dao.Selecionar( nomePessoa );

			Pessoa pessoaNova = new Pessoa( pessoaAntiga.Agencia, pessoaAntiga.Conta );

			pessoaNova = InformacoesPessoa( pessoaAntiga.Agencia, pessoaAntiga.Conta );

			dao.Atualizar( pessoaAntiga, pessoaNova );

			Console.WriteLine( "Conta Atualizada." );
		}

		public void Cadastrar(IArmazenamento<Pessoa> dao)
		{
			Console.Clear();

			Console.WriteLine( "Cadastro da Pessoa." );

			Pessoa pessoa = InformacoesPessoa();
	
			dao.Cadastrar( pessoa );

			Console.WriteLine( "Pessoa cadastrada." );
		}

		public void Remover(IArmazenamento<Pessoa> dao)
		{
			Console.Clear();

			Console.WriteLine( "Qual o nome da Pessoa que deseja remover:" );
			string nomePessoa = Console.ReadLine();

			Pessoa pessoa = dao.Selecionar( nomePessoa );

			dao.Remover( pessoa );

			Console.WriteLine( "Pessoa Removida." );
		}

		public void SelecionarTudo(IArmazenamento<Pessoa> dao)
		{
			Console.Clear();

			Console.WriteLine( "Listagem de todas as pessoas: \n" );

			foreach (var pessoa in dao.SelecionarTudo()) {
				Console.WriteLine( string.Format( "Nome: {0} | Tipo: {1} | CPF/CNPJ: {2} | Conta: {3} \n | Agencia: {4} \n", pessoa.Nome, pessoa.Tipo, pessoa.CpfCnpj, pessoa.Conta.Nome, pessoa.Agencia.Nome ) );
			}
		}

		private Pessoa InformacoesPessoa(Agencia agencia, Conta conta)
		{
			Pessoa pessoa = new Pessoa(agencia, conta);

			Console.WriteLine( "Nome Pessoa: " );
			pessoa.Nome = Console.ReadLine();

			Console.WriteLine( "Tipo (Fisica/Juridica): " );
			pessoa.Tipo = Console.ReadLine();

			Console.WriteLine( "Documento: " );
			pessoa.CpfCnpj = Console.ReadLine();

			Console.WriteLine( "CEP: " );
			pessoa.CEP = Console.ReadLine();

			Console.WriteLine( "Data de nascimento: " );
			pessoa.DataNascOp = Convert.ToDateTime(Console.ReadLine());

			Console.WriteLine( "Numero do Endereço: " );
			pessoa.NumeroEndereco = Convert.ToInt16(Console.ReadLine());

			pessoa.Agencia = agencia;
			pessoa.Conta = conta;

			return pessoa;
		}
	}
}
