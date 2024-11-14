using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Udlejning : Vare
    {
        public UdlejningsScooter Scooter { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }
        public string Noter { get; set; }
    }
}
