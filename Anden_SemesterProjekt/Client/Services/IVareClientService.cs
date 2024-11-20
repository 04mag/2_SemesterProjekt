using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IVareClientService
    {
        Task<Vare?> PostVare(Vare vare);
        Task<List<Vare>?> GetAktiveVarerOgYdelser();
        Task<List<Vare>?> GetAktiveVarer();
        Task<List<Ydelse>?> GetAktiveYdelser();
        Task<Vare?> GetVare(int id);
        Task<HttpResponseMessage> PutVare(Vare vare);
        Task<HttpResponseMessage> DeleteVare(int id);


    }
}
