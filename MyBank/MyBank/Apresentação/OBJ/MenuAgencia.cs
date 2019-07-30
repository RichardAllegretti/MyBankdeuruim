using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Dominio.OBJ;

namespace MyBank.Apresentação.OBJ
{
	public class MenuAgencia : Menu
	{
		List<Agencia> agencias = new List<Agencia>();

		public void Menu(Menu menu)
		{
			Console.WriteLine( "Bem vindo ao menu de Agencias." );
			Console.WriteLine( "Digite a opção desejada: \n Cadastrar Agencia: F1 \n Atualizar Agencia: F2 \n Remover Agencia: F3" );
			var opcao = Console.ReadKey();

			switch (opcao.Key) {
				case ConsoleKey.F1:
					Console.Clear();
					CadastrarAgencia();
					Console.WriteLine("Agencia cadastrada.");
					break;
				case ConsoleKey.F2:
					Console.Clear();
					CadastrarAgencia();
					Console.WriteLine( "Agencia cadastrada." );
					break;
				case ConsoleKey.F3:

					break;
				default:
					Console.WriteLine( "Opção Inválida." );
					break;
			}

			menu.Inicio();
		}

		public void CadastrarAgencia()
		{
			Agencia agencia = new Agencia();

			Console.WriteLine( "Cadastro da Agencia." );

			Console.WriteLine( "Codigo da agencia: " );
			agencia.Codigo = Convert.ToInt32( Console.ReadLine() );

			Console.WriteLine( "Nome da agencia: " );
			agencia.Nome = Console.ReadLine();

			Console.WriteLine( "Nome da cidade: " );
			agencia.NomeCidade = Console.ReadLine();

			Console.WriteLine( "UF: " );
			agencia.UF = Convert.ToInt32( Console.ReadLine() );

			agencias.Add( agencia );
		}
	}
}
