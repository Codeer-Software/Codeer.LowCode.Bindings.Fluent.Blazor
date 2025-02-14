using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    public class FluentLabelFieldDesign : LabelFieldDesign
    {
        public FluentLabelFieldDesign() => TypeFullName = typeof(FluentLabelFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentLabelFieldComponent).FullName!;
    }
}
