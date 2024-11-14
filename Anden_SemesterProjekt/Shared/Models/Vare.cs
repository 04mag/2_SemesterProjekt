using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public abstract class Vare
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public double Pris { get; set; }
        public string Beskrivelse { get; set; }
        
    }
}
