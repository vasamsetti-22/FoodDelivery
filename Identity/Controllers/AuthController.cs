using FoodDelivery.Identity.Models;
using FoodDelivery.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Identity.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IdentityContext _context;
    private readonly TokenService _tokenService;
    private readonly RoleManager<IdentityRole> _roleManager;  
    public AuthController(UserManager<IdentityUser> userManager,  RoleManager<IdentityRole> roleManager, IdentityContext context, TokenService tokenService)
    {
        _userManager = userManager;
        _context = context;
        _tokenService = tokenService;
        _roleManager = roleManager;
    }
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        IdentityResult roleResult;

        // foreach (var roleName in  Enum.GetValues(typeof(RegistrationType)))
        // {
        //     var roleExist = await _roleManager.RoleExistsAsync(roleName.ToString());
        //     if (!roleExist)
        //     {
        //         roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName.ToString()));
        //     }
        // }
        
        string role = ((RegistrationType)request.RegistrationType).ToString();
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var defaultrole = _roleManager.FindByNameAsync(role).Result;
        if (defaultrole == null)  
        { 
            return BadRequest(ModelState);
        } 
        var user = new IdentityUser { UserName = request.Email, Email = request.Email };  
        var result = await _userManager.CreateAsync(
            user,
            request.Password
        );
        IdentityResult roleresult = await  _userManager.AddToRoleAsync(user, defaultrole.Name);

        if (result.Succeeded)
        {
            request.Password = "";
            return CreatedAtAction(nameof(Register), new {email = request.Email}, request);
        }
        foreach (var error in result.Errors) {
            ModelState.AddModelError(error.Code, error.Description);
        }
        return BadRequest(ModelState);
    }
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var managedUser = await _userManager.FindByEmailAsync(request.Email);
        if (managedUser == null)
        {
            return BadRequest("Bad credentials");
        }
        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);
        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }
        var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);
        if (userInDb is null)
            return Unauthorized();
        var roles = await _userManager.GetRolesAsync(managedUser);
        var accessToken = _tokenService.CreateToken(userInDb, roles);
        await _context.SaveChangesAsync();
        return Ok(new AuthResponse
        {
            Username = userInDb.UserName,
            Email = userInDb.Email,
            Token = accessToken,
        });
    }

    private async Task createRolesAsync(){

    }
}