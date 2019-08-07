using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Apresentação.OBJ;
using MyBank.Dominio.OBJ;

namespace MyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Inicio();
        }
    }
}