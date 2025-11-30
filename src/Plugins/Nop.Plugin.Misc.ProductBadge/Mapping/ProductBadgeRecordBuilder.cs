using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.ProductBadge.Data;

namespace Nop.Plugin.Misc.ProductBadge.Mapping
{
    public class ProductBadgeRecordBuilder : NopEntityBuilder<ProductBadgeRecord>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ProductBadgeRecord.Id)).AsInt32().PrimaryKey().Identity()
                .WithColumn(nameof(ProductBadgeRecord.ProductId)).AsInt32().NotNullable()
                .WithColumn(nameof(ProductBadgeRecord.BadgeText)).AsString(100).Nullable()
                .WithColumn(nameof(ProductBadgeRecord.BadgeColor)).AsString(20).Nullable()
                .WithColumn(nameof(ProductBadgeRecord.IsActive)).AsBoolean().NotNullable();
        }
    }
}
