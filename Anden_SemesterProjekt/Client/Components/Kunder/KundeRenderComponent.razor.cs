﻿using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Components.Kunder
{
    public partial class KundeRenderComponent
    {
        [Parameter, EditorRequired]
        public Kunde? Kunde { get; set; }

        [Parameter]
        public EventCallback<Kunde> OnEditKunde { get; set; }
        [Parameter]
        public EventCallback<Kunde> OnDeleteKunde { get; set; }
    }
}
