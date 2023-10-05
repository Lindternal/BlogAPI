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
            if (Logic.Logic.GetBaseCount() <= 0)
            {
                return NoContent();
            }

            return Ok(Logic.Logic.GetBaseList());
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
            var blog = Logic.Logic.GetBlogByID(id);

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

            Logic.Logic.AddToBase(value);

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

            var blog = Logic.Logic.GetBlogByID(id);

            if(blog == null)
            {
                return NotFound();
            }

            blog = value;
            Logic.Logic.SetBlogByID(id, blog);

            return NoContent();
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= Logic.Logic.GetBaseCount())
            {
                return BadRequest();
            }

            if (Logic.Logic.GetBlogByID(id) == null)
            {
                return NotFound();
            }

            Logic.Logic.RemoveBlogByID(id);

            return NoContent();
        }
    }
}
