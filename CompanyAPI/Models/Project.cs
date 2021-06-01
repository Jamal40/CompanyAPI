using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Models
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public int ProjectNo { get; set; }

        public string ProjectName { get; set; }

        [Column(TypeName = ("money"))]
        public decimal? Budget { get; set; }

        public ICollection<Works_on> Works_Ons { get; set; }
    }
}
