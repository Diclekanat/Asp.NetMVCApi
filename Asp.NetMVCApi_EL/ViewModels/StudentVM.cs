using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetMVCApi_EL.ViewModels
{
    public class StudentVM  //
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Adınız en az 2 en çok 50 karakter olmalıdır!")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Soyadınz en az 2 en çok 50 karakter olmalıdır!")]
        public string Surname { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
