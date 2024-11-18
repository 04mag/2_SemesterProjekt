
using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Pages
{
    public partial class KundePage
    {
        private List<Kunde>? kunder;
        public IKundeClientService KundeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("Før indlæsning");
            var result = await KundeService.GetKunder();
            Console.WriteLine($"Midt i indlæsning: {result.GetType()}");
            kunder = result;
        }

        private async Task OnKundeAddedHandler()
        {
            try
            {
                kunder = await KundeService.GetKunder();
            }
            catch
            {
                kunder = null;
            }
        }

        private async Task OnEditKunde(Kunde kunde)
        {
            
        }

        private async Task OnDeleteKunde(Kunde kunde)
        {
            await KundeService.DeleteKunde(kunde.KundeId);
            kunder = await KundeService.GetKunder();
        }
    }
}
