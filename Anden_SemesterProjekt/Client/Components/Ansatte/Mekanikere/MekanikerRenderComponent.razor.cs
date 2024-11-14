using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Components.Ansatte.Mekanikere
{
    public partial class MekanikerRenderComponent
    {
        [Parameter, EditorRequired]
        public Mekaniker Mekaniker { get; set; }
    }
}
