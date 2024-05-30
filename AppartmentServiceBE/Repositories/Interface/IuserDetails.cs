using AppartmentServiceBE.Models.Domain;
using AppartmentServiceBE.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AppartmentServiceBE.Repositories.Interface
{
    public interface IuserDetails
    {
        Task<UserDetails> CreateAsync(UserDetails userDetails);

        Task<UserDetails> FindByEmailAsync(string email);
        Task<UserDetails> FindMyDetailsAsync(string username, string password);

        Task<IEnumerable<UserDetails>> GetAllAsync();

        Task<ActionResult<UserDetails>> UsersbyId(int userid);
    }
}
