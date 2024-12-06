using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    public class FluentIdFieldDesign : IdFieldDesign
    {
        public FluentIdFieldDesign() => TypeFullName = typeof(FluentIdFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentIdFieldComponent).FullName!;
    }
}
