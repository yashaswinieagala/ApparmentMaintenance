using AppartmentServiceBE.Models.Domain;

namespace AppartmentServiceBE.Repositories.Interface
{
    public interface INewFlat
    {
        Task<flatDetails> CreateAsync(flatDetails newflat);
        Task<IEnumerable<flatDetails>> GetAllAsync();
        Task<IEnumerable<flatDetails>> NewFlatDetails(int complexId);

    }
}

