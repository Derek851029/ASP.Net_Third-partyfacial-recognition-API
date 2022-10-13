using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using Dapper;
using System.Data;
using System.Reflection;
public class DBTool
{
    private static string connectionstr = WebConfigurationManager.ConnectionStrings["fg080"].ToString();

    public static IEnumerable<T> Query<T>(string sqlstr, object param = null)
    {
        using (SqlConnection conn = new SqlConnection(connectionstr))
        {
            return conn.Query<T>(sqlstr, param);
        }
    }

    public static IEnumerable<dynamic> Query(string sqlstr, object param = null)
    {
        using (SqlConnection conn = new SqlConnection(connectionstr))
        {
            return conn.Query(sqlstr, param);
        }
    }

    /// <summary>
    /// 建立連線，需要自行做關閉
    /// </summary>
    /// <returns></returns>
    public static IDbConnection GetConn()
    {
        return new SqlConnection(connectionstr);
    }
    public static DataTable LinqQueryToDataTable(IEnumerable<dynamic> v)
    {
        //We really want to know if there is any data at all
        var firstRecord = v.FirstOrDefault();
        if (firstRecord == null)
            return null;

        /*Okay, we have some data. Time to work.*/

        //So dear record, what do you have?
        PropertyInfo[] infos = firstRecord.GetType().GetProperties();

        //Our table should have the columns to support the properties
        DataTable table = new DataTable();

        //Add, add, add the columns
        foreach (var info in infos)
        {

            Type propType = info.PropertyType;

            if (propType.IsGenericType
                && propType.GetGenericTypeDefinition() == typeof(Nullable<>)) //Nullable types should be handled too
            {
                table.Columns.Add(info.Name, Nullable.GetUnderlyingType(propType));
            }
            else
            {
                table.Columns.Add(info.Name, info.PropertyType);
            }
        }

        //Hmm... we are done with the columns. Let's begin with rows now.
        DataRow row;

        foreach (var record in v)
        {
            row = table.NewRow();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                row[i] = infos[i].GetValue(record,null) != null ? infos[i].GetValue(record,null) : DBNull.Value;
                //row[i] = infos[i].GetValue(record) != null ? infos[i].GetValue(record) : DBNull.Value;
            }

            table.Rows.Add(row);
        }

        //Table is ready to serve.
        table.AcceptChanges();

        return table;
    }
}