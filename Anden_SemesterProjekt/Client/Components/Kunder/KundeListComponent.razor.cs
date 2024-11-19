using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Components.Kunder
{
    public partial class KundeListComponent
    {
        [Parameter, EditorRequired]
        public List<Kunde>? Kunder { get; set; }

        private string searchString = "";


        [Parameter]
        public EventCallback<Kunde> OnEditKunde { get; set; }
        [Parameter]
        public EventCallback<Kunde> OnDeleteKunde { get; set; }

        [Inject]
        public IMærkeClientService MærkeService { get; set; }

        public List<Mærke>? Mærker { get; set; }

        private int selectedMærkeId;

        private List<Kunde> _filter;

        public List<Kunde> FilteredKunder
        {
            get
            {
                if (selectedMærkeId == 0)
                {
                    return Kunder.Where(m => m.TlfNumre.Any(t => t.TelefonNummer.Contains(searchString, StringComparison.OrdinalIgnoreCase))).ToList();
                }
                else
                {
                    return Kunder.Where(m => m.TlfNumre.Any(t => t.TelefonNummer.Contains(searchString, StringComparison.OrdinalIgnoreCase))).Where(Kunder => Kunder.Scootere.Any(s => s.MærkeId == selectedMærkeId)).ToList();
                }
            }
        }


        protected override async Task OnInitializedAsync()
        {
            Mærker = await MærkeService.GetMærker();
        }
    }
}
