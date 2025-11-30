using System.Threading.Tasks;
using Nop.Services.Security;
using Nop.Services.Events;
using Nop.Web.Framework.Events;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Misc.ProductBadge.Infrastructure
{
    // This class adds "Product Badge" under Configuration in the left admin menu
    public class AdminMenuConsumer : IConsumer<AdminMenuCreatedEvent>
    {
        private readonly IPermissionService _permissionService;

        public AdminMenuConsumer(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public async Task HandleEventAsync(AdminMenuCreatedEvent eventMessage)
        {
            // Only show for admins that can manage plugins (you can change permission if you want)
            if (!await _permissionService.AuthorizeAsync(StandardPermission.Configuration.MANAGE_PLUGINS))
                return;

            // Create our menu item
            var menuItem = new AdminMenuItem
            {
                SystemName = "ProductBadge",
                Title = "Product Badge",
                Url = eventMessage.GetMenuItemUrl("ProductBadgeAdmin", "Configure"),
                IconClass = "far fa-dot-circle",
                Visible = true
            };

            // Add under the Configuration menu root
            // You can also InsertBefore/InsertAfter specific items if you want a precise position
            eventMessage.RootMenuItem.ChildNodes.Add(menuItem);
        }
    }
}
