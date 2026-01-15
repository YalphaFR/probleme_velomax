# VéloMax – Application de gestion (C# / MySQL)

## 📌 Présentation du projet

Ce projet a été réalisé dans le cadre de mes études en ingénierie. Il consiste en la **conception et le développement complet d’une application de gestion pour l’entreprise fictive VéloMax**, spécialisée dans la vente de vélos et de pièces détachées.

L’objectif principal est de proposer une **solution logicielle robuste et réaliste**, permettant de gérer efficacement les ventes, les clients, les fournisseurs, les salariés et les stocks, tout en s’appuyant sur une **base de données relationnelle MySQL**.

Le projet a été réalisé **en autonomie**, de la modélisation de la base de données jusqu’à l’implémentation applicative et la démonstration fonctionnelle.

---

## 🧩 Fonctionnalités principales

### 🚲 Gestion des vélos et des pièces de rechange

* Création, modification et suppression de vélos
* Création, modification et suppression de pièces détachées
* Gestion des dépendances entre vélos et pièces (assemblage)
* Suivi des dates d’introduction et de fin de production

### 👥 Gestion des clients

* Clients particuliers avec ou sans programme **Fidélio**
* Clients entreprises avec taux de remise commerciale
* Création, modification et suppression des clients
* Suivi des adhésions Fidélio (dates d’adhésion et d’expiration)

### 🏭 Gestion des fournisseurs

* Création, modification et suppression des fournisseurs
* Qualification des fournisseurs (réactivité, délais, prix)
* Gestion des pièces fournies par plusieurs fournisseurs

### 🧑‍💼 Gestion des salariés

* Création, modification et suppression des salariés
* Affectation aux magasins
* Calcul des bonus en fonction du chiffre d’affaires et de la satisfaction client

### 🛒 Gestion des commandes

* Création, modification et suppression de commandes
* Commandes composées de vélos et/ou de pièces détachées
* Association d’un magasin et d’un vendeur à chaque commande
* Vérification automatique de la disponibilité en stock
* Estimation des délais de livraison en cas de rupture

### 📦 Gestion des stocks

* Suivi des stocks :

  * par magasin
  * par vélo
  * par pièce
  * par fournisseur
  * par catégorie de vélo
* Alerte en cas de stock faible
* Proposition de réapprovisionnement auprès des fournisseurs

### 📊 Module statistiques

* Quantités vendues par produit
* Ventes par magasin et par vendeur
* Liste des membres par programme Fidélio
* Dates d’expiration des adhésions
* Identification des meilleurs clients (volume ou chiffre d’affaires)
* Analyse des commandes (moyennes, montants, volumes)
* Calcul des bonus salariés et bonus moyens

---

## 🗄️ Base de données

* **SGBD** : MySQL
* **Nom de la base** : `VeloMax`
* Conception basée sur un **diagramme Entité / Association**
* Respect de l’intégrité référentielle et des dépendances

### 👤 Utilisateurs MySQL

* `root / root` : administrateur
* `bozo / bozo` : utilisateur avec droits de lecture uniquement

### 🔍 Requêtes SQL spécifiques

* Requête synchronisée
* Requête avec auto-jointure
* Requête utilisant UNION
* Requêtes statistiques avancées

---

## 💻 Technologies utilisées

* **Langage** : C#
* **Base de données** : MySQL
* **Accès aux données** : SQL
* **IDE** : Visual Studio
* **Versioning** : Git / GitHub

---

## ▶️ Exécution du projet

1. Cloner le dépôt GitHub
2. Importer le script `VeloMax.sql` dans MySQL
3. Vérifier la présence des utilisateurs MySQL (`root`, `bozo`)
4. Ouvrir le projet C# dans Visual Studio
5. Configurer la chaîne de connexion à la base de données
6. Lancer l’application

---

## 🎯 Objectifs pédagogiques

* Modélisation avancée de bases de données relationnelles
* Mise en œuvre de requêtes SQL complexes
* Développement d’une application métier connectée à une BDD
* Gestion de règles métier réalistes (stocks, délais, remises)
* Travail en autonomie et structuration d’un projet logiciel

## ✍️ Auteur

Projet réalisé en autonomie dans le cadre d’un cursus en ingénierie.

---

📌 *Ce projet illustre la conception complète d’un système d’information métier, de la base de données jusqu’à l’application finale.*
