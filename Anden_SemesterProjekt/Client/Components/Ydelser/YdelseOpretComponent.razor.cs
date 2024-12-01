using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Anden_SemesterProjekt.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.JSInterop;

namespace Anden_SemesterProjekt.Client.Components.Ydelser
{
    public partial class YdelseOpretComponent
    {
        private Ydelse ydelseModel = new Ydelse();
        private EditContext editContext;
        private bool isSubmitting = false;
        private bool addModal = false;

        [Inject]
        public IVareClientService VareService { get; set; }

        [Parameter]
        public EventCallback OnYdelseAdded { get; set; }

        [Inject] private IJSRuntime JS { get; set; }


        protected override void OnInitialized()
        {
            editContext = new EditContext(ydelseModel);
        }

        private async Task YdelseHandleValidSubmit()
        {
            isSubmitting = true;

            try
            {
                var result = await VareService.PostVare(ydelseModel); //Sender ydelsen til serveren via VareService

                if (result != null) //Tjekker om serveren har returneret en gyldig ydelse
                {
                    Console.WriteLine($"Ydelsen oprettet med ID: {result.Id}"); //Udskriver ID på den oprettede ydelse - succesmeddelelse
                    ydelseModel = new Ydelse(); //Nulstiller modellen, så formularen bliver tom
                    editContext = new EditContext(ydelseModel); //Opretter en ny EditContext til den nulstillede model
                    await OnYdelseAdded.InvokeAsync();

                }
                else
                {
                    Console.WriteLine("Fejl: Ydelsen blev ikke oprettet."); //Fejlmeddelelse hvis serveren ikke returnerer en gyldig ydelse
                }
            }

            catch (Exception e) //Fejlmeddelelse hvis der opstår en exception
            {
                Console.WriteLine($"Fejl: {e.Message}"); // Udskriver fejlbeskeden
            }

            finally
            {
                isSubmitting = false; //Resetter isSubmitting til false, så formularen kan bruges igen, uanset som processen lykkedes eller ej. 
            }
        }
    }
}
