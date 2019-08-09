using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Dominio.OBJ;
using MyBank.Infraestrutura;
using MyBank.Infraestrutura.Interface;

namespace MyBank._2_Aplicação.Interface
{
	public class ServicoAgencia : IServico<Agencia>
	{
		private IArmazenamento<Agencia> _agencia;

		public ServicoAgencia(IArmazenamento<Agencia> agencia)
		{
			_agencia = agencia;
		}

		public void Atualizar(Agencia objetoAntigo, Agencia objetoNovo)
		{
			_agencia.Atualizar( objetoAntigo, objetoNovo );
		}

		public void Cadastrar(Agencia objeto)
		{
			_agencia.Cadastrar(objeto);
		}

		public void Remover(Agencia objeto)
		{
			_agencia.Remover( objeto );
		}

		public Agencia Selecionar(string nome)
		{
			return _agencia.Selecionar( nome );
		}

		public List<Agencia> SelecionarTudo()
		{
			return _agencia.SelecionarTudo();
		}
	}
}
