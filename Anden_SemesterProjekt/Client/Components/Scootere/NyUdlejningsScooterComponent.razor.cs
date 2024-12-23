﻿using Anden_SemesterProjekt.Shared.Models;
using System.Net.Http.Json;
using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Microsoft.JSInterop;


namespace Anden_SemesterProjekt.Client.Components.Scootere
{
    public partial class NyUdlejningsScooterComponent
    {
        [Inject] private IJSRuntime JS { get; set; } // JavaScript runtime

        private UdlejningsScooter nyUdlejningsScooter = new UdlejningsScooter();
        private List<Mærke> mærker = new List<Mærke>();
        private int nyScooterMærkeId;
        private int? valgtScooterMærkeId = new int();
        private bool addModal = false;
        [Inject] public IMærkeClientService MærkeService { get; set; }
        [Inject] public IScooterClientService UdlejningsScooterService { get; set; }
        [Parameter] public EventCallback OnScooterAdded { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var mærkerResult = await MærkeService.GetMærker();

            if (mærkerResult != null)
            {
                mærker = mærkerResult;
            }
        }
        private async Task HandleValidSubmit()
        {
            try
            {
                if (nyScooterMærkeId == 0)
                {
                    throw new InvalidOperationException("Valgt scooter mærke ID er null.");
                }
                // Tildel data til nyUdlejningsScooter
                nyUdlejningsScooter.MærkeId = nyScooterMærkeId;
                nyUdlejningsScooter.ErAktiv = true;
                
                // Kald API for at gemme
                var response = await UdlejningsScooterService.CreateScooter(nyUdlejningsScooter);

                if (response != null)
                {
                    // Tving UI-opdatering
                    await OnScooterAdded.InvokeAsync(); // Kalder parent component's HandleChildChanged metode
                    StateHasChanged();
                    nyUdlejningsScooter = new UdlejningsScooter();
                    nyScooterMærkeId = new int();
                    addModal = false;
                    await JS.InvokeVoidAsync("alert", "Scooteren blev oprettet.");
                }
                else
                {
                    throw new InvalidOperationException("API oprettelsen mislykkedes.");
                }
            }
            catch (Exception ex)
            {
                var errorBox = await JS.InvokeAsync<string>("alert", ex.Message);
            }
        }
        private async Task ShowAddModal()
        {
            // Hent mærker
            var mærkerResult = await MærkeService.GetMærker();

            // Hvis der er mærker i databasen, så tildel dem til den lokale liste
            if (mærkerResult != null)
            {
                mærker = mærkerResult;
            }
            // Åben modal
            addModal = true;
            StateHasChanged();
        }
        private void CloseAddModal()
        {
            addModal = false;
        }
    }
}