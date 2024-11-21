using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Components.Vare
{
    public partial class VareOpretComponent
    {
    private Vare? vareModel = new Vare();
        private EditContext editContext;
        private bool isSubmitting = false;

        [Inject]
        public IVareClientService VareService { get; set; }

        protected override void OnInitialized()
        {
            editContext = new EditContext(vareModel);
        }


        private async Task HandleValidSubmit()
        {
            isSubmitting = true;

            try
            {
                var result = await VareService.PostVare(vareModel);

                if (result != null)
                {
                    Console.WriteLine($"Vare oprettet med ID: {result.Id}");
                    vareModel = new Vare(); //Nulstiller model 
                    editContext = new EditContext(vareModel); //Opdaterer kontekst
                }
                else
                {
                    Console.WriteLine("Fejl: Varen blev ikke oprettet.");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine($"Fejl: {e.Message}");
            }

            finally
            {
                isSubmitting = false;
            }
        }

        private void HandleInvalidSubmit()
        {
            Console.WriteLine("Formularen indeholder fejl.");
        }
    }
}
}
