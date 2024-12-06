using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Bindings.Fluent.Blazor.Search;
using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    public class FluentLinkFieldDesign : LinkFieldDesign
    {
        public FluentLinkFieldDesign() => TypeFullName = typeof(FluentLinkFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentLinkFieldComponent).FullName!;
        public override string GetSearchWebComponentTypeFullName() => typeof(FluentLinkComponent).FullName!;
    }
}
