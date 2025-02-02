﻿using Anden_SemesterProjekt.Shared.Models;
using System.Net.Http.Json;
using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Microsoft.JSInterop;



namespace Anden_SemesterProjekt.Client.Pages
{
    public partial class ScooterLager
    {
        // Dependency Injection af service
        [Inject] public IScooterClientService UdlejningsScooterService { get; set; }

        private List<UdlejningsScooter>? udlejningsScootere = new List<UdlejningsScooter>();

        // Denne metode bliver kaldt fra NyUdlejningsScooterComponent når en scooter er tilføjet
        private async Task HandleChildChanged()
        {
            // Opdater listen af udlejningsscootere efter ny scooter er tilføjet
            udlejningsScootere = await UdlejningsScooterService.GetAllUdlejningsScootereAsync();
            StateHasChanged();
        }

        // Simulerer at hente data fra en service eller API
    }
}
