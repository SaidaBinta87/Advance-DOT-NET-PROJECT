using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("api/getAllPerson")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = EmployeeService.GetAll();

                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Data not found.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/Employee/Create")]
        public HttpResponseMessage Create(EmployeeDTO employeeDTO)
        {
            try
            {
                var updatedPost = EmployeeService.Create(employeeDTO);

                if (updatedPost != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updatedPost);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, " not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/Employee/login")]
        public HttpResponseMessage Login([FromBody] EmployeeDTO empDto)
        {
            try
            {
                var res = EmployeeService.GetEmp(empDto.Email, empDto.Password);

                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Account not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpPut]
        [Route("api/Employee/Update")]
        public HttpResponseMessage Update(EmployeeDTO employeeDTO)
        {
            try
            {
                var updatedPost = EmployeeService.Update(employeeDTO);
                if (updatedPost != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updatedPost);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, " not update found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = EmployeeService.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        //Get question Mgs from here

        [HttpGet]
        [Route("api/Employee/Question/{id}")]
        public HttpResponseMessage GetAllQuestion(int id)
        {
            try
            {
                var data = EmployeeService.GetAll(id);

                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Data not found.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/Employee/Question")]
        public HttpResponseMessage GetAllQuestion()
        {
            try
            {
                var data = EmployeeService.GetAllQuestion();

                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Data not found.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }




        [HttpPut]
        [Route("api/Employee/Question/Update")]
        public HttpResponseMessage UpdateQuestion(MgsDTO employeeDTO)
        {
            try
            {
                var updatedPost = EmployeeService.UpdateQuestion(employeeDTO);
                if (updatedPost != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updatedPost);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, " not update found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/Employee/Question/Delete/{id}")]
        public HttpResponseMessage DeleteQuestion(int id)
        {
            try
            {
                var result = EmployeeService.DeleteQuestion(id);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
