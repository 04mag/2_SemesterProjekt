﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public abstract class Scooter
    {
        public int ScooterId { get; set; }
        [Required (ErrorMessage = "Stelnummer er påkrævet.")]
        [StringLength(20, MinimumLength = 15, ErrorMessage = "Stelnummer skal være mellem 15 og 20 tegn.")]
        public string Stelnummer { get; set; }
        public string? Registreringsnummer { get; set; }
        
        public int MærkeId { get; set; }

        public Mærke? Mærke { get; set; }
        public bool ErAktiv { get; set; }
       
    }
}
