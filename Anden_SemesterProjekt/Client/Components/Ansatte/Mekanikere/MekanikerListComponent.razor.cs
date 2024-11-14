using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Components.Ansatte.Mekanikere
{
    public partial class MekanikerListComponent
    {
        [Parameter, EditorRequired]
        public List<Mekaniker> Mekanikere { get; set; }
    }
}
