﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class KundeScooter : Scooter
    {
        public int KundeId { get; set; }
        public Kunde Kunde { get; set; }
    }
}