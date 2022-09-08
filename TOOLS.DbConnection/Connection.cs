using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace TOOLS.DbConnection
{
    public class Connection {

        private readonly string _ConnectionString;
        private readonly DbProviderFactory _Factory;

        public Connection(string invariantName, string connectionString) {
            _ConnectionString = connectionString;
            _Factory = DbProviderFactories.GetFactory(invariantName);
        }

        private IDbCommand CreateCommand(IDbConnection connection, Command command) {

            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandText = command.Query;
            cmd.CommandType = command.IsStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            foreach (var v in command.Parameters) {
                IDbDataParameter p = _Factory.CreateParameter()!;
                p.ParameterName = v.Key;
                p.Value = v.Value;
                cmd.Parameters.Add(p);
            }
            return cmd;
        }

        private IDbConnection CreateConnection() {
            IDbConnection? connection = _Factory.CreateConnection();

            if (connection is null) throw new InvalidOperationException();

            connection.ConnectionString = _ConnectionString;

            return connection;
        }

        public object? ExecuteScalar(Command command) {
            using (IDbConnection dbConnection = CreateConnection()) {
                using (IDbCommand dbCommand = CreateCommand(dbConnection, command)) {

                    dbConnection.Open();

                    object? result = dbCommand.ExecuteScalar();
                    return result is DBNull ? null : result;
                }
            }
        }

        public int ExecuteNonQuery(Command command) {
            using (IDbConnection dbConnection = CreateConnection()) {
                using (IDbCommand dbCommand = CreateCommand(dbConnection, command)) {

                    dbConnection.Open();
                    return dbCommand.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetDataTable(Command command) {
            using (IDbConnection dbConnection = CreateConnection()) {
                using (IDbCommand dbCommand = CreateCommand(dbConnection, command)) {

                    IDbDataAdapter dataAdapter = _Factory.CreateDataAdapter()!;
                    dataAdapter.SelectCommand = (DbCommand)dbCommand;

                    DataSet dataSet = new DataSet();

                    dataAdapter.Fill(dataSet);

                    return dataSet.Tables["Table"];
                }
            }
        }


        public IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<IDataRecord, TResult> mapper) {
            using (IDbConnection dbConnection = CreateConnection()) {
                using (IDbCommand dbCommand = CreateCommand(dbConnection, command)) {

                    dbConnection.Open();

                    using (IDataReader dataReader = dbCommand.ExecuteReader()) {
                        while (dataReader.Read()) {

                            yield return mapper(dataReader);

                        }
                    }
                }
            }
        }
    }
}