using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }

        public string Fname { get; set; }

        public string Lname { get; set; }

        [Column(TypeName = "money")]
        public decimal? Salary { get; set; }

        public int DeptNo { get; set; }

        [ForeignKey("DeptNo")]
        public Department Department { get; set; }

        public ICollection<Works_on> Works_Ons { get; set; }
    }
}
