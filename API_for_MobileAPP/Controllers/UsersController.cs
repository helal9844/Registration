using BL;
using Microsoft.AspNetCore.Mvc;

namespace API_for_MobileAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            return _userManager.GetAllUsers();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<UserDTO> GetUser(int id)
        {
            var user = _userManager.GetUser(id);
            if (user == null)
                return NotFound("Not Found");
            return Ok(user);
        }
        [HttpPost]
        [Route("Register")]
        public ActionResult<UserDTO> AddUser(UserDTO user)
        {
            
            var userDTO = _userManager.AddUser(user);
            return CreatedAtAction("GetUser",new {id = userDTO.Id },userDTO);
        }
        [HttpPut]
        public ActionResult EditUser( UserDTO userdto) 
        {
            
            var result = _userManager.UpdateUser(userdto);
            if (result)
                return Ok("Edited");
            return BadRequest("Not Valid");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id) 
        {
            _userManager.DeleteUser(id);
            return Ok("Deleted");
        }
        [HttpGet]
        [Route("UsersWithCountry")]
        public ActionResult<List<UserWriteDTO>> GetUsersWithCountry()
        {
            
            return _userManager.GetUsersWithCountry();
        }
    }
}
