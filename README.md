# NexaWorks

NexaWorks développe divers produits logiciels, chacun ayant plusieurs versions compatibles avec différents systèmes d'exploitation tels que Windows, MacOS,
Linux, Android, et iOS. L'entreprise doit suivre les problèmes rencontrés pour chaque version et chaque système d'exploitation, ainsi que leur résolution.
Actuellement. Ce projet est une base de données relationnelle personnalisée pour stocker et suivre les problèmes des produits tout au long de leur cycle de vie, 
ainsi que pour gérer la résolution de ces problèmes.

## Capture d'écran du Modèle d'Entité-Association
![Modèle Entité-Association](Modèle%20Entitées-Associations.png)

## Installation

### Prérequis

- .NET SDK 6.0 ou supérieur
- LINQPad (pour exécuter les requêtes LINQ)
- Visual Studio ou tout autre IDE supportant C#

### Étapes d'installation

1. **Cloner le dépôt :**

   ```bash
   git clone https://github.com/RenatoSclr/NexaWorks.CodeFirstDatabase.git

2. **Installer LINQPad :**

Pour exécuter les requêtes LINQ incluses dans le projet, vous devez installer LINQPad :

- Téléchargez et installez LINQPad depuis le site officiel : [Télécharger LINQPad](https://www.linqpad.net/).  
- Une fois installé, ouvrez LINQPad et chargez les fichiers .linq situés dans le dossier Queries du projet.  

## Exécution des requêtes LINQ  
Voici un exemple de requête LINQ que vous pouvez exécuter dans LINQPad pour filtrer et explorer les tickets en fonction de différents critères tels que le statut de résolution, le produit, la version ou une plage de dates.  

```bash
#load "MyBaseNexaWorksQuery"

void Main()
{
    bool estResolu = false; 
    int? produitId = 1; 
    DateTime dateDebut = new DateTime(2023, 9, 1);
    DateTime dateFin = new DateTime(2023, 9, 30);

    IQueryable<Tickets> tickets = Tickets.AsQueryable();
    
    var query = TicketExtensions.GetQuery(tickets, estResolu, produitId, dateDebut: dateDebut, dateFin: dateFin);
    
    var result = query.Select(t => new
    {
        t.Ticket_Id,
        t.DateCreation,
        t.Probleme,
        Resolution = t.Statut.EtatStatut ? t.Resolution : null,
        Produit = t.Version.Produit.NomProduit,
        Version = t.Version.Numero,
        OS = t.OS.NomOS,
        Statut = t.Statut.EtatStatut ? "Résolu" : "En cours"
    });

    result.Dump(); 
}

```
### Comment ça fonctionne :  

Cette requête utilise des paramètres dynamiques pour filtrer les tickets. Voici les paramètres que vous pouvez ajuster :  
 - estResolu: Indique si vous souhaitez filtrer les tickets résolus (true) ou non résolus (false).
 - produitId: Filtre par ID de produit. Vous pouvez définir cet ID pour cibler un produit spécifique.
 - dateDebut et dateFin: Ces paramètres permettent de définir une plage de dates pour filtrer les tickets créés pendant cette période.

Note: Pour accéder à différentes versions, produits, ou plages de dates, il vous suffit de modifier ces paramètres dans la requête. Cela vous permet de personnaliser les résultats selon vos besoins spécifiques.








