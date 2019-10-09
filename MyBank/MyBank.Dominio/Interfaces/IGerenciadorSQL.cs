using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MyBank.Dominio.Interfaces
{
    public interface IGerenciadorSQL<T>
    {
        object ExecuteCommand(string query, IEnumerable<SqlParameter> parameters);
        DataSet SelectRegisters(string query, IEnumerable<SqlParameter> parameters);
        List<T> SelectRegistersObject<T>(string query, IEnumerable<SqlParameter> parameters, Func<DataRow, T> convert);
    }
}
