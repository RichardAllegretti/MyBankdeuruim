using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Dominio.OBJ;

namespace MyBank._3_Dominio.OBJ
{
	public class Funcionario : Pessoa
	{
		public DateTime DataAdmissao { get; set; }
		public string Funcao { get; set; }
		public double Salario { get; set; }

		public Funcionario(Agencia agencia, Conta conta) : base(agencia, conta)
		{
		}
		public Funcionario()
		{
				
		}
	}
}
