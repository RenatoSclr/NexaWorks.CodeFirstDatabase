using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NexaWorks.CodeFirstDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = NexaWorks.CodeFirstDatabase.Models.Version;

namespace NexaWorks.CodeFirstDatabase.Data
{
    public class NexaWorksDbContext : DbContext
    {
        public NexaWorksDbContext() : base()
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Models.Version> Versions { get; set; }
        public DbSet<OS> OS { get; set; }
        public DbSet<Statut> Statuts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=NexaWorksDb;Trusted_Connection=True;TrustServerCertificate=True; ");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>()
                .HasMany(p => p.Versions)
                .WithOne(v => v.Produit)
                .HasForeignKey(v => v.Produit_Id);

            modelBuilder.Entity<Version>()
                .HasMany(v => v.Tickets)
                .WithOne(t => t.Version)
                .HasForeignKey(t => t.Version_Id);

            modelBuilder.Entity<OS>()
                .HasMany(os => os.Tickets)
                .WithOne(t => t.OS)
                .HasForeignKey(t => t.OS_Id);

            modelBuilder.Entity<Statut>()
                .HasMany(s => s.Tickets)
                .WithOne(t => t.Statut)
                .HasForeignKey(t => t.Statut_Id);


            modelBuilder.Entity<Produit>().HasData(
            new Produit { Produit_Id = 1, NomProduit = "Trader en Herbe" },
            new Produit { Produit_Id = 2, NomProduit = "Maître des Investissements" },
            new Produit { Produit_Id = 3, NomProduit = "Planificateur d’Entraînement" },
            new Produit { Produit_Id = 4, NomProduit = "Planificateur d’Anxiété Sociale" }
        );

            modelBuilder.Entity<Version>().HasData(
                new Version { Version_Id = 1, Numero = 1.0, Produit_Id = 1 },
                new Version { Version_Id = 2, Numero = 1.1, Produit_Id = 1 },
                new Version { Version_Id = 3, Numero = 1.2, Produit_Id = 1 },
                new Version { Version_Id = 4, Numero = 1.3, Produit_Id = 1 },
                new Version { Version_Id = 5, Numero = 1.0, Produit_Id = 2 },
                new Version { Version_Id = 6, Numero = 2.0, Produit_Id = 2 },
                new Version { Version_Id = 7, Numero = 2.1, Produit_Id = 2 },
                new Version { Version_Id = 8, Numero = 1.0, Produit_Id = 3 },
                new Version { Version_Id = 9, Numero = 1.1, Produit_Id = 3 },
                new Version { Version_Id = 10, Numero = 2.0, Produit_Id = 3 },
                new Version { Version_Id = 11, Numero = 1.0, Produit_Id = 4 },
                new Version { Version_Id = 12, Numero = 1.1, Produit_Id = 4 }
            );

            modelBuilder.Entity<OS>().HasData(
                new OS { OS_Id = 1, NomOS = "Windows" },
                new OS { OS_Id = 2, NomOS = "Linux" },
                new OS { OS_Id = 3, NomOS = "MacOS" },
                new OS { OS_Id = 4, NomOS = "Android" },
                new OS { OS_Id = 5, NomOS = "iOS" }
            );

