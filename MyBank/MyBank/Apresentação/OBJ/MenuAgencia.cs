﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Dominio.OBJ;
using MyBank.Infraestrutura;

namespace MyBank.Apresentação.OBJ
{
	public class MenuAgencia : Menu
	{
		public void Menu(Menu menu, AgenciaDAO dao)
		{
			Console.WriteLine( "Bem vindo ao menu de Agencias." );
			Console.WriteLine( "Digite a opção desejada: \n Cadastrar Agencia: F1 \n Atualizar Agencia: F2 \n Remover Agencia: F3" );
			var opcao = Console.ReadKey();

			switch (opcao.Key) {
				case ConsoleKey.F1:					
					CadastrarAgencia( dao );					
					break;
				case ConsoleKey.F2:
					AtualizarAgencia( dao );					
					break;
				case ConsoleKey.F3:					
					RemoverAgencia( dao );					
					break;
				case ConsoleKey.F4:					
					SelecionarTodasAgencias( dao );
					break;
				default:
					Console.WriteLine( "Opção Inválida." );
					break;
			}

			menu.Inicio();
		}

		private void SelecionarTodasAgencias(AgenciaDAO dao)
		{
			Console.Clear();

			Console.WriteLine( "Listagem de todas as agencias: \n" );

			foreach (var agencia in dao.SelecionarTudo()) 
			{
				Console.WriteLine( "" );
			}
		}

		private void RemoverAgencia(AgenciaDAO dao)
		{
			Console.Clear();

			Console.WriteLine( "Qual o nome da Agencia que deseja remover:" );
			string nomeAgencia = Console.ReadLine();

			Agencia agencia = dao.Selecionar( nomeAgencia );

			dao.Remover( agencia );

			Console.WriteLine( "Agencia Removida." );
		}

		private void AtualizarAgencia(AgenciaDAO dao)
		{
			Console.Clear();

			Console.WriteLine( "Atualizar Agencia:" );

			Console.WriteLine( "Nome da Agencia a ser atualizada:" );
			string nomeAgencia = Console.ReadLine();

			Agencia agenciaAntiga = dao.Selecionar( nomeAgencia );

			Agencia agenciaNova = new Agencia();

			agenciaNova = InformacoesAgencia();

			dao.Atualizar( agenciaAntiga, agenciaNova );

			Console.WriteLine( "Agencia Atualizada." );
		}

		private void CadastrarAgencia(AgenciaDAO dao)
		{
			Console.Clear();

			Console.WriteLine( "Cadastro da Agencia." );

			Agencia agencia = InformacoesAgencia();

			dao.Cadastrar( agencia );

			Console.WriteLine( "Agencia cadastrada." );
		}

		private Agencia InformacoesAgencia()
		{
			Agencia agencia = new Agencia();

			Console.WriteLine( "Codigo da agencia: " );
			agencia.Codigo = Convert.ToInt32( Console.ReadLine() );

			Console.WriteLine( "Nome da agencia: " );
			agencia.Nome = Console.ReadLine();

			Console.WriteLine( "Nome da cidade: " );
			agencia.NomeCidade = Console.ReadLine();

			Console.WriteLine( "UF: " );
			agencia.UF = Convert.ToInt32( Console.ReadLine() );

			return agencia;
		}
	}
}
