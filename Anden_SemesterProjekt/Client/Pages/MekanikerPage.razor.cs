using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Pages
{
    public partial class MekanikerPage
    {
        private List<Mekaniker> mekanikerList = new List<Mekaniker>();


        [Inject]
        public IAnsatClientService AnsatService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            mekanikerList = await AnsatService.GetMekanikere();
        }

        //Til test og reference til implementering af vælg knap.Skal slettes senere
        public Mekaniker? SelectedMekaniker { get; set; }
        private void OnSelectHandler(Mekaniker mekaniker)
        {
            SelectedMekaniker = mekaniker;
        }
    }
}
