using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Configuration;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Plugin.Misc.ProductBadge.Models;
using Nop.Plugin.Misc.ProductBadge.Services;

namespace Nop.Plugin.Misc.ProductBadge.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.ADMIN)]
    public class ProductBadgeAdminController : BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly IPermissionService _permissionService;
        private readonly IProductBadgeService _badgeService;

        public ProductBadgeAdminController(
            ISettingService settingService,
            IPermissionService permissionService,
            IProductBadgeService badgeService)
        {
            _settingService = settingService;
            _permissionService = permissionService;
            _badgeService = badgeService;
        }

        public async Task<IActionResult> Configure()
        {
            var settings = await _settingService.LoadSettingAsync<ProductBadgeSettings>();
            var badges = await _badgeService.GetAllAsync();

            var model = new ConfigurationModel
            {
                Enabled = settings.Enabled,
                DefaultBadgeColor = settings.DefaultBadgeColor,
                Badges = badges.Select(b => new ProductBadgeModel
                {
                    ProductId = b.ProductId,
                    BadgeText = b.BadgeText,
                    BadgeColor = b.BadgeColor,
                    IsActive = b.IsActive
                }).ToList()
            };

            return View("~/Plugins/Misc.ProductBadge/Views/ProductBadgeAdmin/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return await Configure();

            var settings = await _settingService.LoadSettingAsync<ProductBadgeSettings>();
            settings.Enabled = model.Enabled;
            settings.DefaultBadgeColor = model.DefaultBadgeColor;
            await _settingService.SaveSettingAsync(settings);

            ViewBag.Success = true;

            return await Configure();
        }
    }
}
