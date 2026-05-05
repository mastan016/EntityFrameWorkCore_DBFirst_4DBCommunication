using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        // Inject the dependencies into constrctor

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Post([FromBody] EmployeeDto empdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _employeeService.AddEmployees(empdto);
                    return StatusCode(StatusCodes.Status201Created, empdata);
                }
            }
            catch (Exception ex)
            {
                // if you got any error we are using this statuscode: Status500Internal ServerError

                return StatusCode(StatusCodes.Status500InternalServerError, "Server not found");

            }
        }


        [HttpDelete]
        [Route("DeleteEmployeeByEmpid/{empid}")]
        public async Task<IActionResult> delete(int empid)
        {
            if(empid<0)
            {
                //If input parameters are wrongly sent or empty, we will get 400 badrequest status
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var empdata = await _employeeService.DeleteEmployeesById(empid);

                if (empdata == null)
                {
                    //in db if you get empty data we need to retrun this statuscode:status404Notfound
                    return StatusCode(StatusCodes.Status404NotFound, "empdata not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server not found");
            }

        }


        [HttpGet]
        [Route("GetEmployee")]

        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var empdata=await _employeeService.GetEmployees();
                if(empdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server not found");
            }
        }


        [HttpGet]
        [Route("GetEmployeeByEmpid/{empid}")]

        public async Task<IActionResult> Get(int empid)
        {
            if (empid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var empdata = await _employeeService.GetEmployeeById(empid);
                return StatusCode(StatusCodes.Status200OK, empdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }


        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> put([FromBody] EmployeeDto empdto)
        {

            try
            {
                if(!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _employeeService.UpdateEmployee(empdto);
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch(Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }


        }




    }
}