            modelBuilder.Entity<Statut>().HasData(
                new Statut { Statut_Id = 1, EtatStatut = true },
                new Statut { Statut_Id = 2, EtatStatut = false }
            );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    Ticket_Id = 1,
                    DateCreation = new DateTime(2023, 1, 12),
                    DateResolution = new DateTime(2023, 1, 26),
                    Probleme = "L'application ne s'ouvre pas sur certaines machines Windows, affichant un message d'erreur indiquant que le fichier DLL requis est manquant.",
                    Resolution = "Installation manuelle du fichier manquant via une mise à jour du programme d'installation.",
                    OS_Id = 1,
                    Statut_Id = 1,
                    Version_Id = 2
                },
                new Ticket
                {
                    Ticket_Id = 2,
                    DateCreation = new DateTime(2023, 2, 5),
                    Probleme = "L'application plante lors de l'ajout d'un nouveau portefeuille avec des titres ayant des caractères spéciaux dans leur nom.",
                    OS_Id = 2,
                    Statut_Id = 2,
                    Version_Id = 5
                },
                new Ticket
                {
                    Ticket_Id = 3,
                    DateCreation = new DateTime(2023, 3, 20),
                    DateResolution = new DateTime(2023, 4, 10),
                    Probleme = "Les notifications d'entraînement ne se déclenchent pas à l'heure prévue sur certains appareils Android.",
                    Resolution = "Ajustement des permissions de notifications spécifiques à Android 11+.",
                    OS_Id = 4,
                    Statut_Id = 1,
                    Version_Id = 9
                },
                new Ticket
                {
                    Ticket_Id = 4,
                    DateCreation = new DateTime(2023, 4, 15),
                    Probleme = "L'interface de l'application gèle lors de la création d'une nouvelle session de gestion de l'anxiété.",
                    OS_Id = 3,
                    Statut_Id = 2,
                    Version_Id = 11
                },
                new Ticket
                {
                    Ticket_Id = 5,
                    DateCreation = new DateTime(2023, 5, 2),
                    DateResolution = new DateTime(2023, 5, 16),
                    Probleme = "Les utilisateurs signalent des retards dans la mise à jour des données boursières en temps réel.",
                    Resolution = "Optimisation des appels API pour réduire la latence.",
                    OS_Id = 5,
                    Statut_Id = 1,
                    Version_Id = 3
                },
                new Ticket
                {
                    Ticket_Id = 6,
                    DateCreation = new DateTime(2023, 6, 12),
                    DateResolution = new DateTime(2023, 6, 24),
                    Probleme = "L'importation des programmes d'entraînement depuis des fichiers Excel échoue si le fichier contient plus de 100 lignes.",
                    Resolution = "Augmentation de la limite de lignes traitées et amélioration de l'algorithme d'importation.",
                    OS_Id = 1,
                    Statut_Id = 1,
                    Version_Id = 10
                },
                new Ticket
                {
                    Ticket_Id = 7,
                    DateCreation = new DateTime(2023, 6, 30),
                    Probleme = "L'application consomme une quantité excessive de mémoire lors de l'analyse de portefeuilles complexes, entraînant des ralentissements du système.",
                    OS_Id = 1,
                    Statut_Id = 2,
                    Version_Id = 6
                },
                new Ticket
                {
                    Ticket_Id = 8,
                    DateCreation = new DateTime(2023, 7, 10),
                    DateResolution = new DateTime(2023, 7, 22),
                    Probleme = "L'application ne sauvegarde pas correctement les notes prises pendant les sessions.",
                    Resolution = "Correction d'un problème de synchronisation avec iCloud.",
                    OS_Id = 5,
                    Statut_Id = 1,
                    Version_Id = 12
                },
                new Ticket
                {
                    Ticket_Id = 9,
                    DateCreation = new DateTime(2023, 8, 15),
                    Probleme = "Les graphiques interactifs ne s'affichent pas correctement sous certaines distributions Linux, rendant l'analyse visuelle des données difficile.",
                    OS_Id = 2,
                    Statut_Id = 2,
                    Version_Id = 4
                },
                new Ticket
                {
                    Ticket_Id = 10,
                    DateCreation = new DateTime(2023, 9, 1),
                    Probleme = "Les utilisateurs ne peuvent pas partager leurs programmes d'entraînement via AirDrop.",
                    OS_Id = 5,
                    Statut_Id = 2,
                    Version_Id = 9
                },
                new Ticket
                {
                    Ticket_Id = 11,
                    DateCreation = new DateTime(2023, 9, 7),
                    Probleme = "L'application affiche des erreurs lors de la connexion au serveur de données, empêchant la récupération des statistiques de l'utilisateur.",
                    OS_Id = 1,
                    Statut_Id = 2,
                    Version_Id = 11
                },
                new Ticket
                {
                    Ticket_Id = 12,
                    DateCreation = new DateTime(2023, 9, 15),
                    Probleme = "L'authentification biométrique ne fonctionne pas sur certains appareils Android, obligeant les utilisateurs à saisir manuellement leur mot de passe.",
                    OS_Id = 4,
                    Statut_Id = 2,
                    Version_Id = 7
                },
                new Ticket
                {
                    Ticket_Id = 13,
                    DateCreation = new DateTime(2023, 9, 20),
                    Probleme = "L'application ne parvient pas à synchroniser les données d'entraînement avec l'application Santé d'Apple.",
                    OS_Id = 3,
                    Statut_Id = 2,
                    Version_Id = 10
                },
                new Ticket
                {
                    Ticket_Id = 14,
                    DateCreation = new DateTime(2023, 10, 2),
                    DateResolution = new DateTime(2023, 10, 15),
                    Probleme = "Des utilisateurs signalent que l'application se ferme de manière inattendue lorsqu'ils tentent de consulter l'historique des transactions.",
                    Resolution = "Correction d'un bug dans la gestion des fichiers de log.",
                    OS_Id = 3,
                    Statut_Id = 1,
                    Version_Id = 1
                },
                new Ticket
                {
                    Ticket_Id = 15,
                    DateCreation = new DateTime(2023, 10, 18),
                    Probleme = "L'application ne parvient pas à récupérer les données de marché en temps réel, affichant à la place des données obsolètes.",
                    OS_Id = 4,
                    Statut_Id = 2,
                    Version_Id = 6
                },
                new Ticket
                {
                    Ticket_Id = 16,
                    DateCreation = new DateTime(2023, 10, 25),
                    Probleme = "L'application plante lorsqu'un utilisateur tente de lancer une session de relaxation après une longue période d'inactivité.",
                    OS_Id = 1,
                    Statut_Id = 2,
                    Version_Id = 12
                },
                new Ticket
                {
                    Ticket_Id = 17,
                    DateCreation = new DateTime(2023, 11, 5),
                    Probleme = "Les notifications de surveillance du marché ne fonctionnent pas de manière fiable, ce qui entraîne des retards dans l'alerte des utilisateurs.",
                    OS_Id = 4,
                    Statut_Id = 2,
                    Version_Id = 4
                },
                new Ticket
                {
                    Ticket_Id = 18,
                    DateCreation = new DateTime(2023, 11, 10),
                    DateResolution = new DateTime(2023, 11, 20),
                    Probleme = "L'application ne parvient pas à suivre correctement les calories brûlées lors de l'utilisation d'appareils de fitness connectés.",
                    Resolution = "Mise à jour de l'intégration des appareils de fitness pour assurer la compatibilité avec les derniers modèles.",
                    OS_Id = 4,
                    Statut_Id = 1,
                    Version_Id = 10
                },
                new Ticket
                {
                    Ticket_Id = 19,
                    DateCreation = new DateTime(2023, 11, 15),
                    Probleme = "Les graphiques de performance des portefeuilles ne se chargent pas correctement lorsque l'utilisateur sélectionne une période supérieure à 5 ans.",
                    OS_Id = 1,
                    Statut_Id = 2,
                    Version_Id = 7
                },
                new Ticket
                {
                    Ticket_Id = 20,
                    DateCreation = new DateTime(2023, 11, 20),
                    Probleme = "Les notifications push ne s'affichent pas pour les rappels programmés, ce qui affecte l'efficacité du plan de gestion de l'anxiété.",
                    OS_Id = 4,
                    Statut_Id = 2,
                    Version_Id = 11
                },
                new Ticket
                {
                    Ticket_Id = 21,
                    DateCreation = new DateTime(2023, 12, 1),
                    Probleme = "Les utilisateurs signalent que l'application devient très lente lors de la navigation entre les différentes sections du tableau de bord.",
                    OS_Id = 3,
                    Statut_Id = 2,
                    Version_Id = 4
                },
                new Ticket
                {
                    Ticket_Id = 22,
                    DateCreation = new DateTime(2023, 12, 5),
                    Probleme = "L'application ne synchronise pas les données d'entraînement avec les serveurs cloud, entraînant la perte de données lorsque l'utilisateur change d'appareil.",
                    OS_Id = 3,
                    Statut_Id = 2,
                    Version_Id = 9
                },
                new Ticket
                {
                    Ticket_Id = 23,
                    DateCreation = new DateTime(2023, 12, 10),
                    Probleme = "L'application échoue à se connecter aux services bancaires en ligne, empêchant les utilisateurs d'effectuer des transferts de fonds.",
                    OS_Id = 3,
                    Statut_Id = 2,
                    Version_Id = 5
                },
                new Ticket
                {
                    Ticket_Id = 24,
                    DateCreation = new DateTime(2023, 12, 15),
                    Probleme = "L'application ne démarre pas correctement sur certaines distributions Linux, bloquant sur l'écran de chargement.",
                    OS_Id = 2,
                    Statut_Id = 2,
                    Version_Id = 8
                },
                new Ticket
                {
                    Ticket_Id = 25,
                    DateCreation = new DateTime(2023, 12, 20),
                    Probleme = "Les utilisateurs signalent que le programme ne sauvegarde pas correctement les préférences d'affichage, obligeant à les reconfigurer à chaque ouverture de l'application.",
                    OS_Id = 1,
                    Statut_Id = 2,
                    Version_Id = 1
                }
            );
        }
    }
}