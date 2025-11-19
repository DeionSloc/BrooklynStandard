using BrooklynStandard.Controllers;
using BrooklynStandard.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrooklynStandard
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRequestController1 : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public UserRequestController1(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<List<UserRequest>> Get()
        {
            return await _dbContext.UserRequests.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserRequest> GetById(int id)
        {
            return await _dbContext.UserRequests.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserRequest userRequest)
        {
            if(string.IsNullOrWhiteSpace(userRequest.FullName) ||
            string.IsNullOrEmpty(userRequest.Email) ||
            string.IsNullOrEmpty(userRequest.Request))
            {
                return BadRequest("Invalid Request");
            }
            await _dbContext.UserRequests.AddAsync(userRequest);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = userRequest.Id }, userRequest);
        }

        public IActionResult UploadFile(IFormFile file)
        {
            return Ok(new UploadFileController().Upload(file));
        }
    }
}
