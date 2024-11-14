using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Mærke
    {
        public int ScooterMækreId { get; set; }
        public string ScooterMærke { get; set; }
        public List <Scooter> Scootere { get; set; }
        public List<Mekaniker> Mekanikere { get; set; }
    }
}
