using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Data.Core.Repositories
{
    public class BaseRepository
    {
        private string _connectionString;

        public BaseRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        protected SqlConnection OpenConnection(string connectionString = null)
        {
            var connection = new SqlConnection(connectionString ?? _connectionString);
            connection.Open();
            return connection;
        }

        protected IEnumerable<dynamic> Query(string sql, object param)
        {
            IEnumerable<dynamic> result;
            using (var connection = OpenConnection())
            {
                result = Query(connection, sql, param);
            }
            return result;
        }

        protected IEnumerable<dynamic> Query(SqlConnection connection, string sql, object param)
        {
            return connection.Query(sql, param);
        }

        protected IEnumerable<T> Query<T>(string sql, object param)
        {
            IEnumerable<T> result;
            using (var connection = OpenConnection())
            {
                result = Query<T>(connection, sql, param);
            }
            return result;
        }

        protected IEnumerable<T> Query<T>(SqlConnection connection, string sql, object param)
        {
            return connection.Query<T>(sql, param);
        }

        protected T QueryFirst<T>(string sql, object param)
        {
            T result;
            using (var connection = OpenConnection())
            {
                result = QueryFirst<T>(connection, sql, param);
            }
            return result;
        }

        protected T QueryFirst<T>(SqlConnection connection, string sql, object param)
        {
            return connection.QueryFirst<T>(sql, param);
        }

        protected T QueryFirstOrDefault<T>(string sql, object param)
        {
            T result;
            using (var connection = OpenConnection())
            {
                result = QueryFirstOrDefault<T>(connection, sql, param);
            }
            return result;
        }

        protected T QueryFirstOrDefault<T>(SqlConnection connection, string sql, object param)
        {
            return connection.QueryFirstOrDefault<T>(sql, param);
        }

        protected int Execute(string sql, object param)
        {
            using (var connection = OpenConnection())
            {
                return Execute(connection, sql, param);
            }
        }

        protected int Execute(SqlConnection connection, string sql, object param)
        {
            return connection.Execute(sql, param);
        }

        protected string ConcatWhere(List<string> where)
        {
            switch (where.Count)
            {
                case 0:
                    return "";
                case 1:
                    return $"where {where[0]}";
                default:
                    return $"where {where.Aggregate((i, j) => i + "and " + j)}";
            }
        }
    }

}
