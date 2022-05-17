using Asp.NetMVCApi_EL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetMVCApi_DAL
{
    public class MyContext: DbContext
    {
        public MyContext() : base("name=MyCon")
        {

        }

        public DbSet<Student> Students { get; set; }



    }
}
