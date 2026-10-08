using ASp_Tutorial._4Day;
using ASp_Tutorial._4Day.Dtos_4;
using Microsoft.AspNetCore.Mvc;

namespace ASp_Tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _UserService) : Controller
    {
        [HttpGet("getUsers")]
        public ActionResult<IEnumerable<ListUserDTO>> GetAll()
        {
            
            return Ok(_UserService.GetUsers()) ;
        }
        [HttpGet("getbyid/{id:int}")]
        public ActionResult getBytId(int id)
        {
            ResponseUserDTO? i = _UserService.GetByID(id);
            return i is null ? NotFound() : Ok(i);
        }
        [HttpDelete("deleteuser/{id:int}")]
        public ActionResult delete(int id)
        {
            
            return _UserService.Delete(id)?NoContent():NotFound(); 
        }
        [HttpPut("Updateuser/{id:int}")]
        public ActionResult<ResponseUserDTO?> update(int id ,[FromBody] UpdateuserDTO x)
        {
            ResponseUserDTO? Res= _UserService.Update(id, x);
            return Res is null ? NotFound() : Ok(Res);
        }
        [HttpPost("Create")]
        public ActionResult<ResponseUserDTO> Create([FromBody] CreateUserDTO x)
        {
            ResponseUserDTO User= _UserService.Create(x);
            return CreatedAtAction(nameof(getBytId), new { id = User.Id }, User);
        
        }
    }
}
