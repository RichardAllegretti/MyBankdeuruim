using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyBank
{
	public class Pessoa
	{
		string cpfCnpj;

		public string Nome { get; set; }
		public string Tipo { get; set; }
		public string CpfCnpj { get { return cpfCnpj; }
			set {
				if (IsCPFCNPJ( value ))
					cpfCnpj = value;
			} }
				
		public string CEP { get; set; }
		public DateTime DataNascOp { get; set; }
		public int NumeroEndereco { get; set; }
		
		public bool IsCPFCNPJ(string cpfCnpj)
		{
			if (string.IsNullOrEmpty(CpfCnpj))
				return false;
			else {
				int[] d = new int[14];
				int[] v = new int[2];
				int j, i, soma;
				string Sequencia, SoNumero;

				SoNumero = Regex.Replace(CpfCnpj, "[^0-9]", string.Empty);

				//verificando se todos os numeros são iguais
				if (new string(SoNumero[0],SoNumero.Length) == SoNumero) return false;

				// se a quantidade de dígitos numérios for igual a 11
				// iremos verificar como CPF
				if (SoNumero.Length == 11) {
					for (i = 0; i <= 10; i++) d[ i ] = Convert.ToInt32(SoNumero.Substring(i, 1));
					for (i = 0; i <= 1; i++) {
						soma = 0;
						for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

						v[ i ] = (soma * 10) % 11;
						if (v[i] == 10) v[i] = 0;
					}
					return (v[0] == d[9] & v[1] == d[10]);
				}
				// se a quantidade de dígitos numérios for igual a 14
				// iremos verificar como CNPJ
				else if (SoNumero.Length == 14) {
					Sequencia = "6543298765432";
					for (i = 0; i <= 13; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
					for (i = 0; i <= 1; i++) {
						soma = 0;
						for (j = 0; j <= 11 + i; j++)
							soma += d[j] * Convert.ToInt32(Sequencia.Substring(j + 1 - i, 1));

						v[i] = (soma * 10) % 11;
						if (v[i] == 10) v[i] = 0;
					}
					return (v[0] == d[12] & v[1] == d[13]);
				}
				// CPF ou CNPJ inválido se
				// a quantidade de dígitos numérios for diferente de 11 e 14
				else return false;
			}
		}
	}
}
