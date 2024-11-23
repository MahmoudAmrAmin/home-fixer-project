using Microsoft.AspNetCore.Identity;
using Project.BLL.DTOs.Auth;
using Project.BLL.DTOs.Person;
using Project.BLL.DTOs.Technician;
using Project.BLL.DTOs.User;
using Project.BLL.ServiceContracts;
using Project.DAL.Entities;

namespace Project.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITechnicianService _technicianService;
        private readonly IClientService _userService;

        public AuthService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITechnicianService technicianService,
            IClientService userService

            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _technicianService = technicianService;
            _userService = userService;
        }

        public async Task<PersonDto?> LogIn(LogInDto logInDto)
        {
            var user = await _userManager.FindByEmailAsync(logInDto.Email);
            if (user == null)
            {
                // User not found
                return null;
            }

            bool isCorrectPassword = await _userManager.CheckPasswordAsync(user, logInDto.Password);
            if (!isCorrectPassword)
            {
                // Invalid password
                return null;
            }

            // Sign in user with persistent login
            var result = await _signInManager.PasswordSignInAsync(user, logInDto.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // Fetch the user's roles
                var roles = await _userManager.GetRolesAsync(user);

                var personDto = new PersonDto
                {
                    ApplicationId = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Role = roles.FirstOrDefault() // Assumes user has at least one role, handle null if necessary
                };

                return personDto;
            }

            // Authentication failed
            return null;
        }


        public async Task<List<string>> RegisterUser(RegisterUserDto registerDto)
        {
            List<string> errors = new List<string>();

            var user = new ApplicationUser
            {
                UserName = registerDto.Email.Split('@')[0],
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
            };

            var res = await _userManager.CreateAsync(user, registerDto.Password);

            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "USER");

                _userService.Add(new AddClientDto
                {
                    ApplicationUserId = user.Id,
                });
            }
            else
            {
                foreach (var error in res.Errors)
                {
                    errors.Add(error.Description);
                }
            }
            return errors;
        }

        public async Task<List<string>> RegisterTechnician(RegisterTechnicianDto registerDto)
        {
            List<string> errors = new List<string>();

            var user = new ApplicationUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                UserName = registerDto.Email.Split('@')[0],
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
            };

            var res = await _userManager.CreateAsync(user, registerDto.Password);

            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "TECHNICAIN");

                _technicianService.Add(new AddTechnicianDto
                {
                    ApplicationUserId = user.Id,
                    SpecializationID = registerDto.SpecializationID,
                });
            }
            else
            {
                foreach (var error in res.Errors)
                {
                    errors.Add(error.Description);
                }
            }

            return errors;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }


    }


}
