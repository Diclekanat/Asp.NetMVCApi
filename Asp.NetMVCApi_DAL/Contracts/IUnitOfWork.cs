using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Asp.NetMVCApi_DAL.Contracts
{
    public interface IUnitOfWork
    {
        IStudentRepo StudentRepo { get; }
    }
}
