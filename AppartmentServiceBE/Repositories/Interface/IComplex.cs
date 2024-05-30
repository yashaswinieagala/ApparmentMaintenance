using AppartmentServiceBE.Models.Domain;

namespace AppartmentServiceBE.Repositories.Interface
{
    public interface IComplex
    {
        Task<complexDetails> Createcomplex(complexDetails newComplex);
        Task<IEnumerable<complexDetails>> GetAllAsync();
        Task<IEnumerable<complexDetails>> GetComplexDetails();
    }
}
