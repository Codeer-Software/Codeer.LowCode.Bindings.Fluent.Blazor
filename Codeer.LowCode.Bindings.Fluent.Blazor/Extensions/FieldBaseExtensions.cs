using System.Text;
using Codeer.LowCode.Blazor.OperatingModel;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Extensions
{
    public static class FieldBaseExtensions
    {
        public static string? GetStyleString(this FieldBase data)
        {
            var drawStyle = data.GetOwnStyles();
            var style = new StringBuilder();
            if (drawStyle.HasFlag(DrawStyle.BackgroundColor))
                style.Append($"background-color: {data.BackgroundColor};");
            if (drawStyle.HasFlag(DrawStyle.Color))
                style.Append($"color: {data.Color};");
            return style.Length == 0 ? null : style.ToString();
        }
    }
}
