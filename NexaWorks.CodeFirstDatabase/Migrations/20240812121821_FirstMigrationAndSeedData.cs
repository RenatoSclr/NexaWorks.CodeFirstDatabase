using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexaWorks.CodeFirstDatabase.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrationAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OS",
                columns: table => new
                {
                    OS_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomOS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OS", x => x.OS_Id);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Produit_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProduit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Produit_Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuts",
                columns: table => new
                {
                    Statut_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtatStatut = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuts", x => x.Statut_Id);
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    Version_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<double>(type: "float", nullable: false),
                    Produit_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.Version_Id);
                    table.ForeignKey(
                        name: "FK_Versions_Produits_Produit_Id",
                        column: x => x.Produit_Id,
                        principalTable: "Produits",
                        principalColumn: "Produit_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Ticket_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateResolution = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Probleme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OS_Id = table.Column<int>(type: "int", nullable: false),
                    Statut_Id = table.Column<int>(type: "int", nullable: false),
                    Version_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Ticket_Id);
                    table.ForeignKey(
                        name: "FK_Tickets_OS_OS_Id",
                        column: x => x.OS_Id,
                        principalTable: "OS",
                        principalColumn: "OS_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Statuts_Statut_Id",
                        column: x => x.Statut_Id,
                        principalTable: "Statuts",
                        principalColumn: "Statut_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Versions_Version_Id",
                        column: x => x.Version_Id,
                        principalTable: "Versions",
                        principalColumn: "Version_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OS",
                columns: new[] { "OS_Id", "NomOS" },
                values: new object[,]
                {
                    { 1, "Windows" },
                    { 2, "Linux" },
                    { 3, "MacOS" },
                    { 4, "Android" },
                    { 5, "iOS" }
                });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Produit_Id", "NomProduit" },
                values: new object[,]
                {
                    { 1, "Trader en Herbe" },
                    { 2, "Maître des Investissements" },
                    { 3, "Planificateur d’Entraînement" },
                    { 4, "Planificateur d’Anxiété Sociale" }
                });

            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "Statut_Id", "EtatStatut" },
                values: new object[,]
                {
                    { 1, true },
                    { 2, false }
                });

            migrationBuilder.InsertData(
                table: "Versions",
                columns: new[] { "Version_Id", "Numero", "Produit_Id" },
                values: new object[,]
                {
                    { 1, 1.0, 1 },
                    { 2, 1.1000000000000001, 1 },
                    { 3, 1.2, 1 },
                    { 4, 1.3, 1 },
                    { 5, 1.0, 2 },
                    { 6, 2.0, 2 },
                    { 7, 2.1000000000000001, 2 },
                    { 8, 1.0, 3 },
                    { 9, 1.1000000000000001, 3 },
                    { 10, 2.0, 3 },
                    { 11, 1.0, 4 },
                    { 12, 1.1000000000000001, 4 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Ticket_Id", "DateCreation", "DateResolution", "OS_Id", "Probleme", "Resolution", "Statut_Id", "Version_Id" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "L'application ne s'ouvre pas sur certaines machines Windows, affichant un message d'erreur indiquant que le fichier DLL requis est manquant.", "Installation manuelle du fichier manquant via une mise à jour du programme d'installation.", 1, 2 },
                    { 2, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "L'application plante lors de l'ajout d'un nouveau portefeuille avec des titres ayant des caractères spéciaux dans leur nom.", null, 2, 5 },
                    { 3, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Les notifications d'entraînement ne se déclenchent pas à l'heure prévue sur certains appareils Android.", "Ajustement des permissions de notifications spécifiques à Android 11+.", 1, 9 },
                    { 4, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "L'interface de l'application gèle lors de la création d'une nouvelle session de gestion de l'anxiété.", null, 2, 11 },
                    { 5, new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Les utilisateurs signalent des retards dans la mise à jour des données boursières en temps réel.", "Optimisation des appels API pour réduire la latence.", 1, 3 },
                    { 6, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "L'importation des programmes d'entraînement depuis des fichiers Excel échoue si le fichier contient plus de 100 lignes.", "Augmentation de la limite de lignes traitées et amélioration de l'algorithme d'importation.", 1, 10 },
                    { 7, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "L'application consomme une quantité excessive de mémoire lors de l'analyse de portefeuilles complexes, entraînant des ralentissements du système.", null, 2, 6 },
                    { 8, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "L'application ne sauvegarde pas correctement les notes prises pendant les sessions.", "Correction d'un problème de synchronisation avec iCloud.", 1, 12 },
                    { 9, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Les graphiques interactifs ne s'affichent pas correctement sous certaines distributions Linux, rendant l'analyse visuelle des données difficile.", null, 2, 4 },
                    { 10, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, "Les utilisateurs ne peuvent pas partager leurs programmes d'entraînement via AirDrop.", null, 2, 9 },
                    { 11, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "L'application affiche des erreurs lors de la connexion au serveur de données, empêchant la récupération des statistiques de l'utilisateur.", null, 2, 11 },
                    { 12, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "L'authentification biométrique ne fonctionne pas sur certains appareils Android, obligeant les utilisateurs à saisir manuellement leur mot de passe.", null, 2, 7 },
                    { 13, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "L'application ne parvient pas à synchroniser les données d'entraînement avec l'application Santé d'Apple.", null, 2, 10 },
                    { 14, new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Des utilisateurs signalent que l'application se ferme de manière inattendue lorsqu'ils tentent de consulter l'historique des transactions.", "Correction d'un bug dans la gestion des fichiers de log.", 1, 1 },
                    { 15, new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "L'application ne parvient pas à récupérer les données de marché en temps réel, affichant à la place des données obsolètes.", null, 2, 6 },
                    { 16, new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "L'application plante lorsqu'un utilisateur tente de lancer une session de relaxation après une longue période d'inactivité.", null, 2, 12 },
                    { 17, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Les notifications de surveillance du marché ne fonctionnent pas de manière fiable, ce qui entraîne des retards dans l'alerte des utilisateurs.", null, 2, 4 },
                    { 18, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "L'application ne parvient pas à suivre correctement les calories brûlées lors de l'utilisation d'appareils de fitness connectés.", "Mise à jour de l'intégration des appareils de fitness pour assurer la compatibilité avec les derniers modèles.", 1, 10 },
                    { 19, new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Les graphiques de performance des portefeuilles ne se chargent pas correctement lorsque l'utilisateur sélectionne une période supérieure à 5 ans.", null, 2, 7 },
                    { 20, new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Les notifications push ne s'affichent pas pour les rappels programmés, ce qui affecte l'efficacité du plan de gestion de l'anxiété.", null, 2, 11 },
                    { 21, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Les utilisateurs signalent que l'application devient très lente lors de la navigation entre les différentes sections du tableau de bord.", null, 2, 4 },
                    { 22, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "L'application ne synchronise pas les données d'entraînement avec les serveurs cloud, entraînant la perte de données lorsque l'utilisateur change d'appareil.", null, 2, 9 },
                    { 23, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "L'application échoue à se connecter aux services bancaires en ligne, empêchant les utilisateurs d'effectuer des transferts de fonds.", null, 2, 5 },
                    { 24, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "L'application ne démarre pas correctement sur certaines distributions Linux, bloquant sur l'écran de chargement.", null, 2, 8 },
                    { 25, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Les utilisateurs signalent que le programme ne sauvegarde pas correctement les préférences d'affichage, obligeant à les reconfigurer à chaque ouverture de l'application.", null, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OS_Id",
                table: "Tickets",
                column: "OS_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Statut_Id",
                table: "Tickets",
                column: "Statut_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Version_Id",
                table: "Tickets",
                column: "Version_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Versions_Produit_Id",
                table: "Versions",
                column: "Produit_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "OS");

            migrationBuilder.DropTable(
                name: "Statuts");

            migrationBuilder.DropTable(
                name: "Versions");

            migrationBuilder.DropTable(
                name: "Produits");
        }
    }
}
