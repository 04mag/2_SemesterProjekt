using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Text;

namespace Anden_SemesterProjekt.Client.Pages.Ordrer
{
    public partial class OrdreEditPage
    {
        [Inject]
        public IOrdreClientService OrdreService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        private IJSRuntime JS { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Ordre? OrdreModel { get; set; } = new Ordre();

        public EditContext EditContext { get; set; }

        private bool isBusy = false;

        private bool ordreAfsluttet = false;

        private bool ordreErBetaltState;

        protected override void OnInitialized()
        {
            EditContext = new EditContext(OrdreModel);
        }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("Ordre indhentes!");
            var ordreResult = await OrdreService.GetOrdre(Id);
            
            if (ordreResult != null)
            {
                OrdreModel = ordreResult;
                ordreErBetaltState = OrdreModel.ErBetalt;
            }
        }

        public async Task OnValidSubmit()
        {
            isBusy = true;

            if (OrdreModel != null && OrdreModel.Udlejning != null)
            {
                OrdreModel.Udlejning.SlutDato = OrdreModel.SlutDato;
            }

            if (OrdreModel != null && ordreAfsluttet)
            {
                OrdreModel.ErAfsluttet = true;

                if (OrdreModel.Udlejning != null)
                {
                    OrdreModel.Udlejning.UdlejningsScooter!.ErTilgængelig = true;
                }
            }

            if (OrdreModel != null && !ordreErBetaltState && OrdreModel.ErBetalt)
            {
                OrdreModel.BetalingsDato = DateTime.Now;
            }

            if (OrdreModel != null)
            {
                var response = await OrdreService.UpdateOrdre(OrdreModel);

                if (response.IsSuccessStatusCode)
                {
                    await JS.InvokeVoidAsync("alert", "Ordren er blevet opdateret!");
                    NavigationManager.NavigateTo("/ordre");
                }
                else
                {
                    await JS.InvokeVoidAsync("alert", "Ordren kunne ikke opdateres!");
                }
            }
            else
            {
                await JS.InvokeVoidAsync("alert", "Ordren kunne ikke findes!");
            }

            isBusy = false;
        }

        public void OnInvalidSubmit()
        {
            Console.WriteLine("Invalid submit!");
        }
    }
}
