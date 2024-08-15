using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexaWorks.CodeFirstDatabase.Models
{
    public class Produit
    {
        [Key]
        public int Produit_Id { get; set; }
        public string NomProduit { get; set; }

        public ICollection<Version> Versions { get; set; }
    }
}
