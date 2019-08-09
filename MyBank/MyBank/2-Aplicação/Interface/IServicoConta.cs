using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Dominio.OBJ;

namespace MyBank._2_Aplicação.Interface
{
	public interface IServicoConta : IServico<Conta>
	{
		Agencia SelecionarAgencia(string nome);
	}
}