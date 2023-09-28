using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRN231.CPR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository repository)
        {
            accountRepository = repository;
        }

        // GET: api/<AccountController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> Get()
        {
            var ss = accountRepository.GetAccounts();
            if (ss == null)
                return NotFound();
            return Ok(ss);
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Account value)
        {
            if (value != null)
            {
                accountRepository.Create(value);
                return Ok();
            }
            return BadRequest();
        }

        /*

            // GET api/<AccountController>/5
            [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */

    }
}
