using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class By
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Postnummer { get; set; }
        public string ByNavn { get; set; }
        public List<Adresse> Adresser { get; set; }
    }
}
