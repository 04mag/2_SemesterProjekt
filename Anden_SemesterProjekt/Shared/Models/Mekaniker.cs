using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Mekaniker
    {

        public int MekanikerId { get; set; }
        public string Navn { get; set; }
        public bool ErAktiv { get; set; }
        public List<Mærke> Mærker { get; set; }
        public List<Ordre> Ordrer { get; set; }

    }
}
