using AppartmentServiceBE.Data;
using AppartmentServiceBE.Models.Domain;
using AppartmentServiceBE.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppartmentServiceBE.Repositories.Implementation
{
    public class NewFlatRepo : INewFlat
    {
        private readonly ApplicationDbContext dbContext;
        public NewFlatRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<flatDetails> CreateAsync(flatDetails newFlat)
        {
            await dbContext.ApartMentDetails.AddAsync(newFlat);
            await dbContext.SaveChangesAsync();
            return newFlat;
        }
        public async Task<IEnumerable<flatDetails>> GetAllAsync()
        {
            return await dbContext.ApartMentDetails.ToListAsync();
        }

        public async Task<IEnumerable<flatDetails>> NewFlatDetails(int complexId)
        {
            return await dbContext.ApartMentDetails.Where(c => c.complexId == complexId).ToListAsync();
        }
        //var availableslots = allTimeslots.Except(bookedSlots).OrderBy(s => s).ToList();

    }
}
