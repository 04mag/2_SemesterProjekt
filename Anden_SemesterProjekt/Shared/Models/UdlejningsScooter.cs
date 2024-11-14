using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class UdlejningsScooter
    {
        public int Id { get; set; }
        public string Mærke { get; set; }
        public string Model { get; set; }
        public int Antal { get; set; }
        public ScooterLager ScooterLager { get; set; }
        public ScooterStatus Status { get; set; }
    }
    public enum ScooterStatus
    {
        Ledig, // Ledig til udlejning
        Udlejet,    // Udlejet
        Værksted // Til reparation eller vedligeholdelse
    }

}
