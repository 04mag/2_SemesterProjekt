using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace Anden_SemesterProjekt.Client.Components.Kunder
{
    public partial class KundeCreateComponent
    {
        private Kunde kundeModel = new Kunde();
        private EditContext editContext;

        protected override void OnInitialized()
        {
            editContext = new EditContext(kundeModel);
        }

        private void HandleValidSubmit()
        {
            Console.WriteLine("Form submitted");
        }

        private void HandleInvalidSubmit()
        {
            Console.WriteLine("Form not submitted");
        }
    }
}
