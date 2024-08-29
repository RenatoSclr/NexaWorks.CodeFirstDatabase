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

void Main()
{

}

public static class TicketExtensions
{
    public static IQueryable<Tickets> GetQuery(this IQueryable<Tickets> tickets,
                                               bool estResolu, 
                                               int? produitId = null, 
                                               double? versionNumero = null, 
                                               string[] motsCles = null)
    {
        var query = tickets.Where(t => t.Statut.EtatStatut == estResolu);

        if (produitId.HasValue)
        {
            query = query.Where(t => t.Version.Produit_Id == produitId.Value);
        }

        if (versionNumero.HasValue)
        {
            query = query.Where(t => t.Version.Numero == versionNumero.Value);
        }

        if (motsCles != null && motsCles.Length > 0)
        {
            foreach (var motCle in motsCles)
            {
                query = query.Where(t => t.Probleme.Contains(motCle));
            }
        }
        return query;
    }
}
