using System;

namespace MyBank.Dominio.objetos
{
	public class Pessoa
	{
		public int Id { get; set; }

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
            Agencia = agencia;
			Conta = conta;
		}
	}
}
