using Asp.NetMVCApi_EL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetMVCApi_BLL.ConractBLL
{
    public interface IStudentService
    {
        ResponseData GetAllStudents();
        ResponseData AddStudent(StudentVM student);
        ResponseData UpdateStudent(int studentId, string newName, string newSurname);
        ResponseData DeleteStudent(int studentId);

    }
}
