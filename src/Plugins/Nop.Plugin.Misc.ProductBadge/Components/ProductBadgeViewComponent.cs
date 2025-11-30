using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Nop.Plugin.Misc.ProductBadge.Services;
using Nop.Plugin.Misc.ProductBadge.Models;

namespace Nop.Plugin.Misc.ProductBadge.Components
{
    // ViewComponent name: "ProductBadge"
    public class ProductBadgeViewComponent : NopViewComponent
    {
        private readonly IProductBadgeService _productBadgeService;
        private readonly ProductBadgeSettings _settings;

        public ProductBadgeViewComponent(
            IProductBadgeService productBadgeService,
            ProductBadgeSettings settings)
        {
            _productBadgeService = productBadgeService;
            _settings = settings;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            // Plugin disabled → render nothing
            if (!_settings.Enabled)
                return Content(string.Empty);

            var record = await _productBadgeService.GetByProductIdAsync(productId);
            if (record == null || !record.IsActive || string.IsNullOrWhiteSpace(record.BadgeText))
                return Content(string.Empty);

            var model = new ProductBadgeModel
            {
                ProductId = productId,
                BadgeText = record.BadgeText,
                BadgeColor = string.IsNullOrWhiteSpace(record.BadgeColor)
                    ? _settings.DefaultBadgeColor
                    : record.BadgeColor,
                IsActive = record.IsActive
            };

            // Explicit path keeps the view inside the plugin
            return View("~/Plugins/Misc.ProductBadge/Views/ProductBadge/PublicInfo.cshtml", model);
        }
    }
}
