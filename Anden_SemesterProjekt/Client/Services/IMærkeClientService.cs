using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IMærkeClientService
    {
        public Task<Mærke?> GetMærke(int id);
        public Task<List<Mærke>?> GetMærker();
        public Task<int> AddMærke(Mærke mærke); 
        public Task<int> DeleteMærke(int id); 
        public Task<int> updateMærke(Mærke mærke); 
    }
}
