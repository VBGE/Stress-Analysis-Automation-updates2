using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Entity.Core.Common.CommandTrees;


namespace MyCAD
{
    public static class SQLiteScript
    {
        static string lConnectionString;
        static string lPath;
        static string lFullPath;
        static string lConnectionParams;

        // Static constructor to initialize static variables
        static SQLiteScript()
        {
            lConnectionString = ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString;
            lPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            lFullPath = Path.Combine(lPath, lConnectionString);
            lConnectionParams = ConfigurationManager.AppSettings["SQLiteParams"];
            lConnectionString = string.Format(lConnectionParams, lFullPath);
        }

        //private static string lConnectionString = @"DataSource = C:\Users\223139002\source\repos\Stress-Analysis-Automation\MyCAD\SQLite\Files\AppTables.db; Version = 3;";
        public static void createTablesFromCSV(string csvPath)
        {
            string[] lines = File.ReadAllLines(csvPath);
            var tables = new Dictionary<string, List<string[]>>();

            foreach (var line in lines)
            {
                //var item = line.Split(new char[] { ',' }, 2);
                var item = line.Split(',');
                string tableName = item[0];
                var columnDefinitions = item.Skip(1).ToArray();
                columnDefinitions = columnDefinitions.Where(s => !string.IsNullOrEmpty(s)).ToArray();

                if (!tables.ContainsKey(tableName))
                {
                    tables[tableName] = new List<string[]>();
                }
                tables[tableName].Add(columnDefinitions);
            }
            using (SQLiteConnection connection = new SQLiteConnection(lConnectionString))
            {
                connection.Open();

                foreach (var table in tables)
                {
                    string values = "";
                    var tableQuery = tables[table.Key][0];

                    foreach (var value in tableQuery)
                    {
                        if (Array.IndexOf(tableQuery, value) == 0)
                        {
                            values = value;
                        }

                        else
                        {
                            values = values + ',' + value;
                        }
                    }

                    string createTableQuery = $"CREATE TABLE IF NOT EXISTS \"{table.Key}\" ({values});";

                    using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        public static List<string> GetTableNames()
        {
            var tableNames = new List<string>();

            using (var connection = new SQLiteConnection(lConnectionString))
            {
                connection.Open();
                string query = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tableNames.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return tableNames;
        }

        public static List<string> GetTableColumns(string tableName)
        {
            using (SQLiteConnection conn = new SQLiteConnection(lConnectionString))
            {
                conn.Open();
                var columnNames = new List<string>();
                string query = $"PRAGMA table_info({tableName});";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnNames.Add(reader.GetString(1));
                        }
                    }
                }
                return columnNames;
            }
        }

        public static void AddTableValuesToDB(string [] values)
        {
            using (SQLiteConnection connection = new SQLiteConnection(lConnectionString))
            {
                connection.Open();

                var tableNames = GetTableNames();
                string tableName = tableNames[0];
                var columnList = GetTableColumns(tableName);
                string columnNames =string.Join(",",columnList);
                string placeHolders = string.Join(",", columnList.Select((_,index) => $"@value{index}"));

                string lQueryValue = $@"INSERT INTO {tableName} ({columnNames}) VALUES ({placeHolders}) ";
                using (var insertCommand = new SQLiteCommand(lQueryValue,connection)) 
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        insertCommand.Parameters.AddWithValue($"@value{i}", values[i]);
                    }
                    insertCommand.ExecuteNonQuery();
                }
            }
        }

    }
}
