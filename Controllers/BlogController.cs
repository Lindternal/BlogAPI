using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        // GET: api/<PostController>
        [HttpGet(Name = "GetBlog")]
        public ActionResult<IEnumerable<Blog>> Get()
        {
            if (Data.Base.Posts.Count <= 0)
            {
                return NoContent();
            }

            return Ok(Data.Base.Posts);
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
            var blog = Data.Base.Posts[id];

            if (blog == null)
            {
                return NoContent();
            }

            return Ok(blog);
        }

        // POST api/<PostController>
        [HttpPost]
        public ActionResult<Blog> Post([FromBody] Blog value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            Data.Base.Posts.Add(value);

            return Created("Get", value);
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Blog value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            var blog = Data.Base.Posts[id];

            if(blog == null)
            {
                return NotFound();
            }

            blog = value;
            Data.Base.Posts[id] = blog;

            return NoContent();
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= Data.Base.Posts.Count)
            {
                return BadRequest();
            }

            if (Data.Base.Posts[id] == null)
            {
                return NotFound();
            }

            Data.Base.Posts.RemoveAt(id);

            return NoContent();
        }
    }
}
