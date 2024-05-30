using AppartmentServiceBE.Data;
using AppartmentServiceBE.Models.Domain;
using AppartmentServiceBE.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppartmentServiceBE.Repositories.Implementation
{
    public class ComplexRepo:IComplex
    {
        private readonly ApplicationDbContext dbContext;

        public ComplexRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //Task<IEnumerable<complexDetails>> GetComplexDetails(int complexId);

       
        public async Task<complexDetails> Createcomplex(complexDetails newcomplex)
        {
            await dbContext.ComplexDetails.AddAsync(newcomplex);
            await dbContext.SaveChangesAsync();
            return newcomplex;
        }

        public async Task<IEnumerable<complexDetails>> GetAllAsync()
        {
            return await dbContext.ComplexDetails.ToListAsync();
        }
        public async Task<IEnumerable<complexDetails>> GetComplexDetails()
        {
            return await dbContext.ComplexDetails.ToListAsync();
        }


    }
}
