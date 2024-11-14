using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class OrdreLinje
    {
        public int Id { get; set; }
        public int Antal { get; set; }
        public double Pris { get; set; }
        public Vare Vare { get; set; }
    }
}

    