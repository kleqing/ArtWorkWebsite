using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DiscountDAO : SingletonBase<DiscountDAO>
    {
        public async Task<IEnumerable<Discount>> GetAllDiscounts()
        {
            return await _context.Discounts.ToListAsync();
        }

        public async Task<Discount> GetDiscountById(int id)
        {
            var discount = await _context.Discounts.FirstOrDefaultAsync(d => d.Id == id);
            if (discount == null) return null;

            return discount;
        }

        public async Task Add(Discount discount)
        {
            await _context.Discounts.AddAsync(discount);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Discount discount)
        {
            var existingItem = await GetDiscountById(discount.Id);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(discount);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var discount = await GetDiscountById(id);
            if (discount != null)
            {
                _context.Discounts.Remove(discount);
                await _context.SaveChangesAsync();
            }
        }
    }
}
