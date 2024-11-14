using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Vare
    {
        [Key]
        public int Id { get; set; }
        public string Beskrivelse { get; set; }
        public double Pris { get; set; }
        public bool ErAktiv { get; set; }
        public List<VareLinje> VareLinjer { get; set; }
    }
}
