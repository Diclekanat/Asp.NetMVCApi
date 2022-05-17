using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asp.NetMVCApi_DAL.Contracts;
using Asp.NetMVCApi_EL.Models;

namespace Asp.NetMVCApi_DAL.Implementations
{
    public class StudentRepo: RepositoryBase<Student,int>, IStudentRepo
    {
        public StudentRepo(MyContext myContext):base(myContext)
        {

        }
    }
}
