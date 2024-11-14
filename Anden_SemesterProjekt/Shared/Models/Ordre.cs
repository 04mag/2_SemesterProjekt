using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Ordre
    {
        public int Id { get; set; }
        public List<VareLinje> OrdreLinjer { get; set; }
        public Kunde Kunde { get; set; }
        public DateTime Dato { get; set; }
        public Betaling Betaling { get; set; }
    }
}
