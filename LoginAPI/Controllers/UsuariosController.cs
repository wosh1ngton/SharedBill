using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using LoginAPI.Models;

namespace LoginAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;       
        private readonly UserManager<ApplicationUser> _userManager;

        public UsuariosController(
       
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
        {
       
            _userManager = userManager;
            _signInManager = signInManager;
        }

       [HttpPost("registrar")]
       public async Task<IActionResult> CriarUsuario([FromBody] Usuario usuario, [FromQueryAttribute] string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");            
            List<string> erros = new List<string>();
            if (usuario != null)
            {
                var user = CreateUser();

                //await _userStore.SetUserNameAsync(user, usuario.Email, CancellationToken.None);
                await _userManager.SetUserNameAsync(user, usuario.Email);
                await _userManager.SetEmailAsync(user, usuario.Email);
                var result = await _userManager.CreateAsync(user, usuario.Password);

                if (result.Succeeded)
                {
                    //_logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    // await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //     $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = usuario.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    erros.Add(error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return BadRequest(erros);
        }


        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }

}