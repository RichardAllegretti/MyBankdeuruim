using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank._2_Aplicação.Interface;
using MyBank.Apresentação.OBJ;

namespace MyBank._1_Apresentação.Interface
{
	public interface IMenuConta<T>
	{
		void Inicio(Menu menu, IServicoConta serv);
		void Cadastrar(IServicoConta serv);
		void Atualizar(IServicoConta serv);
		void Remover(IServicoConta serv);
		void SelecionarTudo(IServicoConta serv);
	}
}
