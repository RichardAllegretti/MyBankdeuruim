using System;
using MyBank.Aplicacao.Interfaces;
using MyBank.Apresentacao.Console.Interfaces;
using MyBank.Apresentação.OBJ;
using MyBank.Dominio.objetos;

namespace MyBank.Apresentacao.Console.objetos
{
	public class MenuConta : IMenuConta<Conta>
	{
		private readonly IServicoConta _conta;

		public MenuConta(IServicoConta serv)
		{
			_conta = serv;
		}

		public void Inicio(Menu menu)
		{
			System.Console.Clear();

			System.Console.WriteLine( "Bem vindo ao menu de Agencias." );
			System.Console.WriteLine( "Digite a opção desejada: \n Cadastrar Conta: F1 \n Atualizar Conta: F2 \n Remover Conta: F3 \n Selecionar todas as Conta: F4 \n Voltar ao Inicio: F5" );
			var opcao = System.Console.ReadKey();

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
					System.Console.WriteLine( "Opção Inválida." );
					break;
			}

			menu.Inicio();
		}
		
		public void Cadastrar()
		{
			System.Console.Clear();

			System.Console.WriteLine( "Cadastro da Conta." );

			System.Console.WriteLine( "Digite o nome da agencia a ser vinculada." );
			string nomeAgencia = System.Console.ReadLine(); ;

			Conta conta = InformacoesConta( _conta.SelecionarAgencia( nomeAgencia ) );

			_conta.Cadastrar( conta );

			System.Console.WriteLine( "Conta cadastrada." );

			System.Console.ReadLine();
		}

		public void Atualizar()
		{
			System.Console.Clear();

			System.Console.WriteLine( "Atualizar Conta:" );

			System.Console.WriteLine( "Nome da Conta a ser atualizada:" );
			string nomeConta = System.Console.ReadLine();

			Conta contaAntiga = _conta.Selecionar( nomeConta );

			Conta contaNova = new Conta( contaAntiga.Agencia );

			contaNova = InformacoesConta( contaAntiga.Agencia );

			_conta.Atualizar( contaAntiga, contaNova );

			System.Console.WriteLine( "Conta Atualizada." );

			System.Console.ReadLine();
		}

		public void Remover()
		{
			System.Console.Clear();

			System.Console.WriteLine( "Qual o id da conta que deseja remover:" );
			string idConta = System.Console.ReadLine();

			_conta.Remover(idConta);

			System.Console.WriteLine( "Conta Removida." );

			System.Console.ReadLine();
		}

		public void SelecionarTudo()
		{
			System.Console.Clear();

			System.Console.WriteLine( "Listagem de todas as contas: \n" );

			foreach (var conta in _conta.SelecionarTudo()) {
				System.Console.WriteLine( string.Format( "Nome: {0} | Data de Abertura: {1} | Saldo: {2} | Nome do Cliente: {3} \n", conta.Nome, conta.DataAbertura, conta.Saldo, conta.Pessoa.Nome ) );
			}

			System.Console.ReadLine();
		}

		private Conta InformacoesConta(Agencia agencia)
		{
			Conta conta = new Conta( agencia );

			System.Console.WriteLine( "Nome da conta: " );
			conta.Nome = System.Console.ReadLine();
			conta.DataAbertura = DateTime.Now;
			conta.Agencia = agencia;

			return conta;
		}
	}
}
