using Anden_SemesterProjekt.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Vare
    {
        
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Navn skal være mellem 2 og 50 karaktere langt.")]
        public string Beskrivelse { get; set; }
        
        public double Pris { get; set; }
       
        public bool ErAktiv { get; set; }

        public List<VareLinje> VareLinjer { get; set; }

        public Vare()
        {
           
        }
    }
}
