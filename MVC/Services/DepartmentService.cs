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

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy( x => x.Name).ToList();
        }
    }
}
