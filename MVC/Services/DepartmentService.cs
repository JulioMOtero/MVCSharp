using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Services
{
    public class DepartmentService
    {

        private readonly MVCContext _context;

        public DepartmentService(MVCContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy( x => x.Name).ToListAsync();
        }
    }
}
