using Microsoft.AspNetCore.Mvc;
using testing_project.Data;
using System.Threading.Tasks;
using testing_project.Enitity;
using Microsoft.EntityFrameworkCore;

namespace testing_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class loginController : Controller
    {
        private readonly DataContext _context;

        public loginController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Register(string name)
        {
            UserEntity user = new UserEntity();
            user.Name = name;   
            _context.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserEntity>>> GetUser()
        {
            IEnumerable<UserEntity> users = new List<UserEntity>();
            users = await _context.User.ToListAsync();
            return Ok(users);
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            UserEntity user = await _context.User.SingleOrDefaultAsync(x => x.Id == id);
            
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
