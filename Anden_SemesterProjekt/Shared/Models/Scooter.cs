using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public abstract class Scooter
    {
        public int ScooterId { get; set; }
        public string Stelnummer { get; set; }
        public string? Registreringsnummer { get; set; }
        public Mærke? Mærke { get; set; }
    }
}
