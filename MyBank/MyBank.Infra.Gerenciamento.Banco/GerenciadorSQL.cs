using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MyBank.Dominio.Interfaces;
using MyBank.Dominio.objetos;

namespace MyBank.Infra.Gerenciamento.Banco
{
    public class GerenciadorSQL : IGerenciadorSQL<Agencia>, IGerenciadorSQL<Conta>, IGerenciadorSQL<Pessoa>
    {
        private readonly SqlConnection _connection = new SqlConnection();
        private SqlTransaction _transaction;
        private const string ConnectionString = @"Data Source=tescon20800-1\sql2016;Initial Catalog=mybank;Persist Security Info=True;User ID=sa;Password=Nddadm!@#$%;";

        public GerenciadorSQL(SqlTransaction transaction)
        {
            _transaction = transaction;
            _connection.ConnectionString = ConnectionString;
        }

        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }

        public object ExecuteCommand(string query, IEnumerable<SqlParameter> parameters)
        {
            OpenConnection();

            var command = new SqlCommand { CommandText = query, Connection = _connection, CommandTimeout = 60000 };

            if (_transaction != null)
                command.Transaction = _transaction;

            if (parameters != null)
                foreach (var parameter in parameters)
                    command.Parameters.Add(parameter);

            var result = command.ExecuteScalar();

            CloseConnection();

            return result;
        }

        public DataSet SelectRegisters(string query, IEnumerable<SqlParameter> parameters)
        {
            OpenConnection();

            var command = new SqlCommand {CommandText = query, Connection = _connection, CommandTimeout = 60000};

            if (_transaction != null)
                command.Transaction = _transaction;

            if (parameters != null)
                foreach (var parameter in parameters)
                    command.Parameters.Add(parameter);

            var dataAdapter = new SqlDataAdapter(command);

            var dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            CloseConnection();

            return dataSet;
        }
        public List<T> SelectRegistersObject<T>(string query, IEnumerable<SqlParameter> parameters, Func<DataRow, T> convert)
        {
            OpenConnection();

            var command = new SqlCommand { CommandText = query, Connection = _connection, CommandTimeout = 60000 };

            if (_transaction != null)
                command.Transaction = _transaction;

            if (parameters != null)
                foreach (var parameter in parameters)
                    command.Parameters.Add(parameter);

            var dataAdapter = new SqlDataAdapter(command);

            var dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            CloseConnection();

            return ConvertValues(convert, dataSet);
        }

        private List<T> ConvertValues<T>(Func<DataRow, T> convert, DataSet dataSet)
        {
            List<T> lista = new List<T>();

            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                lista.Add(convert.Invoke(dataSet.Tables[0].Rows[i]));

            return lista;
        }
    }
}
