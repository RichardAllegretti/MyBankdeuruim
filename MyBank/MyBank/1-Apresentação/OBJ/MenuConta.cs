using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank._1_Apresentação.Interface;
using MyBank._2_Aplicação.Interface;
using MyBank.Dominio.OBJ;
using MyBank.Infraestrutura.Interface;

namespace MyBank.Apresentação.OBJ
{
	public class MenuConta : IMenuConta<Conta>
	{
		private IServicoConta _conta;

		public MenuConta(IServicoConta serv)
		{
			_conta = serv;
		}

		public void Inicio(Menu menu)
		{
			Console.Clear();

			Console.WriteLine( "Bem vindo ao menu de Agencias." );
			Console.WriteLine( "Digite a opção desejada: \n Cadastrar Conta: F1 \n Atualizar Conta: F2 \n Remover Conta: F3 \n Selecionar todas as Conta: F4 \n Voltar ao Inicio: F5" );
			var opcao = Console.ReadKey();

			switch (opcao.Key) {
				case ConsoleKey.F1:
					Cadastrar();
					break;
				case ConsoleKey.F2:
					Atualizar();
					break;
				case ConsoleKey.F3:
					Remover();
					break;
				case ConsoleKey.F4:
					SelecionarTudo();
					break;
				case ConsoleKey.F5:
					menu.Inicio();
					break;
				default:
					Console.WriteLine( "Opção Inválida." );
					break;
			}

			menu.Inicio();
		}
		
		public void Cadastrar()
		{
			Console.Clear();

			Console.WriteLine( "Cadastro da Conta." );

			Console.WriteLine( "Digite o nome da agencia a ser vinculada." );
			string nomeAgencia = Console.ReadLine(); ;

			Conta conta = InformacoesConta( _conta.SelecionarAgencia( nomeAgencia ) );

			_conta.Cadastrar( conta );

			Console.WriteLine( "Conta cadastrada." );

			Console.ReadLine();
		}

		public void Atualizar()
		{
			Console.Clear();

			Console.WriteLine( "Atualizar Conta:" );

			Console.WriteLine( "Nome da Conta a ser atualizada:" );
			string nomeConta = Console.ReadLine();

			Conta contaAntiga = _conta.Selecionar( nomeConta );

			Conta contaNova = new Conta( contaAntiga.Agencia );

			contaNova = InformacoesConta( contaAntiga.Agencia );

			_conta.Atualizar( contaAntiga, contaNova );

			Console.WriteLine( "Conta Atualizada." );

			Console.ReadLine();
		}

		public void Remover()
		{
			Console.Clear();

			Console.WriteLine( "Qual o nome da conta que deseja remover:" );
			string nomeConta = Console.ReadLine();

			Conta conta = _conta.Selecionar( nomeConta );

			_conta.Remover( conta );

			Console.WriteLine( "Conta Removida." );

			Console.ReadLine();
		}

		public void SelecionarTudo()
		{
			Console.Clear();

			Console.WriteLine( "Listagem de todas as contas: \n" );

			foreach (var conta in _conta.SelecionarTudo()) {
				Console.WriteLine( string.Format( "Nome: {0} | Data de Abertura: {1} | Saldo: {2} | Nome do Cliente: {3} \n", conta.Nome, conta.DataAbertura, conta.Saldo, conta.Pessoa.Nome ) );
			}

			Console.ReadLine();
		}

		private Conta InformacoesConta(Agencia agencia)
		{
			Conta conta = new Conta( agencia );

			Console.WriteLine( "Nome da conta: " );
			conta.Nome = Console.ReadLine();
			conta.DataAbertura = DateTime.Now;
			conta.Agencia = agencia;

			return conta;
		}
	}
}
