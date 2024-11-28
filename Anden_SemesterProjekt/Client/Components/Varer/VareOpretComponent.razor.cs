using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Components.Varer
{
    public partial class VareOpretComponent
    {
    private Vare? vareModel = new Vare();
        private EditContext editContext;
        private bool isSubmitting = false;

        [Inject]
        public IVareClientService VareService { get; set; }

        [Parameter]
        public EventCallback OnVareAdded { get; set; }

        protected override void OnInitialized()
        {
            editContext = new EditContext(vareModel);
        }


        private async Task HandleValidSubmit()
        {
            isSubmitting = true;

            try
            {
                var result = await VareService.PostVare(vareModel); //Sender varen til serveren via VareService

                if (result != null) //Tjekker om serveren har returneret en gyldig vare
                {
                    Console.WriteLine($"Vare oprettet med ID: {result.Id}"); //Udskriver ID på den oprettede vare - succesmeddelelse
                    vareModel = new Vare(); //Nulstiller modellen, så formularen bliver tom
                    editContext = new EditContext(vareModel); //Opretter en ny EditContext til den nulstillede model
                }
                else
                {
                    Console.WriteLine("Fejl: Varen blev ikke oprettet."); //Fejlmeddelelse hvis serveren ikke returnerer en gyldig vare
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

        private void HandleInvalidSubmit() //Kaldes hvis formularen indeholder invalid data
        {
            Console.WriteLine("Formularen indeholder fejl.");
        }
    }
}

