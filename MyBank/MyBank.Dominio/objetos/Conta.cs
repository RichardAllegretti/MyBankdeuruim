using System;

namespace MyBank.Dominio.objetos
{
	public class Conta
	{
		public int Id { get; set; }

        public string Nome { get; set; }

		public Pessoa Pessoa { get; set; }

		public double Saldo { get; set; }

		public DateTime DataAbertura { get; set; }

		public Agencia Agencia { get; set; }

		public Conta(Agencia agencia)
		{
            Agencia = agencia;
			Pessoa = new Pessoa(agencia, this);
		}
	}
}
