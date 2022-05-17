using Asp.NetMVCApi_BLL.ConractBLL;
using Asp.NetMVCApi_DAL.Contracts;
using Asp.NetMVCApi_EL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Asp.NetMVCApi_EL.Models;

namespace Asp.NetMVCApi_BLL.ImplementationBLL
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ResponseData AddStudent(StudentVM student)
        {
            try
            {
                Student newStudent = student.Adapt<Student>();
                bool result = _unitOfWork.StudentRepo.Add(newStudent);
                if (result)
                {
                    return new ResponseData() { IsSuccess = true, Message = "Yeni öğrenci eklendi!" };
                }
                else
                {
                    return new ResponseData() { IsSuccess = false, Message = "Beklenmedik bir hata oluştu!" };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseData DeleteStudent(int studentId)
        {
            try
            {
                if (studentId > 0)
                {
                    var student = _unitOfWork.StudentRepo.GetById(studentId);
                    if (student == null)
                    {
                        throw new Exception("Hata: Student bulunamadı!!");
                    }
                    bool result = _unitOfWork.StudentRepo.Delete(student);
                    if (result)
                    {
                        return new ResponseData() { IsSuccess = true, Message = "Öğrenci silindi." };
                    }
                    else
                    {
                        return new ResponseData() { IsSuccess = false, Message = "HATA: Öğrenci silinemedi!" };
                    }
                }
                else
                {
                    throw new Exception("HATA: StudentId sıfırdan büyük olmalıdır!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        public ResponseData GetAllStudents()
        {
            try
            {
                var students = _unitOfWork.StudentRepo.GetAll();
                ICollection<StudentVM> resultData = students.Adapt<ICollection<StudentVM>>();
                return new ResponseData()
                {
                    IsSuccess = true,
                    Data = resultData,
                    Message = $"{resultData.Count} adet öğrenci vardır",
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResponseData UpdateStudent(int studentId, string newName, string newSurname)
        {
            try
            {
                if (studentId>0)
                {
                    var student = _unitOfWork.StudentRepo.GetById(studentId);
                    if (student==null)
                    {
                        throw new Exception("HATA: Öğrenci bulunamadı!");
                    }
                    student.Name = newName;
                    student.Surname = newSurname;
                    bool result = _unitOfWork.StudentRepo.Update(student); 
                    if (result)
                    {
                        return new ResponseData() { IsSuccess = false, Message = " Öğrenci güncellendi." };
                    }
                    else
                    {
                        return new ResponseData() { IsSuccess = false, Message = " HATA: Öğrenci güncelleme yapılırken" +
                            " beklenmedik bir hata oluştu!" };
                    }
                }
                else
                {
                    throw new Exception("HATA: StudentId sıfırdan büyük olmalıdır!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
