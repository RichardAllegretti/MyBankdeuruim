using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank._3_Dominio.OBJ;
using MyBank.Dominio.OBJ;

namespace MyBank._2_Aplicação.Interface
{
	public interface IServicoFuncionario : IServico<Funcionario>
	{
		Agencia SelecionarAgencia(string nome);
		Conta SelecionarConta(string nome);
	}
}
