using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Mekaniker
    {
        public int MekanikerId { get; set; }
        //[Required]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Navn skal være mellem 2 og 50 karaktere langt!")]
        public string Navn { get; set; }
        public bool ErAktiv { get; set; } = true;
      [JsonIgnore]  public List<Mærke> Mærker { get; set; }
      [JsonIgnore] public List<Ordre>? Ordrer { get; set; }
    }
}
