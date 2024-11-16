using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public interface IMærkeService
    {
        public Mærke? ReadMærke(int id);
        public List<Mærke>? ReadMærke();
        public int CreateMærke(Mærke mærke);
        public int UpdateMærke(Mærke mærke);
        public int DeleteMærke(int id);
    }
}
