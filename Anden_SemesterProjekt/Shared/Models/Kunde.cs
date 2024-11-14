using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Kunde
    {

        public int Id { get; set; }
        public string Navn { get; set; }
        public string Efternavn { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

    }
}
