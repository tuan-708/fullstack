﻿using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace Spending_Web.DataAccess
{
    public class DBContext
    {
        // get string connection
        public static string GetConnection()
        {

            //string connectionString;
            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .Build();
            string connectionString = configuration.GetConnectionString("MyDB");

            return connectionString;
        }

        // create parameter to add command sql
        public static SqlParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            return new SqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Size = size,
                Direction = direction,
                Value = value
            };
        }

        // read Data from db
        public static IDataReader GetDataReader(string commandText, CommandType commandType, string connection, params SqlParameter[] parameters)
        {
            IDataReader reader = null;
            try
            {
                var con = new SqlConnection(connection);
                con.Open();
                var command = new SqlCommand(commandText, con);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
            return reader;
        }

        // command handle delete query sql
        public static void Delete(string commandText, CommandType commandType, string connection, params SqlParameter[] parameters)
        {
            try
            {
                var con = new SqlConnection(connection);
                con.Open();
                var command = new SqlCommand(commandText, con);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Data Provider: Delete Mothod", ex.InnerException);
            }
        }

        // command handle insert query sql
        public static void Insert(string commandText, CommandType commandType, string connection, params SqlParameter[] parameters)
        {
            try
            {
                var con = new SqlConnection(connection);
                con.Open();
                var command = new SqlCommand(commandText, con);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // command handle update query sql
        public static void Update(string commandText, CommandType commandType, string connection, params SqlParameter[] parameters)
        {
            try
            {
                var con = new SqlConnection(connection);
                con.Open();
                var command = new SqlCommand(commandText, con);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
