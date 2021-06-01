using CompanyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyAPI.Repositories
{
    public interface IRepo<T>
    {
        Task<int> Add(T addedEntity);
        Task<int> Edit(T editedEntity);
        bool EntityExists(int id, int sceond_id = 0);
        Task<List<T>> GetAll(bool include = false);
        Task<T> GetById(int id, int second_id = 0);
        Task<int> Remove(T removedEntity);
    }
}