using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Pessoa> pessoas = new List<Pessoa>();

			Console.WriteLine( "MyBank, Bem vindo ao cadastro de pessoas" );

			Pessoa novaPessoa = new Pessoa();

			Console.WriteLine("Digite o nome: ");
			novaPessoa.Nome = Console.ReadLine();

			Console.WriteLine("Digite o tipo de pessoa (Fisica/Juridica)");
			novaPessoa.Tipo = Console.ReadLine();

			Console.WriteLine( "Digite o documento:" );
			novaPessoa.CpfCnpj = Console.ReadLine();

			if (novaPessoa.CpfCnpj == null) 
			{
				Console.WriteLine("Tipo do documento inválido.");
				Console.WriteLine("Digite novamento o Tipo do documento:");
				Console.ReadLine();
			}

			Console.WriteLine("Digite a data de nascimento: (DD/MM/AAAA)");
			novaPessoa.DataNascOp = Convert.ToDateTime(Console.ReadLine());

			Console.WriteLine("Digite o CEP:");
			novaPessoa.CEP = Console.ReadLine();

			Console.WriteLine( "Digite o número do endereço:" );
			novaPessoa.NumeroEndereco = Convert.ToInt16(Console.ReadLine());

			pessoas.Add( novaPessoa );
		}
	}
}