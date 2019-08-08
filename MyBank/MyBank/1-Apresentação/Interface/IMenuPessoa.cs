using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank._2_Aplicação.Interface;
using MyBank.Apresentação.OBJ;

namespace MyBank._1_Apresentação.Interface
{
	public interface IMenuPessoa<T>
	{
		void Inicio(Menu menu);
		void Cadastrar();
		void Atualizar();
		void Remover();
		void SelecionarTudo();
	}
}
