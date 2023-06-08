using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LoginAPI.Models;


namespace LoginAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {        
        private readonly SignInManager<ApplicationUser> _signInManager;
     
        public LoginController(SignInManager<ApplicationUser> signInManager)
        {      
            _signInManager = signInManager;
            
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

            var result = await _signInManager.PasswordSignInAsync(user.Email!, user.Password, user.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
                {                    
                    return Ok(result);
                }
           
           return BadRequest("Login inválido");
        }
    }
}