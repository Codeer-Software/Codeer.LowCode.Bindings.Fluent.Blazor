using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Bindings.Fluent.Blazor.Search;
using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    public class FluentBooleanFieldDesign : BooleanFieldDesign
    {
        public FluentBooleanFieldDesign() => TypeFullName = typeof(FluentBooleanFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentBooleanFieldComponent).FullName!;
        public override string GetSearchWebComponentTypeFullName() => typeof(FluentBooleanComponent).FullName!;
    }
}
