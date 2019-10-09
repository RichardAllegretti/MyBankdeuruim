using System;
using MyBank._2_Aplicação;
using MyBank._4_Infraestrutura;
using MyBank.Aplicacao;
using MyBank.Apresentacao.Console.objetos;
using MyBank.Dominio.Interfaces;
using MyBank.Dominio.objetos;
using MyBank.Infra.Gerenciamento.Banco;
using MyBank.Infra.SQL;

namespace MyBank.Apresentação.OBJ
{
    public class Menu
    {
        private static IGerenciadorSQL<Agencia> _gerenciador = new GerenciadorSQL(); 

		private static IArmazenamento<Agencia> _daoAgencia = new AgenciaSQLDAO(_gerenciador);
		//private static IArmazenamento<Conta> _daoConta = new AgenciaSQLDAO(_gerenciador);
		//private static IArmazenamento<Pessoa> _daoPessoa = new PessoaDAO();		

		private static ServicoAgencia _servicoAgencia = new ServicoAgencia(_daoAgencia);
		//private static ServicoConta _servicoConta = new ServicoConta( _daoConta, _servicoAgencia, _servicoPessoa );
		//private static ServicoPessoa _servicoPessoa = new ServicoPessoa( _daoPessoa, _servicoAgencia, _servicoConta );

		private static MenuAgencia _agencia = new MenuAgencia( _servicoAgencia );
		//private static MenuConta _conta = new MenuConta( _servicoConta );
		//private static MenuPessoa _pessoa = new MenuPessoa( _servicoPessoa );

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
					//_conta.Inicio(this);
                    break;
				case ConsoleKey.F3:
					//_pessoa.Inicio( this );
					break;
				default:
                    Console.WriteLine("Opção Inválida.");
                    break;
            }
        }
    }
}
