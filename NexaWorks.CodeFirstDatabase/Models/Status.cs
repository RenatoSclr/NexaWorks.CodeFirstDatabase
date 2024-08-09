using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexaWorks.CodeFirstDatabase.Models
{
    public class Statut
    {
        [Key]
        public int Statut_Id { get; set; }
        public bool EtatStatut { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
