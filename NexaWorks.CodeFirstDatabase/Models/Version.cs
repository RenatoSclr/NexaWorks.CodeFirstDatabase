using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexaWorks.CodeFirstDatabase.Models
{
    public class Version
    {
        [Key]
        public int Version_Id { get; set; }
        public int Numero { get; set; }

        public int Produit_Id { get; set; }

        [ForeignKey("Produit_Id")]
        public Produit Produit { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
