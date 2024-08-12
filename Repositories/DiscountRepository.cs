using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        public async Task Add(Discount discount)
        {
            await DiscountDAO.Instance.Add(discount);
        }

        public async Task Delete(int id)
        {
            await DiscountDAO.Instance.Delete(id);
        }

        public async Task<IEnumerable<Discount>> GetAllDiscounts()
        {
            return await DiscountDAO.Instance.GetAllDiscounts();
        }

        public async Task<Discount> GetDiscountById(int id)
        {
            return await DiscountDAO.Instance.GetDiscountById(id);
        }

        public async Task Update(Discount discount)
        {
            await DiscountDAO.Instance.Update(discount);
        }
    }
}
