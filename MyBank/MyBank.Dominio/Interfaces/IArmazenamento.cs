using System.Collections.Generic;

namespace MyBank.Dominio.Interfaces
{
	public interface IArmazenamento<T> 
	{
		void Cadastrar(T objeto);
		void Atualizar(T objetoAntigo, T objetoNovo);
		void Remover(string nome);
		T Selecionar(string nome);
		List<T> SelecionarTudo();
	}
}
