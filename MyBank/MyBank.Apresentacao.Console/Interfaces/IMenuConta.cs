using MyBank.Apresentação.OBJ;

namespace MyBank.Apresentacao.Console.Interfaces
{
	public interface IMenuConta<T>
	{
		void Inicio(Menu menu);
		void Cadastrar();
		void Atualizar();
		void Remover();
		void SelecionarTudo();
	}
}
