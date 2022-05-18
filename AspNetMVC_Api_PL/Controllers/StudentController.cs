using Asp.NetMVCApi_BLL.ConractBLL;
using Asp.NetMVCApi_EL.ViewModels;
using Asp.NetMVCApi_BLL.ImplementationBLL;
using Asp.NetMVCApi_DAL;
using Asp.NetMVCApi_DAL.Contracts;
using Asp.NetMVCApi_DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace AspNetMVCApi_PL.Controllers
{
    [System.Web.Http.RoutePrefix("s")]
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET s --> prefix var böyle çağrılır
        // GET api/student/GetAllStudents
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
                // ex loglanabilir
                return new ResponseData()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }


        // GET api/<controller>/5

        //POST s--> prefix ile böyle çağrılır.
        //POST api/student/GetAllStudents

        //öğrenci ekleme
        [HttpPost]
        [System.Web.Http.Route("")]
        public ResponseData AddStudent([FromBody]StudentVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResponseData()
                    {
                        IsSuccess = false,
                        Message = "Veri girişleri düzgün olmalıdır!"
                    };
                }
                model.RegisterDate = DateTime.Now;
                ResponseData result = _studentService.AddStudent(model);
                return new ResponseData()
                {
                    IsSuccess = true,
                    Message = "Yeni öğrenci kaydı yapılmıştır."
                };
            }
            catch (Exception ex)
            {
                // ex loglanabilir
                return new ResponseData()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        // öğrenci güncelleme
        //HTTPPUT ya da HTTPPost kullanılır.
        [HttpPut]
        [System.Web.Http.Route("")]
        public ResponseData UpdateStudent(int studentId, string name, string surname)
        {
            try
            {
                if (studentId>0)
                {
                    ResponseData result=_studentService.UpdateStudent(studentId, name, surname);
                    if (result.IsSuccess)
                    {
                        return new ResponseData()
                        {
                            IsSuccess = true,
                            Message = " Öğrenci güncelleme işlemi başarılı bir şekilde gerçekleşti."
                        };
                    }
                    else
                    {
                        return new ResponseData()
                        {
                            IsSuccess = false,
                            Message = "HATA: Öğrenci güncelleme işleminde beklenmedik bir hata sorun oluştu!"
                        };
                    }
                }
                else
                {
                    return new ResponseData()
                    {
                        IsSuccess = false,
                        Message = "Öğrenci bulunamadı!"
                    };
                }
            }
            catch (Exception ex)
            {
                // ex loglanabilir
                return new ResponseData()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        [HttpDelete]
        [System.Web.Http.Route("")]
        public ResponseData DeleteStudent(int id)
        {
            try
            {
                if (id>0)
                {
                    var result = _studentService.DeleteStudent(id);
                    if (result.IsSuccess)
                    {
                        return new ResponseData()
                        {
                            IsSuccess = true,
                            Message = " Öğrenci sistemden silinmiştir."
                        };
                    }
                    else
                    {
                        return new ResponseData()
                        {
                            IsSuccess = false,
                            Message = "HATA: Öğrenci silme işleminde beklenmedik bir hata sorun oluştu!"
                        };
                    }
                }
                else
                {
                    //ex loglanabilir
                    return new ResponseData()
                    {
                        IsSuccess = false,
                        Message = "HATA: Id girişi düzgün olmalıdır!"
                    };

                }
            }
            catch (Exception ex)
            {

                // ex loglanabilir
                return new ResponseData()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

    }
}