using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Ydelse : Vare
    {
        public double Tid { get; set; }
       // public Mekaniker Mekaniker { get; set; }
        public YdelsesType YdelsesType { get; set; }
    }

    public enum YdelsesType
    {
        Reparation,
        EkstraYdelse,
    }
}
