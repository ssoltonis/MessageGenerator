using System;
using System.Data.OleDb;
using System.Configuration;
using MessageGeneratorApp.DataModels;
using System.Threading;

namespace MessageGeneratorApp.DAL
{
    public class AccessDb
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["AccessDBConnection"].ConnectionString;

        private OleDbConnection _conn;

        private static Mutex mutex = new Mutex();

        /// <summary>
        /// Konstruktorius
        /// </summary>
        public AccessDb()
        {
            _conn = new OleDbConnection(_connectionString);
        }
        
        public bool CreateTable()
        {
            try
            {
                var sql = @"CREATE TABLE Messages (
                    [ID] AUTOINCREMENT NOT NULL PRIMARY KEY,
                    [ThreadId] NUMBER NOT NULL,
                    [Time] VARCHAR(20) NOT NULL,
                    [Data] VARCHAR(40) NOT NULL)";
                
                using (OleDbCommand cmd = new OleDbCommand(sql, _conn))
                {
                    _conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (_conn != null) _conn.Close();
            }

            return true;
        }

        public bool InsertNewRecord(MessageData message)
        {
            try
            {
                mutex.WaitOne();

                var sql = @"INSERT INTO Messages ([ThreadId], [Time], [Data]) VALUES (@ThreadId, @Time, @Data);";
                using (OleDbCommand cmd = new OleDbCommand(sql, _conn))
                {
                    cmd.Parameters.Add(new OleDbParameter("@ThreadId", message.ThreadID.ToString()));
                    cmd.Parameters.Add(new OleDbParameter("@Time", message.Time.ToString()));
                    cmd.Parameters.Add(new OleDbParameter("@Data", message.Message));

                    _conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (_conn != null) _conn.Close();
                mutex.ReleaseMutex();
            }
            return true;
        }
        
    }
}
