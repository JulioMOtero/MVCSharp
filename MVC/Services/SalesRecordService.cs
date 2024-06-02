using Humanizer;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Services
{
    public class SalesRecordService
    {

        private readonly MVCContext _context;

        public SalesRecordService(MVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? min,DateTime? max)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (min.HasValue)
            {
                result = result.Where(x => x.Date >= min.Value);
            }
            if (max.HasValue)
            {
                result = result.Where(x => x.Date <= max.Value);
            }

            return await result.Include(x => x.Seller).Include(x => x.Seller.Department).OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? min, DateTime? max)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (min.HasValue)
            {
                result = result.Where(x => x.Date >= min.Value);
            }
            if (max.HasValue)
            {
                result = result.Where(x => x.Date <= max.Value);
            }

            return await result.Include(x => x.Seller).Include(x => x.Seller.Department).OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }
    }
}
