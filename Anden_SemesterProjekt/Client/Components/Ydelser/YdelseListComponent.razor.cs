using Anden_SemesterProjekt.Shared.Models;
using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.JSInterop;

namespace Anden_SemesterProjekt.Client.Components.Ydelser
{
    public partial class YdelseListComponent
    {

        [Parameter, EditorRequired]
        public List<Ydelse> Ydelser { get; set; } 
        [Inject] private IJSRuntime JS { get; set; } //JavaScript runtime
        [Inject] public IVareClientService VareClientService { get; set; }

        public string searchString = "";
        public bool IsLoading { get; set; } = true;
        private Ydelse valgtYdelse = new Ydelse();
        private Ydelse redigeretYdelse = new Ydelse();

        public List<Ydelse> FilteredYdelser
        {
            get
            {
                    return Ydelser
                   .Where(v => v.Beskrivelse != null && v.Beskrivelse.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                   .ToList();
            }
        }

        [Parameter]
        public EventCallback<Ydelse> OnSelectYdelse { get; set; }
        [Parameter]
        public EventCallback<Ydelse> OnEditYdelse{ get; set; }
        [Parameter]
        public EventCallback<Ydelse> OnDeleteYdelse { get; set; }

        private int Id;
        private bool detailsModal = false;
        private bool editModal = false;
        private string searchTerm = "";


        private void YdelseBeskrivelse(Ydelse ydelse)
        {
            valgtYdelse = Ydelser.FirstOrDefault(v => v.Id == ydelse.Id);

            // Hvis en Varer er fundet, vis modal
            if (valgtYdelse != null)
            {
                detailsModal = true;
            }
            else
            {
                detailsModal = false;
            }
            // Opdater brugergrænsefladen
            StateHasChanged();
        }

        private void RedigerYdelse(Ydelse ydelse)
        {
            valgtYdelse = ydelse;
            redigeretYdelse = new Ydelse

            {
                Id = ydelse.Id,
                Beskrivelse = ydelse.Beskrivelse,
                Pris = ydelse.Pris,
                AntalTimer = ydelse.AntalTimer,
            };
            editModal = true;
            StateHasChanged();
        }

        public void UpdateList(List<Ydelse> updatedYdelser)
        {
            Ydelser = updatedYdelser;
            StateHasChanged();
        }

        private async Task UpdateYdelse()
        {
            var response = await VareClientService.PutVare(redigeretYdelse);
            if (response != null)
            {
                var successBox = await JS.InvokeAsync<string>("alert", "Ydelsen er opdateret.");
                detailsModal = false;
                Ydelser = await VareClientService.GetAktiveYdelser();
                detailsModal = true;
                editModal = false;
                detailsModal = false;
            }

        }

        private async Task SoftDelete()
        {
            //Viser en bekræftelsesdialog med Javascript
            var confirmDelete = await JS.InvokeAsync<bool>("confirm", "Er du sikker på, at du vil slette denne ydelse?");
            if (confirmDelete)
            {
                redigeretYdelse.ErAktiv = false;
                var response = await VareClientService.SoftDelete(redigeretYdelse);
                if (response != null)
                {
                    var succesBox = await JS.InvokeAsync<string>("alert", "Ydelsen er inaktiv");
                    Ydelser = await VareClientService.GetAktiveYdelser();
                    detailsModal = true;
                    editModal = false;
                    detailsModal = false;
                }
            }
        }
            

        private void CloseModal()
        {
            detailsModal = false;
        }
        private async Task CloseEditModal()
        {
            editModal = false;
        }


    }
}
