using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace employeesTask.Models
{
    [Table("Departments")]
    public class DepartmentModel
    {
        public int Id { get; set; }

        [Required,StringLength(20)]
        public string Name_Ar { get; set; }

        [Required, StringLength(20)]
        public string Name_En { get; set; }

        
        public virtual ICollection<EmployeeModel> Employees { get; set; }
    }
}
