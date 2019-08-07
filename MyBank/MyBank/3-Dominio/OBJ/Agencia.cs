using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Dominio.OBJ
{
	public class Agencia
	{
		public int Id { get; set; }

		private static int _idGlobal { get; set; }

		public int Codigo { get; set; }

		public string Nome { get; set; }

		public string NomeCidade { get; set; }

		public int UF { get; set; }

		public List<Conta> Conta;

		public Agencia()
		{
			IdGlobal++;
			Id = IdGlobal;
			Conta = new List<Conta>();
		}
	}
}
