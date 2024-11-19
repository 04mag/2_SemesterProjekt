using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    
    // Dette er en attribut som bruges til at identificere hvilken type af objekt der er tale om, så man kan deserialisere det korrekt.
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(KundeScooter), "KundeScooter")] 
    [JsonDerivedType(typeof(UdlejningsScooter), "UdlejningsScooter")]
    public abstract class Scooter
    {
        public int ScooterId { get; set; }
        [Required(ErrorMessage = "Stelnummer er påkrævet.")]
        public string Stelnummer { get; set; }
        public string? Registreringsnummer { get; set; }
        
        public int MærkeId { get; set; }

        //[Required(ErrorMessage = "Mærke er påkrævet.")]
        [JsonIgnore] public Mærke? Mærke { get; set; }
    }
}
