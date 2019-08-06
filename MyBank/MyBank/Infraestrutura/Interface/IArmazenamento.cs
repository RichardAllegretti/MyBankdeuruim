using MyBank.Dominio.OBJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Infraestrutura.Interface
{
	public interface IArmazenamento<T> 
	{
		void Cadastrar(T objeto);
		void Atualizar(T objetoAntigo, T objetoNovo);
		void Remover(T objeto);
		T Selecionar(string nome);
		List<T> SelecionarTudo();
	}
}
