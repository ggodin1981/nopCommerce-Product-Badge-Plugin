using System.Collections.Generic;

namespace Nop.Plugin.Misc.ProductBadge.Models
{
    public class ProductBadgeModel
    {
        public int ProductId { get; set; }
        public string BadgeText { get; set; }
        public string BadgeColor { get; set; }
        public bool IsActive { get; set; }
    }

    public class ConfigurationModel
    {
        public bool Enabled { get; set; }
        public string DefaultBadgeColor { get; set; }
        public IList<ProductBadgeModel> Badges { get; set; } = new List<ProductBadgeModel>();
    }
}
