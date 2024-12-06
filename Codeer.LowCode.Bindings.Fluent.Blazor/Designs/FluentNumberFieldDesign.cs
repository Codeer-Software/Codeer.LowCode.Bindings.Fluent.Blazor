using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Bindings.Fluent.Blazor.Search;
using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    public class FluentNumberFieldDesign : NumberFieldDesign
    {
        public FluentNumberFieldDesign() => TypeFullName = typeof(FluentNumberFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentNumberFieldComponent).FullName!;
        public override string GetSearchWebComponentTypeFullName() => typeof(FluentNumberComponent).FullName!;
    }
}
