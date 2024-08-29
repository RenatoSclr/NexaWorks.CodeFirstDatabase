<Query Kind="Program">
  <Connection>
    <ID>3958c427-3c76-43fb-adf6-817f47b3fe98</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DisplayName>database</DisplayName>
    <Database>NexaWorksDb</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

#load "MyBaseNexaWorksQuery"
void Main()
{
	// true pour résolu, false pour en cours
    bool estResolu = false; 
	//1: Trader en herbe - 2: Maître des Investissements - 3: Planificateur d’Entraînement - 4: Planificateur d’Anxiété Sociale	
	int? produitId = 1; 
	string[] motsCles = ["utilisateurs", "historique"]; 
	
	IQueryable<Tickets> tickets = Tickets.AsQueryable();
	
	
    var query = TicketExtensions.GetQuery(tickets, estResolu, produitId, null, motsCles);

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

