using System.Collections.Generic;
using MyBank.Aplicacao.Interfaces;
using MyBank.Dominio.Interfaces;
using MyBank.Dominio.objetos;

namespace MyBank.Aplicacao
{
	public class ServicoAgencia : IServico<Agencia>
	{
		private readonly IArmazenamento<Agencia> _agencia;

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

		public void Remover(string nome)
		{
			_agencia.Remover(nome);
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
