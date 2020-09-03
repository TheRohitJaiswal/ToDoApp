using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public interface IRepository<T>
    {
        Task<bool> Add(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(int id);
        Task<T> Search(int id);
        Task<List<T>> GetAll();
    }
}
