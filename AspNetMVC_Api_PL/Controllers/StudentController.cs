using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Asp.NetMVCApi_BLL;
using Asp.NetMVCApi_BLL.ConractBLL;
using Asp.NetMVCApi_EL;
using Asp.NetMVCApi_EL.ViewModels;

namespace AspNetMVC_Api_PL.Controllers
{
    [System.Web.Http.RoutePrefix("s")]
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET api/<controller>

        [System.Web.Http.Route("")]
        public ResponseData GetAllStudents()
        {
            try
            {
                var result = _studentService.GetAllStudents().Data;
                return new ResponseData() { IsSuccess = true, Data = result };
            }
            catch (Exception ex)
            {
                //ex loglanabilir
                return new ResponseData()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        // GET api/<controller>/5

        // POST api/<controller>

        // PUT api/<controller>/5

        // DELETE api/<controller>/5
    }
}