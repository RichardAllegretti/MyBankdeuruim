using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank._1_Apresentação.Interface;
using MyBank._2_Aplicação.Interface;
using MyBank.Dominio.OBJ;
using MyBank.Infraestrutura.Interface;

namespace MyBank.Apresentação.OBJ
{
	public class MenuPessoa : IMenuPessoa<Pessoa>
	{
		private IServicoPessoa _pessoa;

		public MenuPessoa(IServicoPessoa serv)
		{
			_pessoa = serv;
		}

		public void Inicio(Menu menu)
		{
			Console.Clear();

			Console.WriteLine( "Bem vindo ao menu de Agencias." );
			Console.WriteLine( "Digite a opção desejada: \n Cadastrar Conta: F1 \n Atualizar Conta: F2 \n Remover Conta: F3 \n Selecionar todas as Conta: F4 \n Voltar ao Inicio: F5" );
			var opcao = Console.ReadKey();

			switch (opcao.Key) {
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
					Console.WriteLine( "Opção Inválida." );
					break;
			}

			menu.Inicio();
		}
		
		public void Cadastrar()
		{
			Console.Clear();

			Console.WriteLine( "Cadastro da Pessoa." );

			Console.WriteLine( "Digite o nome da Agencia:" );
			string nomeAgencia = Console.ReadLine();

			Console.WriteLine( "Digite o nome da Conta:" );
			string nomeConta = Console.ReadLine();

			Pessoa pessoa = InformacoesPessoa(_pessoa.SelecionarAgencia(nomeAgencia), _pessoa.SelecionarConta(nomeConta));

			_pessoa.Cadastrar( pessoa );

			Console.WriteLine( "Pessoa cadastrada." );

			Console.ReadLine();
		}

		public void Atualizar()
		{
			Console.Clear();

			Console.WriteLine( "Atualizar Pessoa:" );

			Console.WriteLine( "Nome da Pessoa a ser atualizada:" );
			string nomePessoa = Console.ReadLine();

			Pessoa pessoaAntiga = _pessoa.Selecionar( nomePessoa );

			Pessoa pessoaNova = new Pessoa( pessoaAntiga.Agencia, pessoaAntiga.Conta );

			pessoaNova = InformacoesPessoa( pessoaAntiga.Agencia, pessoaAntiga.Conta );

			_pessoa.Atualizar( pessoaAntiga, pessoaNova );

			Console.WriteLine( "Pessoa Atualizada." );

			Console.ReadLine()
		}

		public void Remover()
		{
			Console.Clear();

			Console.WriteLine( "Qual o nome da Pessoa que deseja remover:" );
			string nomePessoa = Console.ReadLine();

			Pessoa pessoa = _pessoa.Selecionar( nomePessoa );

			_pessoa.Remover( pessoa );

			Console.WriteLine( "Pessoa Removida." );

			Console.ReadLine()
		}

		public void SelecionarTudo()
		{
			Console.Clear();

			Console.WriteLine( "Listagem de todas as pessoas: \n" );

			foreach (var pessoa in _pessoa.SelecionarTudo()) {
				Console.WriteLine( string.Format( "Nome: {0} | Tipo: {1} | CPF/CNPJ: {2} | Conta: {3} \n | Agencia: {4} \n", pessoa.Nome, pessoa.Tipo, pessoa.CpfCnpj, pessoa.Conta.Nome, pessoa.Agencia.Nome ) );
			}

			Console.ReadLine()
		}

		private Pessoa InformacoesPessoa(Agencia agencia, Conta conta)
		{
			Pessoa pessoa = new Pessoa( agencia, conta );

			Console.WriteLine( "Nome Pessoa: " );
			pessoa.Nome = Console.ReadLine();

			Console.WriteLine( "Tipo (Fisica/Juridica): " );
			pessoa.Tipo = Console.ReadLine();

			Console.WriteLine( "Documento: " );
			pessoa.CpfCnpj = Console.ReadLine();

			Console.WriteLine( "CEP: " );
			pessoa.CEP = Console.ReadLine();

			Console.WriteLine( "Data de nascimento: " );
			pessoa.DataNascOp = Convert.ToDateTime( Console.ReadLine() );

			Console.WriteLine( "Numero do Endereço: " );
			pessoa.NumeroEndereco = Convert.ToInt16( Console.ReadLine() );

			pessoa.Agencia = agencia;
			pessoa.Conta = conta;

			return pessoa;
		}
	}
}
