using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Components.Ydelser
{
    public partial class YdelseRenderComponent
    {
        [Parameter, EditorRequired]
        public Ydelse? YdelseModel { get; set; }

        [Parameter]
        public EventCallback<Ydelse> OnSelectYdelse { get; set; }
        [Parameter]
        public EventCallback<Ydelse> OnEditYdelse { get; set; }
        [Parameter]
        public EventCallback<Ydelse> OnDeleteYdelse { get; set; }

        [Parameter]
        public EventCallback<Ydelse> OnVareYdelse { get; set; }
        private Ydelse nyYdelse = new Ydelse();
    }
}
