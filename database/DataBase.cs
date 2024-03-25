using MySql.Data.MySqlClient;
using System;

namespace probleme_velomax.database {
    static public class DataBase {
        private static MySqlConnection connection = CreateConnection();

        public static MySqlConnection Connection {
            get { return connection;}
        }

        static public MySqlConnection CreateConnection(bool firstConnection = false) {
            return new MySqlConnection(firstConnection ? Config.firstConnectionString : Config.connectionString);
        }

        static public void CreateDataBaseEnvironment() {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = Config.scriptToCreateDataBaseEnvironment;
            command.ExecuteNonQuery();
        }

        static public void CreateDataEnvironment() {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = Config.scriptToCreateInstanceEnvironment;
            command.ExecuteNonQuery();
        }

        static public void SendNonQueryCommand(string query) {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
        }

        static public string SendQueryCommand(string query) {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            using (MySqlDataReader reader = command.ExecuteReader()) {
                string res = String.Empty;
                for (int i = 0; i < reader.FieldCount; i++) {
                    res += reader.GetName(i).ToUpper().PadRight(200 / (reader.FieldCount));
                }

                // Lecture des autres lignes
                while (reader.Read()) { // parcours ligne par ligne
                    res += "\n";
                    for (int i = 0; i < reader.FieldCount; i++) { // parcours cellule par cellule
                        string valeur = reader.GetValue(i).ToString().PadRight(200/(reader.FieldCount));
                        res += valeur;
                    }
                    //res = res.Substring(0, res.Length - 3);
                }
                return res;
            }
        }
    }

}