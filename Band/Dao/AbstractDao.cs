using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Band.Util;
using System.Collections.ObjectModel;
using System.Web.Script.Serialization;
using System.Text;
using System.Reflection;

namespace Band.Dao
{
    public class AbstractDao<T> : IAbstractDao<T>
    {
        private Type dbName;

        private DbConnectionUtil util = new DbConnectionUtil();

        public AbstractDao()
        {
            dbName = GetDbTType();
        }

        private Type GetDbTType()
        {
            Type DbTType = typeof(T);

            while (DbTType != null)
            {
                if (DbTType.Name.EndsWith("DbItem")) return DbTType;
                DbTType = DbTType.BaseType;
            }

            throw new Exception("no DbItem found");
        }


        private string ExecuteQuery(string query, object param)
        {
            return "";
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public int insert(T item)
        {
            int result = 0;

            var dic = GetDic(item);
            var table = dbName.Name.Split("DbItem")[0];
            var columns = string.Join(",", dic.Select(t => t.Key));
            var values = string.Join(",", dic.Select(t =>
            {
                if (t.Value.GetType().IsNumeric()) return t.Value.ToString();
                return $"'{t.Value.ToString()}'";
            }));
            var q = $"INSERT INTO [{table}] ({columns}) VALUES ({values})";
            result = InsertConnection(q);


            //var keyValue = GetColumnNameList(item);
            //var dict1 = new JavaScriptSerializer().Deserialize<dynamic>(keyValue[0]);
            //var dict2 = new JavaScriptSerializer().Deserialize<dynamic>(keyValue[1]);

            //string columnString = ConvertArrayToString(dict1, Int32.Parse(keyValue[2]));
            //string valueString = ConvertArrayToValueString(dict2, Int32.Parse(keyValue[2]));

            //string query = @"INSERT INTO [" + dbName.Name.Split("DbItem")[0] + "] (" + columnString + ") " +
            //                          "VALUES(" + valueString + ")";

            ////Item에서 컬럼 일일이 빼올 수 있게 만들기
            //result = InsertConnection(query);
            return result;
        }

        private Dictionary<string, object> GetDic<T>(T item)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (prop.Name.Equals("Id", StringComparison.OrdinalIgnoreCase)) continue;
                if (prop.Name.Equals("Regdate", StringComparison.OrdinalIgnoreCase)) continue;

                rtn[prop.Name] = prop.GetValue(item);
            }
            return rtn;
        }

        private string ConvertArrayToString(Object[] dict, int count)
        {
            string last;
            IList<string> param = new List<string>();
            for (var i = 0; i < count; i++)
            {
                last = dict[i].ToString();
                param.Add(last);
            }
            return string.Join(",", param);
        }

        private string ConvertArrayToValueString(Object[] dict, int count)
        {
            string last;
            IList<string> param = new List<string>();
            for (var i = 0; i < count; i++)
            {
                last = dict[i].ToString();
                param.Add($"'{last}'");
            }
            return string.Join(",", param);
        }

        public T read(int id)
        {
            throw new NotImplementedException();
        }

        public void update(T item)
        {
            throw new NotImplementedException();
        }

        private List<string> GetColumnNameList(T item)
        {
            List<string> result = new List<string>();
            var one = item.ConvertToDictionary();
            var a = one.Keys.ToJson();
            var b = one.Values.ToJson();
            var c = "" + one.Count;
            result.Add(a);
            result.Add(b);
            result.Add(c);
            return result;
        }

        public string readStoredFileNameColumn(int id)
        {
            string result = "";

            string query = @"SELECT storedfilename
                                      FROM [File]
                                      WHERE id = " + id;

            return result;
        }

        public List<string> getColumnListByValue()
        {
            List<string> result = new List<string>();
            string query = @"select storedfilename  from [file] where id < 31";
            SqlDataReader reader = Connection(query);
            result = GetStringList(reader);
            return result;
        }

        private SqlDataReader Connection(string query)
        {
            SqlConnection connection = new SqlConnection("SERVER=192.168.1.76;DATABASE=StudyBand;USER ID=sa; PASSWORD=ad!@#0");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        private int InsertConnection(string query)
        {
            SqlConnection connection = new SqlConnection("SERVER=192.168.1.76;DATABASE=StudyBand;USER ID=sa; PASSWORD=ad!@#0");
            int newIndex;
            connection.Open();
            var tran = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Transaction = tran;
                newIndex = Convert.ToInt32(command.ExecuteScalar());
                tran.Commit();
                tran.Dispose();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                tran.Rollback();
                tran.Dispose();
                throw e;
            }


            return newIndex;
        }

        private List<string> GetStringList(SqlDataReader reader)
        {
            List<string> result = new List<string>();
            while (reader.Read())
            {
                string item = reader.GetString(0);
                result.Add(item);
            }
            return result;
        }

        /*
         1. 인젝션
         - 변수의 ADO.NET IDbParameter

         2. 트랜잭션
         - MSSQL - Commit 안하면 자동 롤백
         */
    }
}