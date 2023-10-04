using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DataAccess
{
    public class DBContext
    {
        // get string connection
        public static string GetConnection()
        {
            string connectionString;
            string projectName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName).Split(new string[] { ".exe" }, StringSplitOptions.None)[0];
            var currentDirectory = Directory.GetCurrentDirectory();
            var basePath = currentDirectory.Split(new string[] { "\\" + projectName }, StringSplitOptions.None)[0];
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(basePath + @"\BussinessObject")
                .AddJsonFile("appsetting.json", true, true)
                .Build();
            connectionString = config["ConnectionString:MyDB"]; 

            // way 2 to connect db

            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //            .AddJsonFile("appsettings.json")
            //            .Build();
            //string connectionString = configuration.GetConnectionString("MyDB");

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
