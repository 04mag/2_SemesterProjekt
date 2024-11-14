using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class KundeScooter
    {
        public int Id { get; set; }
        public Kunde Kunde { get; set; }
        public Scooter Scooter { get; set; }
    }
}
