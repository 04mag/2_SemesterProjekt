using Anden_SemesterProjekt.Client.Services; 
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace Anden_SemesterProjekt.Client.Components.Vare
{

    public class Vare
    {
        [Required(ErrorMessage = "Varenavn er påkrævet.")]
        public string Varenavn { get; set; }

        [Required(ErrorMessage = "Beskrivelse er påkrævet.")]
        public string Beskrivelse { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Prisen skal være større end 0.")]
        public decimal Pris { get; set; }

        public bool Aktiv { get; set; } = true;

    }
}
