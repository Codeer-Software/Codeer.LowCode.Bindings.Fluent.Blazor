using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Extensions
{
    internal static class FieldDesignExtensions
    {
        internal static string GetDisplayText(this FieldDesignBase field)
        {
            if (field is IDisplayName displayName && !string.IsNullOrEmpty(displayName.DisplayName))
                return displayName.DisplayName;
            return field.Name;
        }

        internal static bool IsRequired(this FieldDesignBase field)
        {
            if (field is IRequired required) return required.IsRequired;
            return false;
        }
    }
}
