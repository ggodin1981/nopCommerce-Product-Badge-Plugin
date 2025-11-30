using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Misc.ProductBadge.Data;

namespace Nop.Plugin.Misc.ProductBadge.Services
{
    public class ProductBadgeService : IProductBadgeService
    {
        private readonly IRepository<ProductBadgeRecord> _badgeRepo;

        public ProductBadgeService(IRepository<ProductBadgeRecord> badgeRepo)
        {
            _badgeRepo = badgeRepo;
        }

        public async Task<ProductBadgeRecord> GetByProductIdAsync(int productId)
        {
            var list = await _badgeRepo.GetAllAsync(q => q.Where(x => x.ProductId == productId));
            return list.FirstOrDefault();
        }

        public async Task InsertOrUpdateAsync(ProductBadgeRecord record)
        {
            var existing = await GetByProductIdAsync(record.ProductId);
            if (existing == null)
            {
                await _badgeRepo.InsertAsync(record);
            }
            else
            {
                existing.BadgeText = record.BadgeText;
                existing.BadgeColor = record.BadgeColor;
                existing.IsActive = record.IsActive;
                await _badgeRepo.UpdateAsync(existing);
            }
        }

        public Task<IList<ProductBadgeRecord>> GetAllAsync()
        {
            return _badgeRepo.GetAllAsync(q => q);
        }
    }
}
