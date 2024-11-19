﻿using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Components
{
    public partial class OpretUdlejningComponent
    {
        Udlejning nyUdlejning = new Udlejning();
        UdlejningsScooter udlejningsScooter = new UdlejningsScooter();
        List<UdlejningsScooter> udlejningsScootere = new List<UdlejningsScooter>();
        List<Kunde> kunder = new List<Kunde>();
       [Inject] IUdlejningClientService UdlejningClientService { get; }
       [Inject] IUdlejningsScooterClientService UdlejningsScooterClientService { get; }

        public async Task OnInitializedAsync()
        {
            udlejningsScootere = await UdlejningsScooterClientService.GetUdlejningsScootere();

        }
        public async Task OpretUdlejning()
        {
            nyUdlejning.UdlejningsScooterId = nyUdlejning.Ordre.UdlejningsScooterId.Value;
            nyUdlejning.OrdreId = nyUdlejning.Ordre.OrdreId;
            await UdlejningClientService.AddUdlejningAsync(nyUdlejning);
        }
        public async Task HandleValidSubmit()
        {
            await OpretUdlejning();
        }

    }
}
