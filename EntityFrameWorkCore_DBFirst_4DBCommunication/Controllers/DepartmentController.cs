using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Northwind_DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Metrics;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _deptservice;
        public DepartmentController(IDepartmentService deptservice)
        {
            _deptservice = deptservice;
        }

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> Post([FromBody] DepartmentDto deptdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _deptservice.AddDepartments(deptdto);
                    return StatusCode(StatusCodes.Status201Created, empdata);
                }
            }
            catch (Exception ex)
            {// if you got any error we are using this status  code: status 500 internal server error

                return StatusCode(StatusCodes.Status500InternalServerError, "Server not Found");
            }
        }

        [HttpDelete]
        [Route("DeleteDepartmentByempid/{deptid}")]

        public async Task<IActionResult> delete([FromRoute] int deptid)
        {
            if (deptid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var deptdata = await _deptservice.DeleteDepartmentById(deptid);
                if (deptdata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "deptdata not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }

        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> GetDepartment()
        {
            try
            {
                var deptdata = await _deptservice.GetDepartments();
                if(deptdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "deptdata not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, deptdata);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server not found");
            }
        }

        [HttpGet]
        [Route("GetDepartmentByDeptid/{deptid}")]
        public async Task<IActionResult> Get(int deptid)
        {
            if(deptid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var deptdata = await _deptservice.GetDepartmentById(deptid);
                return StatusCode(StatusCodes.Status200OK, deptdata);
            }
            catch (Exception ex) { 
                return StatusCode(StatusCodes.Status500InternalServerError, "Server not found");

            }

        }

        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> put([FromBody] DepartmentDto deptdto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {                  
                    var deptdata = await _deptservice.UpdateDepartment(deptdto);
                    return StatusCode(StatusCodes.Status200OK, deptdata);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server not found");
            }
        }




    }
}

/* Scaffold-DbContext "Server=LAPTOP-3GC5IQ7F;Database=Northwind_DB;User Id=sa;Password=123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Northwind_DbModels  */

/* Scaffold-DbContext "Server=LAPTOP-3GC5IQ7F;Database=Northwind_DB;User Id=sa;Password=123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Northwind_DbModels -force */

// For re-create the existing Models as it is primary key 

// the above command is used to re-create the models as there is a primary key missing in those models

/*
--alter table department
--add constraint pk_department primary key(deptid) */