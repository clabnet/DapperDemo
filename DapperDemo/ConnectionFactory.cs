using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Dapper;

using Npgsql;

namespace DapperDemo
{
    public static class ConnectionFactory
    {

        private static SimpleCRUD.Dialect _dbtype = SimpleCRUD.Dialect.PostgreSQL;

        private static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
            }
        }

        public static IDbConnection GetOpenConnection()
        {
            DbProviderFactory factory;
            IDbConnection connection;
            
            SimpleCRUD.SetDialect(_dbtype);
            
            if (_dbtype == SimpleCRUD.Dialect.PostgreSQL)
            {
                factory = DbProviderFactories.GetFactory("Npgsql");
            }
            else if (_dbtype == SimpleCRUD.Dialect.SQLServer)
            {
                factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            }
            else
                throw new ApplicationException("Please use a Sql Server or PostgreSQL database.");
            
            connection = factory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            connection.Open();

            return connection;
        }

    }
}
