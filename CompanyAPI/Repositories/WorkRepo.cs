using CompanyAPI.Data;
using CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Repositories
{
    public class WorkRepo : Repo<Works_on>, IWorkRepo
    {
        private readonly CompanyContext db;
        public WorkRepo(CompanyContext injectedContex):base(injectedContex)
        {
            db = injectedContex;
        }
        public async Task<Works_on> GetWorkById(int id, int second_id)
        {
            return await db.Works_on.Include(w => w.Employee).Include(w => w.ProjectNo).FirstOrDefaultAsync(w => w.EmpNo == id && w.ProjectNo == second_id);
        }
    }
}
