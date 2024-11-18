using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Components.Kunder
{
    public partial class KundeListComponent
    {
        [Parameter, EditorRequired]
        public List<Kunde>? Kunder { get; set; }

        public EventCallback<Kunde> OnEditKunde { get; set; }
        public EventCallback<Kunde> OnDeleteKunde { get; set; }
    }
}
