using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LoginAPI.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using LoginAPI.Services;

namespace LoginAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public string Username { get; set; }
        public Usuario usuario { get; set; }
        public LoginController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

        }
        //  public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        // {
        //     returnUrl ??= Url.Content("~/");

        //     ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        //     if (ModelState.IsValid)
        //     {
        //         // This doesn't count login failures towards account lockout
        //         // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        //         var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
        //         if (result.Succeeded)
        //         {
        //             _logger.LogInformation("User logged in.");
        //             return LocalRedirect(returnUrl);
        //         }
        //         if (result.RequiresTwoFactor)
        //         {
        //             return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
        //         }
        //         if (result.IsLockedOut)
        //         {
        //             _logger.LogWarning("User account locked out.");
        //             return RedirectToPage("./Lockout");
        //         }
        //         else
        //         {
        //             ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //             return Page();
        //         }
        //     }

        //     // If we got this far, something failed, redisplay form
        //     return Page();
        // }
        [HttpPost("login")]
        public async Task<IActionResult> Logar([FromBody] Usuario user)
        {
            //recupera o usuário
            user.Username = user.Email;
            var usuarioEncontrado = await _userManager.FindByEmailAsync(user.Email!);
            
            //verifica se o usuário existe
            if (usuarioEncontrado == null)
            {
                return NotFound();
            }

            var result = await _signInManager.PasswordSignInAsync(
                usuarioEncontrado, user.Password, user.RememberMe, false);

            if (result.Succeeded)
            {
                
                var token = TokenService.GenerateToken(user);  
                Response.Headers.Add("Authorization",$"Bearer {token}");
                //var jsonResponse = JsonConvert.SerializeObject(Response.Headers);
               // await LoadAsync(usuario);
                return Ok(new AuthenticatedResponse{ Token = token });
            }

            return BadRequest("Login inválido");
        }
        
        [HttpGet("logout")]        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            var headers = Response.Headers;
            return Ok();          
        }



        [HttpGet("testeAPI")]
        [Authorize]
        public IActionResult testandoApi() 
        {            
            return Ok("teste ok");
        }
    }
}