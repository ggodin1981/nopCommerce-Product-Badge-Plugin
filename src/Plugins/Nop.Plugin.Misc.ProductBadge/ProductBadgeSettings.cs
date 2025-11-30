using Nop.Core.Configuration;

namespace Nop.Plugin.Misc.ProductBadge
{
    public class ProductBadgeSettings : ISettings
    {
        public bool Enabled { get; set; } = true;
        public string DefaultBadgeColor { get; set; } = "#ff5722";
    }
}
