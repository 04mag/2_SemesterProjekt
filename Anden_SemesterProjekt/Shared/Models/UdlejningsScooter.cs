using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
 
    public class UdlejningsScooter : Scooter
    {
        public bool ErTilgængelig { get; set; } = true;
        [JsonIgnore]
        public List<Udlejning>? Udlejninger { get; set; }

        public override string ToString()
        {
            return $"{this.Registreringsnummer}";
        }
    }
}
