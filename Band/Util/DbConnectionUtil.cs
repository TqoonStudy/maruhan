using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Band.Util
{
    public class DbConnectionUtil
    {
        private static string connectionString = "SERVER=192.168.1.76;DATABASE=StudyBand;USER ID=sa; PASSWORD=ad!@#0";

        public IList<T> GetListQuery<T>(string query) where T : class, new()
        {
            IList<T> result = new List<T>();
            ExecuteQuery<T>(query);

            return null;
        }


        private void ExecuteQuery<T>(string query) where T : class, new()
        {
            CommandAndRead<T>(DbConnection(),query);

        }
        private SqlConnection DbConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            con.Open();
            return con;
        }

        private void CommandAndRead<T>(SqlConnection con, string query) where T : class, new()
        {
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            IList<T> list = new List<T>();
            int fieldCnt = reader.FieldCount;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    T item = new T();
                    for(int columnIndex = 0; columnIndex < reader.FieldCount; columnIndex++)
                    {
                        var objectProperty = GetTargetProperty<T>(reader.GetName(columnIndex));
                        if(objectProperty!= null)
                        {
                            var dataValue = reader.GetValue(columnIndex);
                            if(objectProperty.PropertyType == typeof(List<int>))
                            {
                                objectProperty.SetValue(item, DBNull.Value.Equals(dataValue) ? null :
                                    dataValue.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i.Trim())).ToList<int>());
                            }
                            else
                            {
                                objectProperty.SetValue(item, DBNull.Value.Equals(dataValue) ? null : dataValue);
                            }
                        }
                    }
                }
            }
        }

        private static PropertyInfo GetTargetProperty<T>(string name)
        {
            return typeof(T).GetProperties()
                            .Where(p => p.GetCustomAttributes(typeof(DataBind), true)
                                .Where(a => ((DataBind)a).ColumnName == name)
                                .Any()
                                ).FirstOrDefault();
        }
    }

    public class DataBind : Attribute
    {
        #region Fields
        private string columnName;
        #endregion

        #region Properties
        public string ColumnName
        {
            get
            {
                return this.columnName;
            }
            set
            {
                this.columnName = value;
            }
        }
        #endregion

        #region Constructors
        public DataBind(string columnName)
        {
            this.columnName = columnName;
        }
        #endregion
    }
}