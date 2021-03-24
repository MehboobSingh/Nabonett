using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace NabonettWebAPI.Controllers
{
    [Route("Users")]
    public class UserController: Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            
            var result = await userService.GetAllAsync();
            
            return result;
        }

        [HttpGet("/user/{id}")]
        public async Task<User> GetAllAsync(string ID)
        {

            var result = await userService.GetByIDAsync(ID);

            return result;
        }

        [HttpGet("/user/{id}/Email")]
        public List<Email> GetEmailsByIDAsync(string ID)
        {



            return new List<Email>();
        }

    }
}