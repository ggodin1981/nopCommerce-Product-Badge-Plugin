using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Plugin.Misc.ProductBadge.Data;

namespace Nop.Plugin.Misc.ProductBadge.Services
{
    public interface IProductBadgeService
    {
        Task<ProductBadgeRecord> GetByProductIdAsync(int productId);
        Task InsertOrUpdateAsync(ProductBadgeRecord record);
        Task<IList<ProductBadgeRecord>> GetAllAsync();
    }
}
