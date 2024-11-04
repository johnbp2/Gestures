using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;

namespace JohnBPearson.HotkeyButler.DataAccess
{
    public static class SqliteWrapperFactory
    {
        public static SqliteWrapper create(string path)
        {

            return new SqliteWrapper(path);

        }

    }

    public class SqliteWrapper
    {
        internal SqliteWrapper(string file) { 
        Microsoft.Data.Sqlite.SqliteConnection connection = null;
            Microsoft.Data.Sqlite.SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
            builder.DataSource = file;
            
           connection = new Microsoft.Data.Sqlite.SqliteConnection(builder.ConnectionString);
            using(var com = new Microsoft.Data.Sqlite.SqliteCommand())
            {
            
            }
                
                
                
                }


        private static void PrepareCommand(SqliteCommand cmd, SqliteConnection conn, string cmdText, params object[] p)
        {
            if(conn.State != ConnectionState.Open)
                conn.Open();
            if(common_transaction != null)
                cmd.Transaction = common_transaction;
            cmd.Parameters.Clear();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 30;
            if(p != null)
            {
                int index = 0;
                while(index < p.Length)
                {
                    cmd.CommandText = cmd.CommandText.ReplaceOne("?", "$t" + index.ToString());
                    index++;
                }
                index = 0;
                foreach(object parm in p)
                {
                    cmd.Parameters.AddWithValue("$t" + index.ToString(), parm);
                    index++;
                }
            }
            cmd.Prepare();
        }
    }

    


\}

