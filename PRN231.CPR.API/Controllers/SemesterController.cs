using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRN231.CPR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterRepository semesterRepository;

        public SemesterController(ISemesterRepository repository)
        {
            semesterRepository = repository;
        }

        // GET: api/<SemesterController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Semester>>> Get()
        {
            var ss = semesterRepository.GetSemesters();
            if (ss == null)
                return NotFound();
            return Ok(ss);
        }

        // GET api/<SemesterController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Semester>> GetById(int id)
        {
            if (id == 0) return NotFound();
            var s = semesterRepository.GetSemesterByID(id);
            return Ok(s);
        }

        // POST api/<SemesterController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Semester value)
        {
            if (value != null)
            {
                semesterRepository.Create(value);
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<SemesterController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id)
        {
            if (id == 0) return NotFound();
            semesterRepository.Update(id);
            return Ok();
        }

    }
}
