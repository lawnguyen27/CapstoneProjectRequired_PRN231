using BusinessObjects;
using BusinessObjects.DTOs;
using BusinessObjects.DTOs.Request;
using BusinessObjects.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRN231.CPR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicRepository topicRepository;

        public TopicController(ITopicRepository repository)
        {
            topicRepository = repository;
        }

        // GET: api/<TopicViewController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicResponse>>> Get()
        {
            var ss = topicRepository.GetTopics();
            if (ss == null)
                return NotFound();
            return Ok(ss);
        }

        // POST api/<TopicViewController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TopicRequest value)
        {
            if (value != null)
            {
                topicRepository.CreateTopic(value);
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<TopicViewController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id)
        {
            if (id == 0) return NotFound();
            topicRepository.UpdateStatus(id);
            return Ok();
        }

        /*
        // GET api/<TopicViewController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // DELETE api/<TopicViewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
