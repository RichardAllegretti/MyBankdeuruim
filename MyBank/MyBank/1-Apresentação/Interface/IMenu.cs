using MyBank._2_Aplicação.Interface;
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
        void Inicio(Menu menu);
		void Cadastrar();
		void Atualizar();
		void Remover();
		void SelecionarTudo();
    }
}
