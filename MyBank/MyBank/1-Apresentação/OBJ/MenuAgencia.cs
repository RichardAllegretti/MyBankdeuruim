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
        public void Inicio(Menu menu, IServico<Agencia> serv)
        {
            Console.WriteLine("Bem vindo ao menu de Agencias.");
            Console.WriteLine("Digite a opção desejada: \n Cadastrar Agencia: F1 \n Atualizar Agencia: F2 \n Remover Agencia: F3 \n Selecionar todas as Agencias: F4 \n Voltar ao Inicio: F5");
            var opcao = Console.ReadKey();

            switch (opcao.Key)
            {
                case ConsoleKey.F1:
                    Cadastrar(serv);
                    break;
                case ConsoleKey.F2:
                    Atualizar( serv );
                    break;
                case ConsoleKey.F3:
                    Remover( serv );
                    break;
                case ConsoleKey.F4:
					SelecionarTudo( serv );
                    break;
                case ConsoleKey.F5:
                    menu.Inicio();
                    break;
                default:
                    Console.WriteLine("Opção Inválida.");
                    break;
            }       
        }

        private Agencia InformacoesAgencia()
        {
            Agencia agencia = new Agencia();

            Console.WriteLine("Codigo da agencia: ");
            agencia.Codigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nome da agencia: ");
            agencia.Nome = Console.ReadLine();

            Console.WriteLine("Nome da cidade: ");
            agencia.NomeCidade = Console.ReadLine();

            Console.WriteLine("UF: ");
            agencia.UF = Convert.ToInt32(Console.ReadLine());

            return agencia;
        }

		public void Cadastrar(IServico<Agencia> serv)
		{
			Console.Clear();

			Console.WriteLine( "Cadastro da Agencia." );

			Agencia agencia = InformacoesAgencia();

			serv.Cadastrar( agencia );

			Console.WriteLine( "Agencia cadastrada." );
		}

		public void Atualizar(IServico<Agencia> serv)
		{
			Console.Clear();

			Console.WriteLine( "Atualizar Agencia:" );

			Console.WriteLine( "Nome da Agencia a ser atualizada:" );
			string nomeAgencia = Console.ReadLine();

			Agencia agenciaAntiga = serv.Selecionar( nomeAgencia );

			Agencia agenciaNova = new Agencia();

			agenciaNova = InformacoesAgencia();

			serv.Atualizar( agenciaAntiga, agenciaNova );

			Console.WriteLine( "Agencia Atualizada." );
		}

		public void Remover(IServico<Agencia> serv)
		{
			Console.Clear();

			Console.WriteLine( "Qual o nome da Agencia que deseja remover:" );
			string nomeAgencia = Console.ReadLine();

			Agencia agencia = serv.Selecionar( nomeAgencia );

			serv.Remover( agencia );

			Console.WriteLine( "Agencia Removida." );
		}

		public void SelecionarTudo(IServico<Agencia> serv)
		{
			Console.Clear();

			Console.WriteLine( "Listagem de todas as agencias: \n" );

			foreach (var agencia in serv.SelecionarTudo()) {
				Console.WriteLine( string.Format( "Nome: {0} | Codigo: {1} | Nome Cidade: {2} | UF: {3} \n", agencia.Nome, agencia.Codigo, agencia.NomeCidade, agencia.UF ) );
			}
		}
	}
}
