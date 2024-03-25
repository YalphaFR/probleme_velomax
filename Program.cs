using probleme_velomax.database;
using probleme_velomax.structures;
using System;
using System.Collections.Generic;

namespace probleme_velomax {
    internal class Program {
        private static readonly ConsoleKey charaToStopMenu = ConsoleKey.Escape;
        static void Main() {
            try {
                DataBase.Connection.Open();
                Menu();
                DataBase.Connection.Close();
            } catch (Exception e) {
                Console.Error.WriteLine(e.Source);
                Console.Error.WriteLine(e.Message);
            }
        }

        public static void Menu() {
            ConsoleKeyInfo cki = new ConsoleKeyInfo(' ', ConsoleKey.LeftArrow, false, false, false);
            do {
                try {
                    Console.Clear();
                    Console.WriteLine("Bienvenue dans la base de donnée de l'entreprise VéloMax !\n\n\n");
                    Console.WriteLine("Menu : " +
                        "\n1. Gestion des pièces de rechanges et Gestion des vélos " +
                        "\n2. Gestion des clients particuliers et des clients Entreprise" +
                        "\n3. Gestion des fournisseurs" +
                        "\n4. Gestion des commandes" +
                        "\n5. Gestion des employés" +
                        "\n6. Gestion des magasins" +
                        "\n7. Statistiques" +
                        "\n8. Démonstration !!!!!!!!!!" +
                        "\n9. Réinitialiser la base de donnée" +
                        "\n\nQue souhaitez-vous consulter ? Veuillez utiliser les touches qui font référencent à des chiffres pour intéragir avec le système.");
                    Dictionary<string, Type> attributs;

                    cki = Console.ReadKey();
                    Console.Clear();

                    switch (cki.Key) {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Console.WriteLine("1. Pièces\n2. Bicyclette");
                            cki = Console.ReadKey();
                            switch (cki.Key) {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                    attributs = new Dictionary<string, Type>() {
                                    {"piece_id", typeof(string) },
                                    {"piece_nom", typeof(string) },
                                    {"piece_date_debut", typeof(DateTime)},
                                    {"piece_date_fin", typeof(DateTime)},
                                    {"piece_prix_unitaire", typeof(decimal)},
                                    {"piece_delai_approvisionnement", typeof(DateTime)}
                                };
                                    new Base("piece", attributs).Menu();
                                    Console.ReadKey();
                                break;

                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    attributs = new Dictionary<string, Type>() {
                                    {"bicyclette_id", typeof(int) },
                                    {"bicyclette_nom", typeof(string) },
                                    {"bicyclette_grandeur", typeof(string)},
                                    {"bicyclette_prix_unitaire", typeof(decimal)},
                                    {"bicyclette_date_debut", typeof(DateTime)},
                                    {"bicyclette_date_fin", typeof(DateTime)},
                                    {"bicyclette_modele", typeof(string)}
                                };
                                    new Base("bicyclette", attributs).Menu();
                                    Console.ReadKey();
                                break;
                            } 
                        break;

                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            Console.WriteLine("1. Particulier\n2. Professionnel");
                            cki = Console.ReadKey();
                            switch (cki.Key) {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                attributs = new Dictionary<string, Type>() {
                                        {"client_particulier_id", typeof(int) },
                                        {"client_particulier_nom", typeof(string) },
                                        {"client_particulier_prenom", typeof(string)},
                                        {"client_particulier_rue", typeof(string)},
                                        {"client_particulier_ville", typeof(string)},
                                        {"client_particulier_code_postal", typeof(string)},
                                        {"client_particulier_province", typeof(string)},
                                        {"client_particulier_courriel", typeof(string)},
                                        {"client_particulier_tel", typeof(string)},
                                        {"client_particulier_date_adhesion", typeof(DateTime)},
                                        {"programme_id", typeof(int)}
                                    };
                                new Base("client_particulier", attributs).Menu();
                                Console.ReadKey();
                                break;

                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    attributs = new Dictionary<string, Type>() {
                                    {"client_entreprise_id", typeof(int) },
                                    {"client_entreprise_nom", typeof(string) },
                                    {"client_entreprise_rue", typeof(string)},
                                    {"client_entreprise_ville", typeof(string)},
                                    {"client_entreprise_code_postal", typeof(string)},
                                    {"client_entreprise_province", typeof(string)},
                                    {"client_entreprise_courriel", typeof(string)},
                                    {"client_entreprise_tel", typeof(string)},
                                    {"client_entreprise_nom_contact", typeof(string)}
                                            };
                                new Base("client_entreprise", attributs).Menu();
                                    Console.ReadKey();
                                    break;
                                }
                                Console.ReadKey();
                        break;

                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            attributs = new Dictionary<string, Type>() {
                                {"fournisseur_siret", typeof(int) },
                                {"fournisseur_nom_contact", typeof(string)},
                                {"fournisseur_adresse", typeof(string)},
                                {"fournisseur_nom_entreprise", typeof(string)},
                                {"fournisseur_libelle", typeof(string)}
                            };
                            new Base("fournisseur", attributs).Menu();
                            Console.ReadKey();
                        break;

                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:

                            attributs = new Dictionary<string, Type>() {
                                {"commande_id", typeof(int) },
                                {"commande_adresse_livraison", typeof(string)},
                                {"commande_date", typeof(DateTime)},
                                {"commande_date_livraison", typeof(DateTime)},
                                {"client_particulier_id", typeof(int)},
                                {"client_entreprise_id", typeof(int)},
                                {"magasin_id", typeof(int)},
                                {"employe_id", typeof(int)}
                            };
                                new Base("commande", attributs).Menu();
                                Console.ReadKey();
                        break;

                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                            attributs = new Dictionary<string, Type>() {
                                    {"employe_id", typeof(int) },
                                    {"employe_nom", typeof(string)},
                                    {"employe_prenom", typeof(string)},
                                    {"employe_salaire", typeof(float)},
                                    {"employe_temps_travail", typeof(decimal)},
                                    {"magasin_id", typeof(int)}
                                };
                            new Base("employe", attributs).Menu();
                            Console.ReadKey();
                        break;

                        case ConsoleKey.D6:
                        case ConsoleKey.NumPad6:
                            attributs = new Dictionary<string, Type>() {
                                        {"magasin_id", typeof(int) },
                                        {"magasin_rue", typeof(string)},
                                        {"magasin_ville", typeof(string)},
                                        {"magasin_code_postal", typeof(string)},
                                        {"magasin_province", typeof(string)},
                                        {"magasin_gerant_nom", typeof(string)}
                                    };
                            new Base("magasin", attributs).Menu();
                            Console.ReadKey();
                        break;

                        case ConsoleKey.D7:
                        case ConsoleKey.NumPad7:
                            MenuStatistiques();
                            Console.ReadKey();
                        break;

                        case ConsoleKey.D8:
                        case ConsoleKey.NumPad8:
                            MenuDemo();
                            Console.ReadKey();
                        break;

                        case ConsoleKey.D9:
                        case ConsoleKey.NumPad9:
                            DataBase.CreateDataBaseEnvironment();
                            DataBase.CreateDataEnvironment();
                            Console.WriteLine("Base de donnée réinitialisée");
                            Console.ReadKey();
                        break;
                    }
                } catch (Exception e) {
                    Console.Error.WriteLine(e.Source);
                    Console.Error.WriteLine(e.Message);
                    Console.ReadKey();
                }
            } while (cki.Key != charaToStopMenu);
        }

