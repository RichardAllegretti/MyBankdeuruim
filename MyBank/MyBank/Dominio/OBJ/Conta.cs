using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Dominio.OBJ
{
	public class Conta
	{
		public int Id { get; set; }

		private static int IdGlobal { get; set; }

		public Pessoa Pessoa { get; set; }

		public double Saldo { get; set; }

		public DateTime DataAbertura { get; set; }

		public Agencia Agencia { get; set; }

		public Conta(Agencia agencia)
		{
			IdGlobal++;
			Id = IdGlobal;
			Agencia = agencia;
			Pessoa = new Pessoa();
		}
	}
}
