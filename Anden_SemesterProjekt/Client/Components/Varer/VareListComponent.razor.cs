using Anden_SemesterProjekt.Shared.Models;
using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.JSInterop;

namespace Anden_SemesterProjekt.Client.Components.Varer
{
    public partial class VareListComponent
    {
        [Parameter, EditorRequired]
        public List<Vare>? Varer { get; set; } = new List<Vare>();
        [Inject] private IJSRuntime JS {  get; set; } //JavaScript runtime
        [Inject] public IVareClientService VareClientService { get; set; }

        public string searchString = "";
        public bool IsLoading { get; set; } = true; 

        private Vare valgtVare = new Vare();
        private Vare redigeretVare = new Vare();

        [Parameter]
        public EventCallback<Vare> OnSelectVare { get; set; }
        [Parameter]
        public EventCallback<Vare> OnEditVare { get; set; }
        [Parameter]
        public EventCallback<Vare> OnDeleteVare { get; set; }

        private int Id; 
        private bool detailsModal = false;
        private bool editModal = false;

        protected override async Task OnInitializedAsync()
        {
            try 
            { 
                Varer = await VareClientService.GetAktiveVarer(); 
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fejl ved hentning af varer: {e.Message}");
            }
            finally
            {
                IsLoading = false; 
            }
            
        }

        private void VareBeskrivelse(Vare vare)
        {
            foreach (var s in Varer)
            {
                if (s.Id == vare.Id)
                {
                    valgtVare = vare;
                    detailsModal = true;
                    StateHasChanged();
                }
                else
                {
                    detailsModal = false;
                    StateHasChanged();
                }
            }
        }

        public void UpdateList(List<Vare> updatedVarer)
        {
            Varer = updatedVarer;
            StateHasChanged();
        }

        private void RedigerVare(Vare vare)
        {
            valgtVare = vare;
            redigeretVare = new Vare
            {
                Id = vare.Id,
                Beskrivelse = vare.Beskrivelse,
                Pris = vare.Pris,
            };
            editModal = true;
            StateHasChanged();
        }

        private void CloseModal()
        {
            detailsModal = false;
        }
        private async Task CloseEditModal()
        {
            editModal = false;
        }

        private async Task UpdateVare()
        {
            var response = await VareClientService.PutVare(redigeretVare);
            if (response != null)
            {
                var successBox = await JS.InvokeAsync<string>("alert", "Varen er opdateret.");
                detailsModal = false;
                Varer = await VareClientService.GetAktiveVarer();
                detailsModal = true;
                editModal = false;
                detailsModal = false;
            }
        }

        private async Task DeleteVare(Vare vare)
        {
            var confirmDelete = await JS.InvokeAsync<bool>("confirm", "Er du sikker på at du vil slette denne vare?");
            if (confirmDelete)
            {
                //Søren - hjælp til metode.
            }
        }
    }

}
