public class ScooterService : IScooterService
{
    private readonly IScooterRepository _scooterRepository;

    public ScooterService(IScooterRepository scooterRepository)
    {
        _scooterRepository = scooterRepository;
    }

    public async Task<Scooter?> GetScooterByIdAsync(int id)
    {
        return await _scooterRepository.ReadScooterAsync(id);
    }

    public async Task<List<Scooter>> GetAllScootersAsync()
    {
        return await _scooterRepository.ReadScootersAsync();
    }

    public async Task<int> CreateScooterAsync(Scooter scooter)
    {
        return await _scooterRepository.CreateScooterAsync(scooter);
    }

    public async Task<int> UpdateScooterAsync(Scooter scooter)
    {
        return await _scooterRepository.UpdateScooterAsync(scooter);
    }

    public async Task<int> DeleteScooterAsync(int id)
    {
        return await _scooterRepository.DeleteScooterAsync(id);
    }
}
