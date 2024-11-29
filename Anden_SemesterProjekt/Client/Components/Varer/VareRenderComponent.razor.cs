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

        [Parameter]
        public EventCallback<Vare> OnVareCreated { get; set; }
        private Vare nyVare = new Vare();
       

        //    private async Task OpretVare()
        //    {
        //        await OnVareCreated.InvokeAsync(nyVare);
        //        nyVare = new Vare();
        //    }

        //    [Parameter]
        //    public EventCallback<Vare> OnVareAdded { get; set; }

        //    [Parameter]
        //    public Vare nyOprettetVare { get; set; } = new Vare();

        //    private async Task TilføjNyVare(Vare nyVare)
        //    {
        //        nyOprettetVare = nyVare; // Opdater komponentens interne model
        //        await OnVareAdded.InvokeAsync(nyVare); // Send varen videre til VarePage
        //    }

        //}
    }
}
