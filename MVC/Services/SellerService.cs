using Microsoft.EntityFrameworkCore;
using MVC.Controllers;
using MVC.Models;
using MVC.Services.Exceptions;
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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChangesAsync();
        }

        public async Task <Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (hasAny)
            {
                throw new NotFoundException("ID not Found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}
