using System;
using MyBank.Aplicacao.Interfaces;
using MyBank.Apresentacao.Console.Interfaces;
using MyBank.Apresentação.OBJ;
using MyBank.Dominio.objetos;

namespace MyBank.Apresentacao.Console.objetos
{
	public class MenuPessoa : IMenuPessoa<Pessoa>
	{
		private readonly IServicoPessoa _pessoa;

		public MenuPessoa(IServicoPessoa serv)
		{
			_pessoa = serv;
		}

		public void Inicio(Menu menu)
		{
			System.Console.Clear();

			System.Console.WriteLine( "Bem vindo ao menu de Agencias." );
			System.Console.WriteLine( "Digite a opção desejada: \n Cadastrar Conta: F1 \n Atualizar Conta: F2 \n Remover Conta: F3 \n Selecionar todas as Conta: F4 \n Voltar ao Inicio: F5" );
			var opcao = System.Console.ReadKey();

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
					System.Console.WriteLine( "Opção Inválida." );
					break;
			}

			menu.Inicio();
		}
		
		public void Cadastrar()
		{
			System.Console.Clear();

			System.Console.WriteLine( "Cadastro da Pessoa." );

			System.Console.WriteLine( "Digite o nome da Agencia:" );
			string nomeAgencia = System.Console.ReadLine();

			System.Console.WriteLine( "Digite o nome da Conta:" );
			string nomeConta = System.Console.ReadLine();

			Pessoa pessoa = InformacoesPessoa(_pessoa.SelecionarAgencia(nomeAgencia), _pessoa.SelecionarConta(nomeConta));

			_pessoa.Cadastrar( pessoa );

			System.Console.WriteLine( "Pessoa cadastrada." );

			System.Console.ReadLine();
		}

		public void Atualizar()
		{
			System.Console.Clear();

			System.Console.WriteLine( "Atualizar Pessoa:" );

			System.Console.WriteLine( "Nome da Pessoa a ser atualizada:" );
			string nomePessoa = System.Console.ReadLine();

			Pessoa pessoaAntiga = _pessoa.Selecionar( nomePessoa );

			Pessoa pessoaNova = new Pessoa( pessoaAntiga.Agencia, pessoaAntiga.Conta );

			pessoaNova = InformacoesPessoa( pessoaAntiga.Agencia, pessoaAntiga.Conta );

			_pessoa.Atualizar( pessoaAntiga, pessoaNova );

			System.Console.WriteLine( "Pessoa Atualizada." );

            System.Console.ReadLine();
        }

		public void Remover()
		{
			System.Console.Clear();

			System.Console.WriteLine( "Qual o nome da Pessoa que deseja remover:" );
			string nomePessoa = System.Console.ReadLine();

			Pessoa pessoa = _pessoa.Selecionar( nomePessoa );

			_pessoa.Remover( "teste" );

			System.Console.WriteLine( "Pessoa Removida." );

            System.Console.ReadLine();
        }

		public void SelecionarTudo()
		{
			System.Console.Clear();

			System.Console.WriteLine( "Listagem de todas as pessoas: \n" );

			foreach (var pessoa in _pessoa.SelecionarTudo()) {
				System.Console.WriteLine( string.Format( "Nome: {0} | Tipo: {1} | CPF/CNPJ: {2} | Conta: {3} \n | Agencia: {4} \n", pessoa.Nome, pessoa.Tipo, pessoa.CpfCnpj, pessoa.Conta.Nome, pessoa.Agencia.Nome ) );
			}

            System.Console.ReadLine();
        }

		private Pessoa InformacoesPessoa(Agencia agencia, Conta conta)
		{
			Pessoa pessoa = new Pessoa( agencia, conta );

			System.Console.WriteLine( "Nome Pessoa: " );
			pessoa.Nome = System.Console.ReadLine();

			System.Console.WriteLine( "Tipo (Fisica/Juridica): " );
			pessoa.Tipo = System.Console.ReadLine();

			System.Console.WriteLine( "Documento: " );
			pessoa.CpfCnpj = System.Console.ReadLine();

			System.Console.WriteLine( "CEP: " );
			pessoa.CEP = System.Console.ReadLine();

			System.Console.WriteLine( "Data de nascimento: " );
			pessoa.DataNascOp = Convert.ToDateTime( System.Console.ReadLine() );

			System.Console.WriteLine( "Numero do Endereço: " );
			pessoa.NumeroEndereco = Convert.ToInt16( System.Console.ReadLine() );

			pessoa.Agencia = agencia;
			pessoa.Conta = conta;

			return pessoa;
		}
	}
}
