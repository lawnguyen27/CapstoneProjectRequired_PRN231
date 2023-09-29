using BusinessObjects;
using BusinessObjects.DTOs.Request;
using BusinessObjects.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRN231.CPR.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository subjectRepository;

        public SubjectController(ISubjectRepository repository)
        {
            subjectRepository = repository;
        }


        // GET: api/<SubjectController>/5
        [Route("api/Subject/Prerequisite/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectResponse>>> GetSubjectIsPrerequisite(int id)
        {
            var ss = subjectRepository.GetSubjectIsPrerequisite((int)id);
            if (ss == null)
                return NotFound();
            return Ok(ss);
        }


        // GET api/<SubjectController>/5
        [Route("api/Subject/Specialization/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectResponse>>> GetSubjects(int id)
        {
            var ss = subjectRepository.GetSubjectBySpecializationId(id);
            if (ss == null)
                return NotFound();
            return Ok(ss);
        }

        // POST api/<SubjectController>
        [Route("api/Subject")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubjectRequest value)
        {
            if (value != null)
            {
                subjectRepository.Create(value);
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<SubjectController>/5
        [Route("api/Subject/{id}")]
        [HttpPut]
        public async Task<ActionResult> Put(int id)
        {
            if (id == 0) return NotFound();
            subjectRepository.UpdateStatus(id);
            return Ok();
        }

    }
}
