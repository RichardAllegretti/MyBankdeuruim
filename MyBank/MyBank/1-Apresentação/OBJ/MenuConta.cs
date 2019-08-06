using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Dominio.OBJ;
using MyBank.Infraestrutura.Interface;

namespace MyBank.Apresentação.OBJ
{
	public class MenuConta : IMenuCadastro<Conta>
	{
		public void Inicio(Menu menu, IArmazenamento<Conta> dao)
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

		private Conta InformacoesConta(Agencia agencia)
		{
			Conta conta = new Conta(agencia);

			Console.WriteLine( "Nome da conta: " );
			conta.Nome = Console.ReadLine();
			conta.DataAbertura = DateTime.Now;
			conta.Agencia = agencia;

			//tela pessoa

			return conta;
		}

		public void Cadastrar(IArmazenamento<Conta> dao)
		{
			Console.Clear();

			Console.WriteLine( "Cadastro da Conta." );

			Conta conta = InformacoesConta();

			dao.Cadastrar( conta );

			Console.WriteLine( "Conta cadastrada." );
		}

		public void Atualizar(IArmazenamento<Conta> dao)
		{
			Console.Clear();

			Console.WriteLine( "Atualizar Conta:" );

			Console.WriteLine( "Nome da Conta a ser atualizada:" );
			string nomeConta = Console.ReadLine();

			Conta contaAntiga = dao.Selecionar( nomeConta );

			Conta contaNova = new Conta( contaAntiga.Agencia );

			contaNova = InformacoesConta( contaAntiga.Agencia );

			dao.Atualizar( contaAntiga, contaNova );

			Console.WriteLine( "Conta Atualizada." );
		}

		public void Remover(IArmazenamento<Conta> dao)
		{
			Console.Clear();

			Console.WriteLine( "Qual o nome da conta que deseja remover:" );
			string nomeConta = Console.ReadLine();

			Conta conta = dao.Selecionar( nomeConta );

			dao.Remover( conta );

			Console.WriteLine( "Conta Removida." );
		}

		public void SelecionarTudo(IArmazenamento<Conta> dao)
		{
			Console.Clear();

			Console.WriteLine( "Listagem de todas as contas: \n" );

			foreach (var conta in dao.SelecionarTudo()) {
				Console.WriteLine( string.Format( "Nome: {0} | Data de Abertura: {1} | Saldo: {2} | Nome do Cliente: {3} \n", conta.Nome, conta.DataAbertura, conta.Saldo, conta.Pessoa.Nome ) );
			}
		}
	}
}
