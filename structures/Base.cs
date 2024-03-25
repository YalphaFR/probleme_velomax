using probleme_velomax.database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace probleme_velomax.structures {
    public class Base {
        private string nomEntite;
        private Dictionary<string, Type> attributsTypes;
        private readonly ConsoleKey charaToStopMenu = ConsoleKey.Escape;

        public Base(string nomEntite, Dictionary<string, Type> attributsTypes) {
            this.nomEntite = nomEntite;
            this.attributsTypes = attributsTypes;
        }

        public void Menu() {
            ConsoleKeyInfo cki = new ConsoleKeyInfo(' ', ConsoleKey.LeftArrow, false, false, false);
            do {
                Console.Clear();
                Console.WriteLine($"Gestionnaire {nomEntite} : " +
                        $"\n1. Afficher {nomEntite}" +
                        $"\n2. Rechercher {nomEntite}" +
                        $"\n3. Créer {nomEntite}" +
                        $"\n4. Supprimer {nomEntite}" +
                        $"\n5. Modifier {nomEntite}" +
                        "\n\nQue souhaitez-vous faire ? Veuillez utiliser les touches qui font référencent à des chiffres pour intéragir avec le système.");
                cki = Console.ReadKey();
                Console.Clear();

                switch (cki.Key) {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                    Afficher();
                    break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                    Rechercher();
                    break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                    Creer();
                    break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                    Supprimer();
                    break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                    Modifier();
                    break;
                }
                Console.ReadKey();
            } while (cki.Key != charaToStopMenu);
        }

        public void Afficher(string selector = "*") {
            Console.WriteLine(DataBase.SendQueryCommand($"SELECT {selector} FROM {this.nomEntite};"));
        }
        public void Rechercher() {
            string[] info = CollecterInfo();
            string query = $"SELECT * FROM {nomEntite} WHERE 1=1" + MakeFacultativeQuery(info, " AND ");
            string res = DataBase.SendQueryCommand(query);
            Console.WriteLine(res);
        }

        public Base Creer() {
            string[] info = CollecterInfo();

            var filters1 = attributsTypes.Keys.Where(key => attributsTypes.ContainsKey(key));
            var filters2 = new List<string>();

            string attributs = string.Join(", ", filters1);

            for (int i = 0; i < info.Length; i++) {
                var value = ConvertValue(info[i], attributsTypes.Values.ToList()[i]);
                filters2.Add(value);
            }
            string valeurs = string.Join(", ", filters2);
            string query = $"INSERT INTO {nomEntite} ({attributs}) VALUES ({valeurs})";
            Console.WriteLine(query);

            DataBase.SendNonQueryCommand(query);
            Console.WriteLine("Création effectuée");
            return this;
        }

        public Base Modifier() {
            string[] info = CollecterInfo();

            var filters = attributsTypes.Keys
                .Where(key => attributsTypes.ContainsKey(key) && !string.IsNullOrEmpty(info[attributsTypes.Keys.ToList().IndexOf(key)]))
                .Select(key => $"{key} = {ConvertValue(info[attributsTypes.Keys.ToList().IndexOf(key)], attributsTypes[key])}");
            string valeurs = string.Join(",", filters);

            string query = $"UPDATE {nomEntite} SET {valeurs} WHERE {attributsTypes.Keys.First()} = {ConvertValue(info[0], attributsTypes.Values.First())}";
            DataBase.SendNonQueryCommand(query);
            Console.WriteLine("Modification effectuée");
            return this;
        }

        public Base Supprimer() {
            string[] info = CollecterInfo();
            string query = $"DELETE FROM {nomEntite} WHERE 1=1" + MakeFacultativeQuery(info, " AND ");
            DataBase.SendQueryCommand(query);
            Console.WriteLine("Suppression effectuée");
            return this;
        }

        public string[] CollecterInfo() {
            string[] res = new string[attributsTypes.Count];
            foreach (var attribut in attributsTypes.Keys) {
                Console.WriteLine(attribut + " ?");
                string input = Console.ReadLine();
                res[attributsTypes.Keys.ToList().IndexOf(attribut)] = input;
            }
            return res;
        }

        public string MakeFacultativeQuery(string[] info, string separator) {
            var filters = attributsTypes.Keys.Where(key => attributsTypes.ContainsKey(key) && !string.IsNullOrEmpty(info[attributsTypes.Keys.ToList().IndexOf(key)]))
                        .Select(key => $"{separator}{key} = {ConvertValue(info[attributsTypes.Keys.ToList().IndexOf(key)], attributsTypes[key])}");
            return string.Join("", filters);
        }

        private string ConvertValue(string value, Type targetType) {
            if (targetType == typeof(DateTime) && string.IsNullOrEmpty(value)) {
                return "NULL";
            } else if (targetType == typeof(DateTime) && !string.IsNullOrEmpty(value)) {
                return $"'{value}'";
            } else if (targetType == typeof(string) && !string.IsNullOrEmpty(value)) {
                return $"'{value}'";
            } else if ((targetType == typeof(string) || targetType == typeof(int)) && string.IsNullOrEmpty(value)) {
                return "NULL";
            }
            return value;
        }
    }
}