        public static void MenuStatistiques() {
            ConsoleKeyInfo cki = new ConsoleKeyInfo(' ', ConsoleKey.LeftArrow, false, false, false);
            do {
                Console.Clear();
                Console.WriteLine("1. Produire un rapport statistique présentant les quantités vendues de chaque item qui se trouve dans l’inventaire de VéloMax dans son ensemble, par magasin et par vendeur \n\n2. Produire la liste des membres pour chaque programme d’adhésion.\n\n3. Affichez également la date d’expiration des adhésions \n\n4. Retrouvez-le (ou les) meilleur client en fonction des quantités vendues en nombre de \n\npièces vendues ou en cumul en euros  \n\n5. Faîtes une analyse des commandes : par exemple, moyenne des montants des commandes, moyenne du nombre de pièces ou de vélos par commande. \n\n6. Calcul des bonus des salariés en fonction de la satisfaction client et du CA réalisé par chacun, calcul du bonus moyen");
                cki = Console.ReadKey();
                Console.Clear();
                string query = String.Empty;

                switch (cki.Key) {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        query = "SELECT 'Piece' AS item_type, piece_id, SUM(commander_piece_quantite) AS quantite_vendu, magasin_id, employe_id \r\nFROM piece\r\nNATURAL JOIN commander_piece\r\nNATURAL JOIN magasin\r\nNATURAL JOIN commande\r\nNATURAL JOIN employe\r\nGROUP BY piece_id, magasin_id, employe_id\r\n\r\nUNION\r\n\r\nSELECT 'Bicyclette' AS item_type, bicyclette_id, SUM(commander_bicyclette_quantite) AS quantite_vendu, magasin_id, employe_id \r\nFROM bicyclette\r\nNATURAL JOIN commander_bicyclette\r\nNATURAL JOIN magasin\r\nNATURAL JOIN commande\r\nNATURAL JOIN employe\r\nGROUP BY bicyclette_id, magasin_id, employe_id;";
                    break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        query = "SELECT programme_id, programme_description, client_particulier_nom, client_particulier_prenom FROM client_particulier JOIN programme using (programme_id) ORDER BY programme_id, client_particulier_nom, client_particulier_prenom;\r\n";
                    break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                    query = "SELECT programme_id, programme_description, client_particulier_nom, client_particulier_prenom, client_particulier_date_adhesion, DATE_ADD(client_particulier_date_adhesion, INTERVAL programme_duree YEAR) AS date_expiration\r\nFROM programme\r\nJOIN client_particulier USING (programme_id)\r\nORDER BY programme_id, client_particulier_nom, client_particulier_prenom;";
                    break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                    query = "(SELECT \"Particulier\" AS client_type,\r\n    client_particulier_id AS client_id,\r\n    SUM(commander_piece.commander_piece_quantite * piece.piece_prix_unitaire + commander_bicyclette.commander_bicyclette_quantite * bicyclette.bicyclette_prix_unitaire) AS montant_total_euros\r\n\tFROM client_particulier\r\n\tJOIN commande USING (client_particulier_id)\r\n\tJOIN commander_piece USING(commande_id)\r\n\tJOIN piece USING (piece_id)\r\n\tJOIN commander_bicyclette USING(commande_id)\r\n\tJOIN bicyclette USING (bicyclette_id)\r\n\tGROUP BY client_particulier.client_particulier_id\r\n    \r\n    UNION ALL\r\n    \r\n\tSELECT \"Professionnel\" AS client_type,\r\n    client_entreprise_id AS client_id,\r\n\tSUM(commander_piece.commander_piece_quantite * piece.piece_prix_unitaire + commander_bicyclette.commander_bicyclette_quantite * bicyclette.bicyclette_prix_unitaire) AS montant_total_euros\r\n\tFROM client_entreprise\r\n\tJOIN commande USING (client_entreprise_id)\r\n\tJOIN commander_piece USING(commande_id)\r\n\tJOIN piece USING (piece_id)\r\n\tJOIN commander_bicyclette USING(commande_id)\r\n\tJOIN bicyclette USING (bicyclette_id)\r\n\tGROUP BY client_entreprise.client_entreprise_id) ORDER BY montant_total_euros DESC;";
                    break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                    query = "SELECT \"Bicyclette\" as item_type, AVG(commander_bicyclette_quantite * bicyclette_prix_unitaire) as moyenne_montant, AVG(commander_bicyclette_quantite) as moyenne_quantite_vendu FROM commande\r\nNATURAL JOIN commander_bicyclette\r\nNATURAL JOIN bicyclette\r\n\r\nUNION ALL\r\n\r\nSELECT \"Piece\" as item_type, AVG(commander_piece_quantite * piece_prix_unitaire) as moyenne_montant, AVG(commander_piece_quantite) as moyenne_quantite_vendu FROM commande\r\nNATURAL JOIN commander_piece\r\nNATURAL JOIN piece;";

                    break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                    query = "SELECT employe_id, (AVG(commande_note) * COUNT(*)) as bonus_salarie FROM commande JOIN employe USING (employe_id) GROUP BY employe_id ORDER BY employe_id ASC;";
                    break;
                }
                Console.WriteLine(DataBase.SendQueryCommand(query));
                Console.ReadKey();
            } while (cki.Key != charaToStopMenu);
        }

