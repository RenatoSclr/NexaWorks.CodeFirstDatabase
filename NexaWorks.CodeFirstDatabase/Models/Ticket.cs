using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexaWorks.CodeFirstDatabase.Models
{
    public class Ticket
    {
        [Key]
        public int Ticket_Id { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }
        public DateTime? DateResolution { get; set; }

        [Required]
        public string Probleme { get; set; }
        public string? Resolution { get; set; }

        public int OS_Id { get; set; }

        [ForeignKey("OS_Id")]
        public OS OS { get; set; }

        public int Statut_Id { get; set; }

        [ForeignKey("Statut_Id")]
        public Statut Statut { get; set; }

        public int Version_Id { get; set; }

        [ForeignKey("Version_Id")]
        public Version Version { get; set; }
    }
}
