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
        private static MenuAgencia _agencia;
        private static MenuConta _conta;
		private static ServicoAgencia _servicoAgencia;
		private static ServicoPessoa _servicoPessoa;
		private static ContaDAO _daoConta;
		private static ServicoConta _servicoConta = new ServicoConta(_daoConta, _servicoAgencia, _servicoPessoa );

		public void Inicio()
        {
            Console.WriteLine("Bem vindo ao MyBank. \n");
            Console.WriteLine("Sobre Agencia digite: F1 \n Sobre Contas digite: F2");
            var opcao = Console.ReadKey();

            switch (opcao.Key)
            {
                case ConsoleKey.F1:
                    _agencia.Inicio(this, _servicoAgencia);
                    break;
                case ConsoleKey.F2:
					_conta.Inicio( this, _servicoConta);
                    break;
                default:
                    Console.WriteLine("Opção Inválida.");
                    break;
            }
        }

    }
}