        public static void MenuDemo() {
            ConsoleKeyInfo cki = new ConsoleKeyInfo(' ', ConsoleKey.LeftArrow, false, false, false);
            do {
                Console.Clear();
                Console.WriteLine("");
                Console.Clear();


                Console.WriteLine("1. Particulier\n2. Professionnel");
                cki = Console.ReadKey();
                Dictionary<string, Type> attributs;
                Console.Clear();

                switch (cki.Key) {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        attributs = new Dictionary<string, Type>() {
                                            {"client_particulier_id", typeof(int) },
                                            {"client_particulier_nom", typeof(string) },
                                            {"client_particulier_prenom", typeof(string)},
                                            {"client_particulier_rue", typeof(string)},
                                            {"client_particulier_ville", typeof(string)},
                                            {"client_particulier_code_postal", typeof(string)},
                                            {"client_particulier_province", typeof(string)},
                                            {"client_particulier_courriel", typeof(string)},
                                            {"client_particulier_tel", typeof(string)},
                                            {"client_particulier_date_adhesion", typeof(DateTime)},
                                            {"programme_id", typeof(int)}
                                        };
                        new Base("client_particulier", attributs).Creer().Modifier().Supprimer().Afficher(" COUNT(*) ");
                    break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        attributs = new Dictionary<string, Type>() {
                                        {"client_entreprise_id", typeof(int) },
                                        {"client_entreprise_nom", typeof(string) },
                                        {"client_entreprise_rue", typeof(string)},
                                        {"client_entreprise_ville", typeof(string)},
                                        {"client_entreprise_code_postal", typeof(string)},
                                        {"client_entreprise_province", typeof(string)},
                                        {"client_entreprise_courriel", typeof(string)},
                                        {"client_entreprise_tel", typeof(string)},
                                        {"client_entreprise_nom_contact", typeof(string)}
                                                };
                        new Base("client_entreprise", attributs).Creer().Modifier().Supprimer().Afficher(" COUNT(*) ");
                    break;
                }
                Console.ReadKey();


                Console.Clear();
                Console.WriteLine("4) Noms des clients avec le cumul de toutes ses commandes en euros \n\n\n");
                Console.WriteLine(
                            DataBase.SendQueryCommand(
                                "SELECT \r\n    CONCAT(UPPER(client_particulier.client_particulier_nom), ' ', client_particulier.client_particulier_prenom) AS nom_client,\r\n    SUM(commander_piece.commander_piece_quantite * piece.piece_prix_unitaire + commander_bicyclette.commander_bicyclette_quantite * bicyclette.bicyclette_prix_unitaire) AS montant_total_euros\r\nFROM \r\n    client_particulier\r\nJOIN \r\n    commande ON client_particulier.client_particulier_id = commande.client_particulier_id\r\nJOIN \r\n    commander_piece ON commande.commande_id = commander_piece.commande_id\r\nJOIN \r\n    piece ON commander_piece.piece_id = piece.piece_id\r\nJOIN \r\n    commander_bicyclette ON commande.commande_id = commander_bicyclette.commande_id\r\nJOIN \r\n    bicyclette ON commander_bicyclette.bicyclette_id = bicyclette.bicyclette_id\r\nGROUP BY \r\n    client_particulier.client_particulier_id;"
                                )
                            );
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine("5) Obtenir la liste des produits ayant une quantité en stock inférieure ou égale à 100 \n\n\n");
                Console.WriteLine(
                            DataBase.SendQueryCommand(
                                "SELECT magasin.magasin_id, magasin_rue, magasin_ville, magasin_code_postal, magasin_province, magasin_gerant_nom, \r\n       bicyclette_id AS produit_id, bicyclette_nom AS produit_nom, bicyclette_prix_unitaire AS produit_prix_unitaire, \r\n       referencer_bicyclette_quantite AS quantite_en_stock\r\nFROM magasin\r\nNATURAL JOIN referencer_bicyclette\r\nNATURAL JOIN bicyclette\r\nWHERE referencer_bicyclette_quantite <= 100 UNION SELECT magasin.magasin_id, magasin_rue, magasin_ville, magasin_code_postal, magasin_province, magasin_gerant_nom, \r\n       piece_id AS produit_id, piece_nom AS produit_nom, piece_prix_unitaire AS produit_prix_unitaire,  referencer_piece_quantite AS quantite_en_stock\r\nFROM magasin\r\nNATURAL JOIN referencer_piece NATURAL JOIN piece WHERE referencer_piece_quantite <= 100;"
                                )
                            );
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine("6) Nombres de pièces et/ou vélos fournis par fournisseur \n\n\n");
                Console.WriteLine(
                            DataBase.SendQueryCommand(
                                "SELECT fournir.fournisseur_siret, SUM(fournir_quantite) as Nombre_piece_fournis FROM piece \r\nNATURAL JOIN fournir\r\nNATURAL JOIN fournisseur GROUP BY fournisseur.fournisseur_siret;"
                                )
                            );
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine("7) Le chiffre d’affaires par magasin et les ventes générées par vendeur \n\n\n");
                Console.WriteLine(
                            DataBase.SendQueryCommand(
                                "WITH chiffre_affaires_par_magasin AS (\r\n    SELECT magasin_id, SUM(bicyclette_prix_unitaire * commander_bicyclette_quantite + piece_prix_unitaire * commander_piece_quantite) AS chiffre_affaires\r\n    FROM commande\r\n    JOIN commander_bicyclette ON commande.commande_id = commander_bicyclette.commande_id\r\n    JOIN bicyclette ON commander_bicyclette.bicyclette_id = bicyclette.bicyclette_id\r\n    JOIN commander_piece ON commande.commande_id = commander_piece.commande_id\r\n    JOIN piece ON commander_piece.piece_id = piece.piece_id\r\n    GROUP BY magasin_id\r\n),\r\ntotal_ventes_par_vendeur AS (\r\n    SELECT magasin_id, employe_id, SUM(bicyclette.bicyclette_prix_unitaire * commander_bicyclette.commander_bicyclette_quantite +\r\n    piece.piece_prix_unitaire * commander_piece.commander_piece_quantite) AS total_ventes_vendeur\r\n    FROM employe\r\n    NATURAL JOIN magasin\r\n    NATURAL JOIN commande\r\n    NATURAL JOIN commander_bicyclette\r\n    NATURAL JOIN commander_piece\r\n    NATURAL JOIN bicyclette\r\n    NATURAL JOIN piece\r\n    GROUP BY magasin_id, employe_id\r\n)\r\nSELECT \r\n    magasin_id,\r\n    employe_id,\r\n    chiffre_affaires,\r\n    total_ventes_vendeur\r\nFROM \r\n    chiffre_affaires_par_magasin\r\nJOIN \r\n    total_ventes_par_vendeur USING (magasin_id)\r\nORDER BY \r\n    magasin_id, employe_id;"
                                )
                            );
                Console.ReadKey();
            } while (cki.Key != charaToStopMenu);
        }
    }
}
