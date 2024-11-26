﻿using Anden_SemesterProjekt.Shared.Models;
using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Components.Varer
{
    public partial class VareListComponent
    {
        [Parameter, EditorRequired]
        public List<Vare>? Varer { get; set; } = new List<Vare>();

        public string searchString = ""; 

        [Parameter]
        public EventCallback<Vare> OnSelectVare { get; set; }
        [Parameter]
        public EventCallback<Vare> OnEditVare { get; set; }
        [Parameter]
        public EventCallback<Vare> OnDeleteVare { get; set; }

    }

}
