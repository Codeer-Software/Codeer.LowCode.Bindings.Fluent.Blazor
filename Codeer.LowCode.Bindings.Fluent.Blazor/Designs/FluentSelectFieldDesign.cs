using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Bindings.Fluent.Blazor.Search;
using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    public class FluentSelectFieldDesign : SelectFieldDesign
    {
        public FluentSelectFieldDesign() => TypeFullName = typeof(FluentSelectFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentSelectFieldComponent).FullName!;
        public override string GetSearchWebComponentTypeFullName() => typeof(FluentSelectComponent).FullName!;
    }
}
