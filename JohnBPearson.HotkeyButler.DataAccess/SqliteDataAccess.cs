using System.Collections;
using System.Data;
using System.Data.SQLite;
using System.Threading;
using Extension;

namespace JohnBPearson.HotkeyButler.DataAccess
{
    public struct ApplicationDataRow
    {

    }

    public class SqliteDataAccess
    {

        public static DataTable Read(string selectText)
        {
            DataTable dt = new DataTable();
            var reader = SqliteDataAccess.ExecuteReader(selectText);
            while(reader.Read())
            {
                var schemaTable = reader.GetSchemaTable();
                if(dt.Rows.Count == 0)
                {
                    foreach(DataRow row in schemaTable.Rows)
                    {
                        dt.Columns.Add(row[0].ToString());
                    }
                }
                ArrayList rowValues = new ArrayList();
                rowValues.Add(reader["TargetId"]);
                rowValues.Add(reader["AssemblyName"]);
                rowValues.Add(reader["ProjectPropertiesPath"]);

                rowValues.Add(reader["VersionId"]);
                rowValues.Add(reader["TargetApplication"]);
                rowValues.Add(reader["Major"]);
                rowValues.Add(reader["Minor"]);
                rowValues.Add(reader["Build"]);
                rowValues.Add(reader["Revision"]);
                //  NameValueCollection values = reader.GetValues();
                //System.Diagnostics.Trace( values.
                dt.Rows.Add(rowValues.ToArray());
                System.Diagnostics.Debugger.Log(1, "schema table", schemaTable.TableName);


                // reader.

                //                Console.WriteLine($"Hello, {name}!");
            }
            return dt;
        }
        protected static void initializeConnectionString()
        {
            if(common_conn == null)
            {
                SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
                builder.ConnectionString = Properties.Settings.Default.sqlitConnectionString;
                builder.ForeignKeys = true;
                builder.FailIfMissing = true;
              //  SqliteDataAccess.common_conn = new SQLiteConnection();
            common_conn = new SQLiteConnection(builder.ConnectionString);
            }
        }
        protected static string ConnectionString
        {
            get
            {
                return Properties.Settings.Default.sqlitConnectionString;

            }
        }
        protected static SQLiteConnection common_conn = null;
        protected static SQLiteTransaction common_transaction = null;
        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, params object[] p)
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
        private static void PrepareCommand2(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, params object[] p)
        {
            if(conn.State != ConnectionState.Open)
                conn.Open();
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
        public static int ExecuteNonQuery(string cmdText, params object[] p)
         {
            SqliteDataAccess.initializeConnectionString();
            if(common_conn != null)
            {

               // common_conn = new SQLiteConnection(ConnectionString);
                //using (SqliteConnection conn = new SqliteConnection(ConnectionString)) {
                using(SQLiteCommand command = new SQLiteCommand())
                {
                    PrepareCommand(command, common_conn, cmdText, p);
                    return command.ExecuteNonQuery();
                }
            }
            return -1;
        }
        protected static int ExecuteNonQuery2(string cmdText, params object[] p)
        {
            //if (common_conn == null) common_conn = new SQLiteConnection(ConnectionString);
            using(SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                using(SQLiteCommand command = new SQLiteCommand())
                {
                    PrepareCommand2(command, conn, cmdText, p);
                    return command.ExecuteNonQuery();
                }
            }
        }
        protected static SQLiteDataReader ExecuteReader(string cmdText, params object[] p)
        {
            //QLitePCL. Batteries.Init();
            SqliteDataAccess.initializeConnectionString();
            SQLiteCommand command = new SQLiteCommand();
            PrepareCommand(command, common_conn, cmdText, p);
            return command.ExecuteReader(CommandBehavior.CloseConnection);

        }
        protected static SQLiteDataReader ExecuteReader2(string cmdText, params object[] p)
        {
            SqliteDataAccess.initializeConnectionString();
            //if (common_conn == null) common_conn = new SQLiteConnection(ConnectionString);
           // SQLiteConnection conn = new SQLiteConnection(ConnectionString);
            SQLiteCommand command = new SQLiteCommand();
            PrepareCommand2(command, common_conn, cmdText, p);
            return command.ExecuteReader(CommandBehavior.CloseConnection);

        }
        //public static string ExecuteScalar(string cmdText, params object[] p) {
        //    using (SQLiteConnection conn = new SQLiteConnection(ConnectionString)) {
        //        using (SQLiteCommand command = new SQLiteCommand()) {
        //            PrepareCommand(command, conn, cmdText, p);
        //            return (string)command.ExecuteScalar();
        //        }
        //    }
        //}
        protected static int UpdatePassword(string newPassword)
        {
            using(var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using(var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT quote($newPassword);";
                    command.Parameters.AddWithValue("$newPassword", newPassword);
                    var quotedNewPassword = command.ExecuteScalar() as string;
                    command.CommandText = "PRAGMA rekey = " + quotedNewPassword;
                    command.Parameters.Clear();
                    int x = command.ExecuteNonQuery();
                    return x;
                }
            }
        }

  
    }
}
