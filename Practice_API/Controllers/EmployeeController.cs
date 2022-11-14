using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DBModels;
using Model.RequestBody;
using Model.ResponseBody;
using Practice_API.Validation;

namespace Practice_API.Controllers
{
    /// <summary>
    /// Employees controller 
    /// </summary>
    [ApiController]
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly DemoApiContext _demoApiContext;

        public EmployeeController(DemoApiContext demoApiContext)
        {
            _demoApiContext = demoApiContext;
        }

        /// <summary>
        /// get details of all the employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<List<EmployeeResponse>> GetEmployeesDetails()
        {
            //Get Employee list from DB
            List<EmployeeResponse> employeeResponses = await _demoApiContext.EmployeeDetails.Select(e => new EmployeeResponse
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                PhoneNumber = e.PhoneNumber,
                Age = e.Age,
            }).ToListAsync();
            return employeeResponses;
        }

        /// <summary>
        /// Upload employee details
        /// </summary>
        /// <param name="employee">Enter the employee object</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadEmployeeDetails(EmployeeRequest employee)
        {
            //convert employeeRequest object to employeeDetails to upload it to DB
            EmployeeDetail employeeDetail = new EmployeeDetail()
            {
                Name = employee.Name,
                Age = employee.Age,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
            };

            //Add and save the object to DB
            _demoApiContext.Add(employeeDetail);
            await _demoApiContext.SaveChangesAsync();

            //Create employeeResponse object and return
            EmployeeResponse employeeResponse = new EmployeeResponse()
            {
                EmployeeId = employeeDetail.EmployeeId,
                Name = employeeDetail.Name,
                PhoneNumber = employee.PhoneNumber,
                Age = employee.Age,
            };
            return Ok(employeeResponse);

        }

        /// <summary>
        /// Update employee details
        /// </summary>
        /// <param name="EmployeeID">enter EmployeeID here</param>
        /// <param name="email">enter updated email of employee</param>
        /// <param name="phoneNumber">enter updated name of employee</param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        [HttpPut]
        public async Task<IActionResult> UpdateEmployeeDetails([FromQuery] int EmployeeID, [FromQuery] string email, [FromQuery] long phoneNumber)
        {
            // get the employee details from DB with Employee ID
            EmployeeDetail employeeDetail = _demoApiContext.EmployeeDetails.Find(EmployeeID);

            //if find EmployeeID in DB update the details else throw exception else 
            if (employeeDetail != null)
            {
                //update the Email
                employeeDetail.Email = email;

                //update the PhoneNumber
                employeeDetail.PhoneNumber = phoneNumber;

                //Save changes in DB
                await _demoApiContext.SaveChangesAsync();

                //Create employeeResponse for response and return it
                EmployeeResponse employeeResponse = new EmployeeResponse()
                {
                    EmployeeId = employeeDetail.EmployeeId,
                    Name = employeeDetail.Name,
                    PhoneNumber = employeeDetail.PhoneNumber,
                    Age = employeeDetail.Age,
                };
                return Ok(employeeResponse);
            }
            else
            {
                throw new KeyNotFoundException("Invalid EmployeeID");
            }

        }

        /// <summary>
        /// Delete the Details of the Employee with EmployeeID
        /// </summary>
        /// <param name="EmployeeID">Enter EmployeeID here</param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployeeDetails([FromQuery] int EmployeeID)
        {
            // get the employee details from DB with Employee ID
            EmployeeDetail employeeDetail = _demoApiContext.EmployeeDetails.Find(EmployeeID);

            //if find EmployeeID in DB update the details else throw exception else 
            if (employeeDetail != null)
            {
                //remove the EmployeeID from DB and Save 
                _demoApiContext.Remove(employeeDetail);
                await _demoApiContext.SaveChangesAsync();
                return Ok("Employee With EmployeeID " + EmployeeID + " removed from DataBase");
            }
            else
            {
                throw new KeyNotFoundException("Invalid EmployeeID");
            }
        }
    }
}
