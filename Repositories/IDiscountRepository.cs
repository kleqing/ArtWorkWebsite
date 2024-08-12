using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Discount>> GetAllDiscounts();
        Task<Discount> GetDiscountById(int id);
        Task Add(Discount discount);
        Task Update(Discount discount);
        Task Delete(int id);
    }
}
