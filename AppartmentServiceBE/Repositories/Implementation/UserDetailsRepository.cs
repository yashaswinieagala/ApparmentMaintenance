using AppartmentServiceBE.Data;
using AppartmentServiceBE.Models.Domain;
using AppartmentServiceBE.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppartmentServiceBE.Repositories.Implementation
{
    public class UserDetailsRepository : IuserDetails
    {
        private readonly ApplicationDbContext dbContext;
        public UserDetailsRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserDetails> CreateAsync(UserDetails userDetails)
        {
            await dbContext.UserTable.AddAsync(userDetails);
            await dbContext.SaveChangesAsync();
            return userDetails;
        }

        public async Task<UserDetails> FindByEmailAsync(string email)
        {
            var user = await dbContext.UserTable.FirstOrDefaultAsync(u => u.email == email);
            return user;
        }

        public async Task<UserDetails> FindMyDetailsAsync(string username, string password)
        {
            var user = await dbContext.UserTable.FirstOrDefaultAsync(u => u.userName == username && u.password == password);
            return user;
        }

        public async Task<IEnumerable<UserDetails>> GetAllAsync()
        {
            return await dbContext.UserTable.ToListAsync();
        }

        public async Task<ActionResult<UserDetails>> UsersbyId(int userid)
        {
            return await dbContext.UserTable.FirstOrDefaultAsync(c => c.userId == userid);
        }
    }
}
