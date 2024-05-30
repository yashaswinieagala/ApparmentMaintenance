using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppartmentServiceBE.Models.Domain;
using AppartmentServiceBE.Models.DTO;
using AppartmentServiceBE.Repositories.Implementation;
using AppartmentServiceBE.Repositories.Interface;
using System.Reflection.Metadata.Ecma335;
using Azure.Core;

namespace AppartmentServiceBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatDetailsController : ControllerBase
    {
        private readonly INewFlat FlatRepo;
        private readonly IComplex icomplex;

        public FlatDetailsController(INewFlat FlatRepo, IComplex icomplex)
        {
            this.FlatRepo = FlatRepo;
            this.icomplex = icomplex;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlatdetails(RequestFlatDto request)
        {
            var flat = new flatDetails
            {
                flatId = request.flatId,
                flatNo = request.flatNo,
                complexId = request.complexId,
                ownerName = request.ownerName,
               
                size = request.size,
                facing = request.facing,
                contactNumbers = request.contactNumbers,
                email = request.email,
                occupants = request.occupants,
                selectedServices = request.selectedServices,

            };
            await FlatRepo.CreateAsync(flat);
            var response = new flatDetails
            {
                flatId = flat.flatId,
                flatNo = flat.flatNo,
                complexId = flat.complexId,
                ownerName = flat.ownerName,
       
                size = flat.size,
                facing = flat.facing,
                contactNumbers = flat.contactNumbers,
                email = flat.email,
                occupants = flat.occupants,
                selectedServices = flat.selectedServices,
            };
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFlatDetails()
        {
            var flatDetails = await FlatRepo.GetAllAsync();

            if (flatDetails == null)
            {
                return NotFound();
            }

            // Order by complexId before mapping to DTOs
            var orderedDetails = flatDetails.OrderBy(flat => flat.complexId).ToList();

            var response = orderedDetails.Select(flat => new flatDetailsDto
            {
                flatId = flat.flatId,
                flatNo = flat.flatNo,
                complexId = flat.complexId,
                ownerName = flat.ownerName,
                size = flat.size,
                facing = flat.facing,
                contactNumbers = flat.contactNumbers,
                email = flat.email,
                occupants = flat.occupants,
                selectedServices = flat.selectedServices,
            }).ToList();

            return Ok(response);
        }

        [HttpGet("byComplexId")]
        public async Task<ActionResult<IEnumerable<flatDetailsDto>>> GetAllFlatDetailsByComplexId(int complexId)
        {
            var flatDetails = await FlatRepo.NewFlatDetails(complexId);
          
            if (flatDetails == null)
            {
                return NotFound();

            }
            var response = flatDetails.Select(flats => new flatDetailsDto
            {
                flatId = flats.flatId,
                flatNo = flats.flatNo,
                complexId = flats.complexId,
                ownerName = flats.ownerName,
                size = flats.size,
                facing = flats.facing,
                contactNumbers = flats.contactNumbers,
                email = flats.email,
                occupants = flats.occupants,
                selectedServices = flats.selectedServices,


            }).ToList();


            return Ok(response);
        }
     

    }
    }
