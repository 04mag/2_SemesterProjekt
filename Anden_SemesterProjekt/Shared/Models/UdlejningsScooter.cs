using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class UdlejningsScooter : Scooter
    { 
       public bool ErTilgængelig { get; set; }
       public bool ErAktiv { get; set; }
       public List<Udlejning>? Udlejninger { get; set; }

       public UdlejningsScooter()
       {
       }
    }
}
