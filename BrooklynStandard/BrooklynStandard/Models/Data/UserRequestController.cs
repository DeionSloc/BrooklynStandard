using System.Text;
using System;
namespace BrooklynStandard.Models.Data
[Route("api/[controller]")]
[ApiController]
{
    public class UserRequestController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public UserRequestController(AppDbContext dbContext) => 
        _dbContext = dbContext;

        [HttpGet]
        public async Task<List<UserRequest?> GetById(int id)
        {
            return await _dbContext.UserRequests.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserRequest userRequest)
        {
            if(String.IsNullOrWhiteSpace(userRequest.FullName) ||
            string.IsNullOrWhiteSpace(userRequest.Email)
            string.IsNullOrWhiteSpace(userRequest.Request))
            {
                return BadRequest("Invalid Request");
            }
            await _dbContext.UserRequests.AddAsync(userRequest);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = userRequest.Id }, userRequset);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UserRequest userRequest)
        {
            if(userRequest.Id == 0 ||
            string.IsNullOrWhiteSpace(userRequest.FullName) ||
            string.IsNullOrWhiteSpace(userRequest.Email) ||
            string.IsNullOrWhiteSpace(userRequest.Request))
            {
                return BadRequest("Invalid Request");
            }

            _dbContext.UserRequests.Update(userRequest);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userRequest = await GetById(id);
            if(userRequest is null)
                return NotFound();

            _dbContext.UserRequests.Remove(userRequest);
            await _dbContext.SaveChangesAsync();

            return Ok();    
        }
    }
}