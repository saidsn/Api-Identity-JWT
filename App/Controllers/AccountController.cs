using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Account;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;


namespace App.Controllers
{
    public class AccountController : AppController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterDTO user)
        {
            return Ok(await _accountService.RegisterAsync(user));
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO user)
        {
            var result = await _accountService.LoginAsync(user);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleDTO role)
        {
            await _accountService.CreateRoleAsync(role);
            return Ok();
        }

    }
}
