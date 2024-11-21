using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Components.Kunder
{
    public partial class KundeRenderComponent
    {
        [Parameter, EditorRequired]
        public Kunde? KundeModel { get; set; }

        [Parameter]
        public EventCallback<Kunde> OnEditKunde { get; set; }
        [Parameter]
        public EventCallback<Kunde> OnDeleteKunde { get; set; }
        [Parameter]
        public EventCallback<Kunde> OnSelectKunde { get; set; }

    }
}
