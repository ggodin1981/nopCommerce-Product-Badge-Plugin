using Nop.Core;

namespace Nop.Plugin.Misc.ProductBadge.Data
{
    public class ProductBadgeRecord : BaseEntity
    {
        public int ProductId { get; set; }
        public string BadgeText { get; set; }
        public string BadgeColor { get; set; }
        public bool IsActive { get; set; }
    }
}
