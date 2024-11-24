using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Components.Varer
{
    public partial class VareRenderComponent
    {
        [Parameter, EditorRequired]
        public Vare? VareModel { get; set; }

        [Parameter]
        public EventCallback<Vare> OnSelectVare { get; set; }
        [Parameter]
        public EventCallback<Vare> OnEditVare { get; set; }
        [Parameter]
        public EventCallback<Vare> OnDeleteVare { get; set; }
        
    }
}
