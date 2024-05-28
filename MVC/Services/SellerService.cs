using MVC.Controllers;
using MVC.Models;
using System.Drawing;

namespace MVC.Services
{
    public class SellerService
    {

        private readonly MVCContext _context;

        public SellerService(MVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll() 
        {
            return _context.Seller.ToList();
        }
        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
