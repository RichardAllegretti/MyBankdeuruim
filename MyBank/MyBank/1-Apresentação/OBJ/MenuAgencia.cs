using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank._2_Aplicação.Interface;
using MyBank.Dominio.OBJ;
using MyBank.Infraestrutura;
using MyBank.Infraestrutura.Interface;

namespace MyBank.Apresentação.OBJ
{
    public class MenuAgencia : IMenuCadastro<Agencia>
    {
		private IServico<Agencia> _agencia;

		public MenuAgencia(IServico<Agencia> serv)
		{
			_agencia = serv;
		}

        public void Inicio(Menu menu)
        {
			Console.Clear();

            Console.WriteLine("Bem vindo ao menu de Agencias.");
            Console.WriteLine("Digite a opção desejada: \n Cadastrar Agencia: F1 \n Atualizar Agencia: F2 \n Remover Agencia: F3 \n Selecionar todas as Agencias: F4 \n Voltar ao Inicio: F5");
            var opcao = Console.ReadKey();

            switch (opcao.Key)
            {
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
                    Console.WriteLine("Opção Inválida.");
                    break;
            }
			menu.Inicio();
        }
		
		public void Cadastrar()
		{
			Console.Clear();

			Console.WriteLine( "Cadastro da Agencia." );

			Agencia agencia = InformacoesAgencia();

			_agencia.Cadastrar( agencia );

			Console.WriteLine( "Agencia cadastrada." );

			Console.ReadLine();			
		}

		public void Atualizar()
		{
			Console.Clear();

			Console.WriteLine( "Atualizar Agencia:" );

			Console.WriteLine( "Nome da Agencia a ser atualizada:" );
			string nomeAgencia = Console.ReadLine();

			Agencia agenciaAntiga = _agencia.Selecionar( nomeAgencia );

			Agencia agenciaNova = new Agencia();

			agenciaNova = InformacoesAgencia();

			_agencia.Atualizar( agenciaAntiga, agenciaNova );

			Console.WriteLine( "Agencia Atualizada." );

			Console.ReadLine();
		}

		public void Remover()
		{
			Console.Clear();

			Console.WriteLine( "Qual o nome da Agencia que deseja remover:" );
			string nomeAgencia = Console.ReadLine();

			Agencia agencia = _agencia.Selecionar( nomeAgencia );

			_agencia.Remover( agencia );

			Console.WriteLine( "Agencia Removida." );

			Console.ReadLine();
		}

		public void SelecionarTudo()
		{
			Console.Clear();

			Console.WriteLine( "Listagem de todas as agencias: \n" );

			foreach (var agencia in _agencia.SelecionarTudo()) {
				Console.WriteLine( string.Format( "Nome: {0} | Codigo: {1} | Nome Cidade: {2} | UF: {3} \n", agencia.Nome, agencia.Codigo, agencia.NomeCidade, agencia.UF ) );
			}

			Console.ReadLine();
		}

		private Agencia InformacoesAgencia()
		{
			Agencia agencia = new Agencia();

			Console.WriteLine( "Codigo da agencia: " );
			agencia.Codigo = Convert.ToInt32( Console.ReadLine() );

			Console.WriteLine( "Nome da agencia: " );
			agencia.Nome = Console.ReadLine();

			Console.WriteLine( "Nome da cidade: " );
			agencia.NomeCidade = Console.ReadLine();

			Console.WriteLine( "UF: " );
			agencia.UF = Console.ReadLine();

			return agencia;
		}
	}
}
