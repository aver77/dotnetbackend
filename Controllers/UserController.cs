using _3labBackEnd.Services;
using _3labBackEnd.Models.ViewModels.UserViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3labBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        //used maybe
        [HttpGet]
        public IActionResult GetAllUsers() 
        {
            var listUser = _userService.GetAllUsers();
            return Ok(listUser);
        }

        //used
        [HttpGet]
        //экземпляр класса VM
        public IActionResult GetById(GetUserByIdVM userModel)
        {
            if (userModel.Id == Guid.Empty) return BadRequest();
            // методы из сервисов!
            var user = _userService.GetUserById(userModel);
            return Ok(user);
        }

        //used
        [HttpPost]
        public IActionResult CreateUser(CreateUserVM userModel)
        {
            var isSuccess = _userService.SaveCreationUser(userModel);
            return Ok(isSuccess);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteUserVM userModel)
        {
            var isSuccess = _userService.DeleteUser(userModel);
            return Ok(isSuccess);
        }
    }
}
