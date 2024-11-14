using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class TlfNummer
    {
        public int TlfNummerId { get; set; }
        public string TelefonNummer { get; set; }
        public int KundeId { get; set; }
        public Kunde Kunde { get; set; }
    }
}
