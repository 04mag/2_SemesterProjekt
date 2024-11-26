using Anden_SemesterProjekt.Shared.Models;
using Anden_SemesterProjekt.Client.Components;
using Microsoft.AspNetCore.Components;
using Anden_SemesterProjekt.Client.Services;

namespace Anden_SemesterProjekt.Client.Pages
{
    public partial class OrdreOpretPage
    {
        [Inject]
        public IOrdreClientService OrdreService { get; set; }

        public Ordre OrdreModel { get; set; } = new Ordre();

        public Kunde? KundeModel { get; set; }
        public KundeScooter? KundeScooterModel { get; set; }
        public Mekaniker? MekanikerModel { get; set; }
        public UdlejningsScooter? UdlejningsScooterModel { get; set; }

        private void OpretOrdre()
        {
            if (KundeScooterModel != null) OrdreModel.KundeScooterId = KundeScooterModel.ScooterId;
            if (MekanikerModel != null) OrdreModel.MekanikerId = MekanikerModel.MekanikerId;
            if (UdlejningsScooterModel != null)
            {
                OrdreModel.Udlejning = new Udlejning
                {
                    UdlejningsScooterId = UdlejningsScooterModel.ScooterId,
                    StartDato = OrdreModel.StartDato,
                    SlutDato = OrdreModel.SlutDato
                };
            }
        }
    }

}
