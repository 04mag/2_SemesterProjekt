using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class UdlejningsScooterDTO
    {
        public int ScooterId { get; set; }
        public string Stelnummer { get; set; }
        public string Registreringsnummer { get; set; }
        public int MærkeId { get; set; }
        public bool ErAktiv { get; set; }
        public bool ErTilgængelig { get; set; }
    }

}
