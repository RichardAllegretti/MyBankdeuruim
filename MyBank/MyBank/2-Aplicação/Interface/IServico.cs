using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank._2_Aplicação.Interface
{
	public interface IServico<T>
	{
		void Cadastrar(T objeto);
		void Atualizar(T objetoAntigo, T objetoNovo);
		void Remover(T objeto);
		T Selecionar(string nome);
		List<T> SelecionarTudo();
	}
}
