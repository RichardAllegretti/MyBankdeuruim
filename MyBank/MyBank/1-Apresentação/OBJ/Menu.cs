using MyBank._2_Aplicação;
using MyBank._2_Aplicação.Interface;
using MyBank.Dominio.OBJ;
using MyBank.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Apresentação.OBJ
{
    public class Menu
    {
		private static AgenciaDAO _daoAgencia = new AgenciaDAO();
		private static ContaDAO _daoConta = new ContaDAO();
		private static PessoaDAO _daoPessoa = new PessoaDAO();		

		private static ServicoAgencia _servicoAgencia = new ServicoAgencia(_daoAgencia);
		private static ServicoConta _servicoConta = new ServicoConta( _daoConta, _servicoAgencia, _servicoPessoa );
		private static ServicoPessoa _servicoPessoa = new ServicoPessoa( _daoPessoa, _servicoAgencia, _servicoConta );

		private static MenuAgencia _agencia = new MenuAgencia( _servicoAgencia );
		private static MenuConta _conta = new MenuConta( _servicoConta );
		private static MenuPessoa _pessoa = new MenuPessoa( _servicoPessoa );

		public void Inicio()
        {
            Console.WriteLine("Bem vindo ao MyBank. \n");
            Console.WriteLine( "Agencia: F1 \nContas: F2\nPessoa: F3" );
            var opcao = Console.ReadKey();

            switch (opcao.Key)
            {
                case ConsoleKey.F1:
                    _agencia.Inicio(this);
                    break;
                case ConsoleKey.F2:
					_conta.Inicio(this);
                    break;
				case ConsoleKey.F3:
					_pessoa.Inicio( this );
					break;
				default:
                    Console.WriteLine("Opção Inválida.");
                    break;
            }
        }
    }
}
