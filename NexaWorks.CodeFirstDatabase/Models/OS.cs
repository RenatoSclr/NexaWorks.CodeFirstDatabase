using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexaWorks.CodeFirstDatabase.Models
{
    public class OS
    {
        [Key]
        public int OS_Id { get; set; }
        public string NomOS { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
