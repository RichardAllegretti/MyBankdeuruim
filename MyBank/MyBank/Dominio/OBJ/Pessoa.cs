using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MyBank.Dominio.OBJ;

namespace MyBank
{
	public class Pessoa
	{
		public int Id { get; set; }

		private int IdGlobal { get; set; }

		public string Nome { get; set; }

		public string Tipo { get; set; }

		public string CpfCnpj { get; set; }	
		
		public string CEP { get; set; }

		public DateTime DataNascOp { get; set; }

		public int NumeroEndereco { get; set; }

		public Agencia Agencia { get; set; }

		public Conta Conta { get; set; }

		public Pessoa(Agencia agencia, Conta conta)
		{
			IdGlobal++;
			Id = IdGlobal;
			Agencia = agencia;
			Conta = conta;
		}
	}
}
