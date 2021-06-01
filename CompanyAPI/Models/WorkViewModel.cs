using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Models
{
    public class WorkViewModel
    {
        public int EmpNo { get; set; }

        public int ProjectNo { get; set; }

        public string Job { get; set; }

        public DateTime Enter_Date { get; set; }

        public string EmployeeName { get; set; }
        public string ProjectName { get; set; }
    }
}
