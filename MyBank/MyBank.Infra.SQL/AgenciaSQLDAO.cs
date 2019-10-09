using System.Collections.Generic;
using System.Data.SqlClient;
using MyBank.Dominio.Interfaces;
using MyBank.Dominio.objetos;

namespace MyBank.Infra.SQL
{
    public class AgenciaSQLDAO : IArmazenamento<Agencia>
    {
        private IGerenciadorSQL<Agencia> _comando;

        private const string QueryInserir = @"INSERT INTO DBO.AGENCIA (CODIGO, NOME, NOME_CIDADE, UF)
	                                                      VALUES (@CODIGO, @NOME, @NOME_CIDADE, @UF)";

        private const string QuerySelecionaId = @"SELECT ID, CODIGO, NOME, NOME_CIDADE, UF FROM [dbo].[Agencia] WHERE NOME = @NOME";

        private const string QuerySelecionaTodos = @"SELECT ID, CODIGO, NOME, NOME_CIDADE, UF FROM [dbo].[Agencia]";

        private const string QueryAtualiza = @"UPDATE [dbo].[Agencia] SET 
                                                        [Codigo] = @CODIGO, 
                                                        [Nome] = @NOME, 
                                                        [Nome_cidade] = @NOME_CIDADE, 
                                                        [UF] = @UF WHERE [ID] = @ID";

        private const string QueryDeleta = @"DELETE FROM [dbo].[Agencia] WHERE NOME = @NOME";


        public AgenciaSQLDAO(IGerenciadorSQL<Agencia> sql)
        {
            _comando = sql;
        }

        public void Cadastrar(Agencia objeto)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@CODIGO", objeto.Codigo));
            listaParametros.Add(new SqlParameter("@NOME", objeto.Nome));
            listaParametros.Add(new SqlParameter("@NOME_CIDADE", objeto.NomeCidade));
            listaParametros.Add(new SqlParameter("@UF", objeto.UF));

            _comando.ExecuteCommand(QueryInserir, listaParametros);
        }

        public void Atualizar(Agencia objetoAntigo, Agencia objetoNovo)
        {
            List<SqlParameter> listaAtualizaAgencia = new List<SqlParameter>();
            listaAtualizaAgencia.Add(new SqlParameter("@CODIGO", objetoNovo.Codigo));
            listaAtualizaAgencia.Add(new SqlParameter("@NOME", objetoNovo.Nome));
            listaAtualizaAgencia.Add(new SqlParameter("@NOME_CIDADE", objetoNovo.NomeCidade));
            listaAtualizaAgencia.Add(new SqlParameter("@UF", objetoNovo.UF));
            listaAtualizaAgencia.Add(new SqlParameter("@ID", objetoAntigo.Id));

            _comando.ExecuteCommand(QueryAtualiza, listaAtualizaAgencia);
        }

        public void Remover(string nome)
        {
            List<SqlParameter> parametrosAgencia = new List<SqlParameter>();
            parametrosAgencia.Add(new SqlParameter("@NOME", nome));

            _comando.ExecuteCommand(QueryDeleta, parametrosAgencia);
        }

        public Agencia Selecionar(string nome)
        {
            List<SqlParameter> parametrosAgencia = new List<SqlParameter>();
            parametrosAgencia.Add(new SqlParameter("@NOME", nome));

            List<Agencia> listaAgencias = _comando.SelectRegistersObject(QuerySelecionaId, parametrosAgencia,
                (x) =>
                    new Agencia()
                    {
                        Id = int.Parse(x.ItemArray[0].ToString()),
                        Codigo = int.Parse(x.ItemArray[1].ToString()),
                        Nome = x.ItemArray[2].ToString(),
                        NomeCidade = x.ItemArray[3].ToString(),
                        UF = x.ItemArray[4].ToString()
                    });




            return null;


        }

        public List<Agencia> SelecionarTudo()
        {
            List<SqlParameter> parametrosAgencia = new List<SqlParameter>();

            List<Agencia> listaAgencias = _comando.SelectRegistersObject(QuerySelecionaTodos, parametrosAgencia,
                (x) =>
                    new Agencia()
                    {
                        Id = int.Parse(x.ItemArray[0].ToString()),
                        Codigo = int.Parse(x.ItemArray[1].ToString()),
                        Nome = x.ItemArray[2].ToString(),
                        NomeCidade = x.ItemArray[3].ToString(),
                        UF = x.ItemArray[4].ToString()
                    });
            
            return listaAgencias;
        }

    }
}
