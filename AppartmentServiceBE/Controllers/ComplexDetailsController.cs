using AppartmentServiceBE.Models.Domain;
using AppartmentServiceBE.Models.DTO;
using AppartmentServiceBE.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppartmentServiceBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplexDetailsController : ControllerBase
    {
        private readonly IComplex iComplexRepo;

        public ComplexDetailsController(IComplex iComplexRepo)
        {
            this.iComplexRepo = iComplexRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComplex(requestComplexDto request)
        {
            var complex = new complexDetails
            {
                complexId = request.complexId,
                noofFlats = request.noofFlats,
            };
            await iComplexRepo.Createcomplex(complex);

            var response = new requestComplexDto
            {
                complexId = request.complexId,
                noofFlats = request.noofFlats
            };
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetComplexDetails()
        {
            var complexs = await iComplexRepo.GetAllAsync();

            var response = new List<responsecomplexDto>();
            foreach (var complex in complexs) 
            {
                response.Add(new responsecomplexDto
                {
                    complexId = complex.complexId,
                    noofFlats = complex.noofFlats
                });
            }
            return Ok(response);
        }
    }
}
