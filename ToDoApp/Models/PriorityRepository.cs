using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class PriorityRepository : IRepository<Priority>
    {
        ToDoContext context;
        public PriorityRepository(ToDoContext context)
        {
            this.context = context;
        }
        public async Task<bool> Add(Priority item)
        {
            context.Priorities.Add(item);
            int rows = await context.SaveChangesAsync();
            return rows == 1;
        }

        public async Task<bool> Delete(int id)
        {
            var obj = await context.Priorities.FindAsync(id);
            context.Priorities.Remove(obj);
            int rows = context.SaveChangesAsync().Result;
            return rows == 1;
        }

        public async Task<List<Priority>> GetAll()
        {
            var query = from obj in context.Priorities
                        select obj;
            return await query.ToListAsync();
        }

        public async Task<Priority> Search(int id)
        {
            var obj = await context.Priorities.FindAsync(id);
            return obj;
        }

        public async Task<bool> Update(Priority item)
        {
            bool Updated = false;
            var obj = await context.Priorities.FindAsync(item.Id);
            if (obj != null)
            {
                obj.PriorityName = item.PriorityName;
                obj.ColorCode = item.ColorCode;
                int rows = await context.SaveChangesAsync();
                Updated = rows == 1;
            }
            return Updated;
        }
    }
}
