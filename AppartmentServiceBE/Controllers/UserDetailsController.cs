using AppartmentServiceBE.Models.Domain;
using AppartmentServiceBE.Models.DTO;

using AppartmentServiceBE.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MeetingRoomBooking.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IuserDetails userrepository;
        public UserDetailsController(IuserDetails userrepository)
        {
            this.userrepository = userrepository;
        }


        [HttpPost]
        public async Task<IActionResult> Createuserdetails(RequestUserDto request)
        {

            try

            {



                if (ModelState.IsValid)

                {



                    var existingUser = await userrepository.FindByEmailAsync(request.email);



                    if (existingUser != null)

                    {
                        return BadRequest("Email is already registered.");

                    }




                    var user = new UserDetails

                    {
                        userId = request.userId,
                        userName = request.userName,
                        email = request.email,
                        password = request.password,
                        isAdmin = request.isAdmin,
                    };



                    // Assuming you have a user repository

                    var createdUser = await userrepository.CreateAsync(user);

                    //DateTime dt = DateTime.Parse(DateTime.Now.ToString());
                    //string s = dt.ToString("dd-MM-YYYY");

                    // Create a response object with the newly created user's data

                    var response = new UserDetailsdto

                    {
                        userId = user.userId,
                        userName = user.userName,
                        email = user.email,
                        password = user.password,
                        isAdmin = user.isAdmin,
                    };



                    return Ok(response); // Return a successful response

                }

                else

                {

                    // Handle invalid input data

                    return BadRequest(ModelState);

                }

            }

            catch (Exception ex)

            {

                // Handle exceptions, log errors, and return an appropriate error response

                return StatusCode(500, "Internal Server Error: " + ex.Message);

            }



            // return Ok(response);



        }


        [HttpPost("Auth")]
        public async Task<IActionResult> LoginDetails(string username, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userrepository.FindMyDetailsAsync(username, password);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "Invalid Username");
                return BadRequest(ModelState);
            }
            if (!IsPasswordValid(user.password, user.password))
            {
                ModelState.AddModelError("Password", "Invalid Password");
            }
            return Ok(user);
        }
        private bool IsPasswordValid(string storedPassword, string enteredPassword)
        {
            return storedPassword == enteredPassword;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllNewMeetingDetails()
        {
            var users = await userrepository.GetAllAsync();



            //map domain model to DTO



            var response = new List<UserDetailsdto>();

            foreach (var user in users)
            {
                response.Add(new UserDetailsdto
                {

                    userId = user.userId,
                    userName = user.userName,
                    email = user.email,
                    password = user.password,
                    isAdmin = user.isAdmin,


                });



            }



            return Ok(response);
        }




        //get user details by userid


        [HttpGet("byUserId")]
        public async Task<ActionResult<UserDetails>> UserById(int userid)
        {
            try
            {

                var result = await userrepository.UsersbyId(userid);
                if (result == null)
                {
                    return NotFound();

                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
