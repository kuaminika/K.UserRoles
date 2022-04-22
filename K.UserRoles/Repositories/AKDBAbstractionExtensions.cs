using KDBAbstractions.Repository;
using MySql.Data.MySqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using KDBAbstractions.Repository.interfaces;

namespace K.UserRoles.Repositories
{
    public static class AKDBAbstractionExtensions
    {
        public static int ExecuteInsertTransaction<T>( this AKDBAbstraction abstraction,string query, T newRecord)
        {

            MySqlConnection conn = new MySqlConnection(abstraction.ConnectionString);
           
            string lastInsertSelect = "select LAST_INSERT_ID();";
            query = $@"{query} ; {lastInsertSelect} ";
            int result = conn.ExecuteScalar<int>(query, newRecord);
            return result;
        }


        public static List<T> ExecuteReadTransaction<T>(this AKDBAbstraction abstraction, string query, T QueryObj)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(abstraction.ConnectionString);
                var yielded = conn.Query<T>(query, QueryObj);
                List<T> result = yielded == null ? new List<T>() : yielded.AsList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static T GetQueryHolder<T>(this AKDBAbstraction abstraction )
        {
            T result =(T) Activator.CreateInstance(typeof(T));
            return result;
        }


    }
}
