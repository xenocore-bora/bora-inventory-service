using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Inventory.Infrastructure.Extensions;

public static class ModelBuilderExtension
{
    public static void ConvertToSnakeCase(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            if (entity.IsOwned())
            {
                var ownership = entity.FindOwnership();
                var ownerTable = ownership?.PrincipalEntityType.GetTableName() ??
                                 throw new InvalidOperationException("Owned type without owner");
                foreach (var property in entity.GetProperties())
                {
                    var columnName = property.GetColumnName(StoreObjectIdentifier.Table(ownerTable, null));
                    if (columnName != null)
                        property.SetColumnName(columnName.ToSnakeCase());
                }

                continue; // We don't touch owned types
            }

            entity.SetTableName(entity.GetTableName()!.ToSnakeCase());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToSnakeCase());
            }

            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName().ToSnakeCase());
            }

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
            }
        }
    }
}