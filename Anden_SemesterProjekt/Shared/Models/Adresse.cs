using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Adresse
    {
        public int AdresseId { get; set; }
        [Required(ErrorMessage = "Gadenavn skal udfyldes!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Gadenavn skal være mellem 2 og 100 karaktere langt!")]
        public string Gadenavn { get; set; } = string.Empty;
        [Required(ErrorMessage = "Husnummer skal udfyldes!")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Husnummer skal være mellem 1 og 5 karaktere langt!")]
        public string Husnummer { get; set; } = string.Empty;
        [StringLength(3, ErrorMessage = "Etage må maks være 3 karaktere langt.")]
        public string Etage { get; set; } = string.Empty;
        [StringLength(3, ErrorMessage = "Side må maks være 3 karaktere langt.")]
        public string Side { get; set; } = string.Empty;
        [StringLength(5, ErrorMessage = "Dørnummer må maks være 5 karaktere langt.")]
        public string Dørnummer { get; set; } = string.Empty;
        [Required(ErrorMessage = "Postnummer skal udfyldes!")]
        [ForeignKey("By")]
        public string Postnummer { get; set; }
        public By? By { get; set; }
        public int KundeId { get; set; }
        [JsonIgnore]
        public Kunde? Kunde { get; set; }

        public override string ToString()
        {
            if (EtageToString().Length == 0 && SideToString().Length == 0 && DørnummerToString().Length == 0)
            {
                return $"{Gadenavn} {Husnummer}";
            }
            else
            {
                return $"{Gadenavn} {Husnummer}, {EtageToString()} {SideToString()} {DørnummerToString()}";
            }
        }

        private string EtageToString()
        {
            if (Etage == null || Etage.Length == 0) return string.Empty;

            if (Etage.EndsWith('.'))
            {
                return Etage;
            }
            else
            {
                return Etage + ".";
            }
        }

        private string SideToString()
        {
            if (Side == null || Side.Length == 0) return string.Empty;

            if (Side.EndsWith('.'))
            {
                return Side;
            }
            else
            {
                return Side + ".";
            }
        }

        private string DørnummerToString()
        {
            if (Dørnummer == null || Dørnummer.Length == 0) return string.Empty;

            if (Dørnummer.EndsWith('.'))
            {
                return Dørnummer;
            }
            else
            {
                return Dørnummer + ".";
            }
        }
    }
}
