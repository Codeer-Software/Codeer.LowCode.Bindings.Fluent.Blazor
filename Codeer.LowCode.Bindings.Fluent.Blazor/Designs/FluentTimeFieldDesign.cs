using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Bindings.Fluent.Blazor.Search;
using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    public class FluentTimeFieldDesign : TimeFieldDesign
    {
        public FluentTimeFieldDesign() => TypeFullName = typeof(FluentTimeFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentTimeFieldComponent).FullName!;
        public override string GetSearchWebComponentTypeFullName() => typeof(FluentTimeComponent).FullName!;
    }
}
