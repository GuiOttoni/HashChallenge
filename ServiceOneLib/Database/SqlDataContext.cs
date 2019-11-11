﻿using ServiceOneLib.Database.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOneLib.Database
{
    public class SqlDataContext : ISqlDataContext
    {
        public string ConnectionString { get; private set; }

        public SqlDataContext()
        {
            //Pegar connection string direto do settings;
            ConnectionString = "";
        }

        public async Task<IEnumerable<T>> SelectListAsync<T>(string procedure, Dictionary<string, object> parameters = null)
        {
            List<T> result = new List<T>();
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                using SqlCommand command = CreateCommand(connection, procedure, parameters);
                using SqlDataReader dataReader = await command.ExecuteReaderAsync();
                {
                    result = await QueryToList<T>(dataReader);
                }
            }
            catch
            {
                //add log
            }

            return result;
        }

        public async Task<T> SelectSingleAsync<T>(string procedure, Dictionary<string, object> parameters = null)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                using SqlCommand command = CreateCommand(connection, procedure, parameters);
                using SqlDataReader dataReader = await command.ExecuteReaderAsync();
                {
                    var result = await QueryToList<T>(dataReader);
                    return result.FirstOrDefault();
                }
            }
            catch
            {
                //add log
            }

            return default;
        }

        private SqlCommand CreateCommand(SqlConnection connection, string procedure, Dictionary<string, object> keyValuePairs)
        {
            SqlCommand command = new SqlCommand(procedure, connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            CreateParameters(command, keyValuePairs);

            return command;
        }

        private void CreateParameters(SqlCommand sqlCommand, Dictionary<string,object> keyValuePairs)
        {
            foreach (var item in keyValuePairs)
                sqlCommand.Parameters.AddWithValue(item.Key, item.Value ?? DBNull.Value );
        }

        private async Task<List<T>> QueryToList<T>(SqlDataReader reader)
        {
            Type dataType = GetType<T>();
            
            List<T> result = new List<T>();

            while (await reader.ReadAsync())
            {
                PropertyInfo[] properties = dataType.GetProperties();
                dynamic instance = CreateInstance(dataType);

                IEnumerable<string> dataReaderColuns = GetColumnsName(reader);

                foreach (var prop in properties)
                {
                    if (dataReaderColuns.Contains(prop.Name.ToUpper()))
                    {
                        object value = reader[prop.Name];
                        SetValue(instance, prop, value);
                    }
                }

                result.Add(instance);
            }
            return result;
        }

        private static Type GetType<T>()
        {
            return typeof(T);
        }

        private static object CreateInstance(Type genericType)
        {
            var instance = Activator.CreateInstance(genericType);
            return instance;
        }

        private static IEnumerable<string> GetColumnsName(SqlDataReader sqlDataReader)
        {
            for (int i = 0; i < sqlDataReader.FieldCount; i++)
            {
                yield return sqlDataReader.GetName(i).ToUpper();
            }
        }

        private static void SetValue<T>(T instance, PropertyInfo prop, object value)
        {
            if (!(value is null) && value.GetType() != DBNull.Value.GetType())
            {
                prop.SetValue(instance, value);
            }
        }
    }
}