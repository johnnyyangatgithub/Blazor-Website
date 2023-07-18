using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerceWebsite.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController (IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
        {
            var response = await _authService.Register(
                new User
                {
                    Email = request.Email
                },
                request.Password );

            if(!response.Success)
            {
                return BadRequest( response );
            }

            return Ok( response );
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
        {
            var response = await _authService.Login( request.Email, request.Password );
            if ( !response.Success )
            {
                return BadRequest( response );
            }

            return Ok( response );
        }

        /// <summary>
        /// Changes the password for the user by using newPassword in the request body.
        /// </summary>
        /// <param name="newPassword">New password is required.</param>
        /// <returns></returns>
        [HttpPost("change-password"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword ( [FromBody] string newPassword)
        {
            var userId = User.FindFirstValue( ClaimTypes.NameIdentifier );
            var response = await _authService.ChangePassword( int.Parse( userId ), newPassword );

            if(!response.Success)
            {
                return BadRequest( response );
            }

            return Ok( response );
        }
    }
}

