using CoreWebAPI.BAL;
using CoreWebAPI.BAL.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAPIforReact.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public EmployeeController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var employees = _dbContext.Employees.ToList();
            if (employees.Count == 0)
            {
                return NotFound("Employees not available!");
            }

            return Ok(employees);
        }

        // GET: api/<EmployeeController>
        //[HttpGet]
        //public IEnumerable<Employee> Get()
        //{
        //    return _dbContext.Employees.ToList();
        //}

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _dbContext.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return Ok(employee);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        //public IActionResult Post([FromBody] Employee employeeModel)
        public IActionResult PostEmployee([FromBody] Employee employeeModel)
        {
            try
            {
                _dbContext.Employees.Add(employeeModel);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, employeeModel);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]

        public IActionResult Post(Employee employee)
        {
            try
            {
                _dbContext.Add(employee);
                _dbContext.SaveChanges();
                return Ok("Created successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
