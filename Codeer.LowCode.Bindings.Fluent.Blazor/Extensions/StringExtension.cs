namespace Codeer.LowCode.Bindings.Fluent.Blazor.Extensions
{
    internal static class StringExtension
    {
        public static string DomSafeString(this string s) => "a" + s.Replace("-", "");
    }
}
