using Anden_SemesterProjekt.Shared.Models;
using System.Net.Http.Json;
using Anden_SemesterProjekt.Client.Services;


namespace Anden_SemesterProjekt.Client.Pages
{
    public partial class ScooterLager
    {
        private UdlejningsScooter nyUdlejningsScooter = new UdlejningsScooter();
        private string? newPhone;
        private string? successMessage;
        private string? errorMessage;
        private List<Mærke> mærker = new List<Mærke>();
        private int? valgtMærkeId;

        protected override async Task OnInitializedAsync()
        {
            mærker = await MærkeClientService.GetMærker();
        }
        private async Task HandleValidSubmit()
        {
            try
            {
                var response = await Http.PostAsJsonAsync("api/scootere", nyUdlejningsScooter);
                if (response.IsSuccessStatusCode)
                {
                    successMessage = "Kunde oprettet med succes!";
                    errorMessage = null;
                    nyUdlejningsScooter = new UdlejningsScooter
                    {
                    };
                }
                else
                {
                    successMessage = null;
                    errorMessage = "Kunne ikke oprette kunden.";
                }
            }
            catch (Exception ex)
            {
                successMessage = null;
                errorMessage = $"Fejl: {ex.Message}";
            }
        }

    }


}
