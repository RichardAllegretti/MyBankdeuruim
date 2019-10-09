using System;
using MyBank.Aplicacao.Interfaces;
using MyBank.Apresentacao.Console.Interfaces;
using MyBank.Apresentação.OBJ;
using MyBank.Dominio.objetos;

namespace MyBank.Apresentacao.Console.objetos
{
    public class MenuAgencia : IMenuCadastro<Agencia>
    {
		private readonly IServico<Agencia> _agencia;

		public MenuAgencia(IServico<Agencia> serv)
		{
			_agencia = serv;
		}

        public void Inicio(Menu menu)
        {
			System.Console.Clear();

            System.Console.WriteLine("Bem vindo ao menu de Agencias.");
            System.Console.WriteLine("Digite a opção desejada: \n Cadastrar Agencia: F1 \n Atualizar Agencia: F2 \n Remover Agencia: F3 \n Selecionar todas as Agencias: F4 \n Voltar ao Inicio: F5");
            var opcao = System.Console.ReadKey();

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
                    System.Console.WriteLine("Opção Inválida.");
                    break;
            }
			menu.Inicio();
        }
		
		public void Cadastrar()
		{
			System.Console.Clear();

			System.Console.WriteLine( "Cadastro da Agencia." );

			Agencia agencia = InformacoesAgencia();

			_agencia.Cadastrar( agencia );

			System.Console.WriteLine( "Agencia cadastrada." );

			System.Console.ReadLine();			
		}

		public void Atualizar()
		{
			System.Console.Clear();

			System.Console.WriteLine( "Atualizar Agencia:" );

			System.Console.WriteLine( "Nome da Agencia a ser atualizada:" );
			string nomeAgencia = System.Console.ReadLine();

			Agencia agenciaAntiga = _agencia.Selecionar( nomeAgencia );

			Agencia agenciaNova = new Agencia();

			agenciaNova = InformacoesAgencia();

			_agencia.Atualizar( agenciaAntiga, agenciaNova );

			System.Console.WriteLine( "Agencia Atualizada." );

			System.Console.ReadLine();
		}

		public void Remover()
		{
			System.Console.Clear();

			System.Console.WriteLine( "Qual o nome da Agencia que deseja remover:" );
			string nomeAgencia = System.Console.ReadLine();

			_agencia.Remover(nomeAgencia);

			System.Console.WriteLine( "Agencia Removida." );

			System.Console.ReadLine();
		}

		public void SelecionarTudo()
		{
			System.Console.Clear();

			System.Console.WriteLine( "Listagem de todas as agencias: \n" );

			foreach (var agencia in _agencia.SelecionarTudo()) {
				System.Console.WriteLine( string.Format( "Nome: {0} | Codigo: {1} | Nome Cidade: {2} | UF: {3} \n", agencia.Nome, agencia.Codigo, agencia.NomeCidade, agencia.UF ) );
			}

			System.Console.ReadLine();
		}

		private Agencia InformacoesAgencia()
		{
			Agencia agencia = new Agencia();

			System.Console.WriteLine( "Codigo da agencia: " );
			agencia.Codigo = Convert.ToInt32( System.Console.ReadLine() );

			System.Console.WriteLine( "Nome da agencia: " );
			agencia.Nome = System.Console.ReadLine();

			System.Console.WriteLine( "Nome da cidade: " );
			agencia.NomeCidade = System.Console.ReadLine();

			System.Console.WriteLine( "UF: " );
			agencia.UF = System.Console.ReadLine();

			return agencia;
		}
	}
}
