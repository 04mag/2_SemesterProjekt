using Anden_SemesterProjekt.Shared.Models;
using System.Net.Http.Json;
using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;


namespace Anden_SemesterProjekt.Client.Pages
{
    public partial class ScooterLager
    {
        private UdlejningsScooter nyUdlejningsScooter = new UdlejningsScooter();
        private List<UdlejningsScooter> udlejningsScootere = new List<UdlejningsScooter>();
        private string? newPhone;
        private string? successMessage;
        private string? errorMessage;
        private List<Mærke> mærker = new List<Mærke>();
        private int? valgtScooterMærkeId;
        private Mærke mærke = new Mærke();
        [Inject]
        public IMærkeClientService MærkeService { get; set; }
        [Inject]
        public IUdlejningsScooterClientService UdlejningsScooterService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            mærker = await MærkeService.GetMærker();
            udlejningsScootere = await UdlejningsScooterService.GetUdlejningsScootere();
        }

        private async Task HandleValidSubmit()
        {
            try
            {
                successMessage = "Scooter oprettet med succes!";
                errorMessage = null;

                if (valgtScooterMærkeId == null)
                {
                    throw new InvalidOperationException("Valgt scooter mærke ID er null.");
                }
                
                mærke.MærkeId = valgtScooterMærkeId.Value;
                mærke.ScooterMærke = mærker.FirstOrDefault(m => m.MærkeId == valgtScooterMærkeId.Value).ScooterMærke;
                nyUdlejningsScooter.MærkeId = valgtScooterMærkeId.Value;
                nyUdlejningsScooter.ErAktiv = true;
                nyUdlejningsScooter.ErTilgængelig = true;
                nyUdlejningsScooter.Udlejninger = new List<Udlejning>();
                nyUdlejningsScooter.ScooterMærke = mærke;

                var response = await UdlejningsScooterService.AddUdlejningsScooter(nyUdlejningsScooter);
                if (response <= 0)
                {
                    throw new InvalidOperationException("Fejl ved oprettelse af udlejnings scooter.");
                }
                else 
                {
                    Console.WriteLine(successMessage);
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Fejl: {ex.Message}";
                Console.WriteLine(errorMessage);
            }




        }
    }


}
