using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Betaling
    {
        public int Id { get; set; }
        public double Pris { get; set; }
        public DateTime Dato { get; set; }
        public Betalingsmetode Betalingsmetode { get; set; }
    }
    public enum Betalingsmetode
    {
        Kontant,
        MobilePay,
        Kreditkort,
        Bankoverførsel
    }
}
