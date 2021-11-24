using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace employeesTask.Models
{
    [Table("Employees")]
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الحقل مطلوب")]
        public int Department_Id { get; set; }

        [Required(ErrorMessage ="الحقل مطلوب"),StringLength(20,ErrorMessage ="يجب أن لا يتجاوز الاسم 20 حرف")]
        public string Name_Ar { get; set; }

        [Required(ErrorMessage = "الحقل مطلوب"), StringLength(20, ErrorMessage = "يجب أن لا يتجاوز الاسم 20 حرف")]
        public string Name_En { get; set; }

        [Required(ErrorMessage = "الحقل مطلوب"), EmailAddress(ErrorMessage ="خطأ في كتابة البريد"), StringLength(50, ErrorMessage = "يجب أن لا يتجاوز البريد 50 حرف")]
        public string Email { get; set; }

        [Required(ErrorMessage = "الحقل مطلوب"), Phone, RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "خطأ في كتابة رقم الهاتف"), StringLength(16, ErrorMessage = "يجب أن لا يتجاوز الهاتف 16 حرف")]
        public string Phone { get; set; }

        public float Salary { get; set; }

        [StringLength(150)]
        public string Address { get; set; }


        public virtual DepartmentModel Department { get; set; }
    }
}
