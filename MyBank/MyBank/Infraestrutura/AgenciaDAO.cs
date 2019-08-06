using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Dominio.OBJ;
using MyBank.Infraestrutura.Interface;

namespace MyBank.Infraestrutura
{
	public class AgenciaDAO : IArmazenamento<Agencia> 
	{
		List<Agencia> agencias = new List<Agencia>();

		public void Atualizar(Agencia objetoAntigo, Agencia objetoNovo)
		{
			Agencia agencia = agencias.Find( a => a.Id == objetoNovo.Id );
			agencia.Nome = objetoNovo.Nome;
			agencia.NomeCidade = objetoNovo.NomeCidade;
			agencia.Codigo = objetoNovo.Codigo;
			agencia.UF = objetoNovo.UF;
		}

		public void Cadastrar(Agencia objeto)
		{
			agencias.Add( objeto );
		}

		public void Remover(Agencia objeto)
		{
			agencias.Remove( objeto );
		}

		public Agencia Selecionar(string nome)
		{
			return agencias.Find( a => a.Nome == nome );
		}

		public List<Agencia> SelecionarTudo()
		{
			return agencias;
		}
	}
}
