using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.ProductBadge.Data;

namespace Nop.Plugin.Misc.ProductBadge.Migrations
{
    [NopSchemaMigration("2025/11/30 10:00:00", "Misc.ProductBadge base schema", MigrationProcessType.Installation)]
    public class SchemaMigration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.TableFor<ProductBadgeRecord>();
        }
    }
}
