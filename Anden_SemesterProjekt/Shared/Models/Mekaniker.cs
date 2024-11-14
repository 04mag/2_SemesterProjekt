using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Mekaniker
    {

        public int Id { get; set; }
        public string Navn { get; set; }
        public string Efternavn { get; set; }
        public List <Scooter> Kompetencer { get; set; }

    }
}
