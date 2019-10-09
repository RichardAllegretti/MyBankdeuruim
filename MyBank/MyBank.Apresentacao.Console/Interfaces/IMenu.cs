using MyBank.Apresentação.OBJ;

namespace MyBank.Apresentacao.Console.Interfaces
{
    public interface IMenuCadastro<T>
    {
        void Inicio(Menu menu);
		void Cadastrar();
		void Atualizar();
		void Remover();
		void SelecionarTudo();
    }
}
