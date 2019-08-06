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

        public void Inicio()
        {
            Console.WriteLine("Bem vindo ao MyBank. \n");
            Console.WriteLine("Sobre Agencia digite: F1 \n Sobre Contas digite: F2");
            var opcao = Console.ReadKey();

            switch (opcao.Key)
            {
                case ConsoleKey.F1:
                    _agencia.Inicio(this, new AgenciaDAO());
                    break;
                case ConsoleKey.F2:

                    break;
                default:
                    Console.WriteLine("Opção Inválida.");
                    break;
            }
        }

    }
}
