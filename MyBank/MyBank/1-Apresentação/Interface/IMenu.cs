using MyBank.Infraestrutura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Apresentação.OBJ
{
    public interface IMenuCadastro<T>
    {
        void Inicio(Menu menu, IArmazenamento<T> dao);
		void Cadastrar(IArmazenamento<T> dao);
		void Atualizar(IArmazenamento<T> dao);
		void Remover(IArmazenamento<T> dao);
		void SelecionarTudo(IArmazenamento<T> dao);
    }
}
