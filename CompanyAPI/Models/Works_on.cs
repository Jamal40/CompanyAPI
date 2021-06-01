using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Models
{
    public class Works_on
    {
        public int EmpNo { get; set; }

        public int ProjectNo { get; set; }

        public string Job { get; set; }

        public DateTime Enter_Date { get; set; }

        [ForeignKey("EmpNo")]
        public Employee Employee { get; set; }

        [ForeignKey("ProjectNo")]
        public Project Project { get; set; }
    }
}
