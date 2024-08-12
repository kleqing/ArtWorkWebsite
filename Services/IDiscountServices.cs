using ArtworkDTO;
using BusinessObject;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IDiscountServices
    {
        Task<IEnumerable<DiscountDTO>> GetAllDiscounts();
        Task<DiscountDTO> GetDiscountById(int id);
        Task Add(DiscountDTO discount);
        Task Update(DiscountDTO discount);
        Task Delete(int id);
    }
}
