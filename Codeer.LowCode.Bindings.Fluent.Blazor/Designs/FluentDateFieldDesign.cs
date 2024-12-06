using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Bindings.Fluent.Blazor.Search;
using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    public class FluentDateFieldDesign : DateFieldDesign
    {
        [Designer]
        public bool StandardInput { get; set; }

        public FluentDateFieldDesign() => TypeFullName = typeof(FluentDateFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentDateFieldComponent).FullName!;
        public override string GetSearchWebComponentTypeFullName() => typeof(FluentDateComponent).FullName!;
    }
}
