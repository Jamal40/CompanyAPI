using CompanyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Repositories
{
    public interface IWorkRepo:IRepo<Works_on>
    {
        public Task<Works_on> GetWorkById(int id, int second_id);
    }
}
