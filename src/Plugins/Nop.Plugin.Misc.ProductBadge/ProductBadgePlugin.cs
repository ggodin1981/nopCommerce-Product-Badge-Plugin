using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Services.Configuration;
using Nop.Services.Plugins;
using Nop.Plugin.Misc.ProductBadge.Services;

namespace Nop.Plugin.Misc.ProductBadge
{
    public class AdminMenuConsumer : BasePlugin
    {
        private readonly ISettingService _settingService;

        public AdminMenuConsumer(ISettingService settingService)
        {
            _settingService = settingService;
        }

        // ✅ This makes the "Configure" button appear in Local plugins
        public override string GetConfigurationPageUrl()
        {
            // relative URL is fine
            return "/Admin/ProductBadgeAdmin/Configure";
        }

        public override async Task InstallAsync()
        {
            var settings = new ProductBadgeSettings
            {
                Enabled = true,
                DefaultBadgeColor = "#ff5722"
            };

            await _settingService.SaveSettingAsync(settings);

            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            await _settingService.DeleteSettingAsync<ProductBadgeSettings>();
            await base.UninstallAsync();
        }
    }

    // Registers ProductBadgeService in DI
    public class ProductBadgeStartup : INopStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductBadgeService, ProductBadgeService>();
        }

        public void Configure(IApplicationBuilder application)
        {
            // no middleware for this plugin
        }

        public int Order => 5000;
    }
}
