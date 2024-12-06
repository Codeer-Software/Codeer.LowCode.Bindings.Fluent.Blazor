using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    public class FluentRadioButtonFieldDesign : RadioButtonFieldDesign
    {
        public FluentRadioButtonFieldDesign() => TypeFullName = typeof(FluentRadioButtonFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentRadioButtonFieldComponent).FullName!;
    }
}
