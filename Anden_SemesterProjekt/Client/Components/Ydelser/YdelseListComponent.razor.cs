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
        public List<Ydelse>? Varer { get; set; } = new List<Ydelse>();
        [Inject] private IJSRuntime JS { get; set; } //JavaScript runtime
        [Inject] public IVareClientService VareClientService { get; set; }

        public string searchString = "";
        public bool IsLoading { get; set; } = true;
        private Ydelse valgtYdelse = new Ydelse();
        private Ydelse redigeretYdelse = new Ydelse();

        [Parameter]
        public List<Ydelse>? filteredYdelser { get; set; } = new List<Ydelse>();

        [Parameter]
        public EventCallback<Vare> OnSelectYdelse { get; set; }
        [Parameter]
        public EventCallback<Vare> OnEditYdelse{ get; set; }
        [Parameter]
        public EventCallback<Vare> OnDeleteYdelse { get; set; }

        private int Id;
        private bool detailsModal = false;
        private bool editModal = false;
        private string searchTerm = string.Empty;

        private void FilterYdelse(ChangeEventArgs e)
        {
            searchTerm = e.Value.ToString();

            if (string.IsNullOrEmpty(searchTerm))
            {
                filteredYdelser = Varer;
            }
            else
            {
                filteredYdelser = Varer
                    .Where(v => v.Beskrivelse != null && v.Beskrivelse.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }

        private void YdelseBeskrivelse(Ydelse ydelse)
        {
            valgtYdelse = Varer.FirstOrDefault(v => v.Id == ydelse.Id);

            // Hvis en varer er fundet, vis modal
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
            Varer = updatedYdelser;
            StateHasChanged();
        }

        private async Task UpdateYdelse()
        {
            var response = await VareClientService.PutVare(redigeretYdelse);
            if (response != null)
            {
                var successBox = await JS.InvokeAsync<string>("alert", "Ydelsen er opdateret.");
                detailsModal = false;
                filteredYdelser = await VareClientService.GetAktiveYdelser();
                detailsModal = true;
                editModal = false;
                detailsModal = false;
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
