using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    public class FluentPasswordFieldDesign : PasswordFieldDesign
    {
        public FluentPasswordFieldDesign() => TypeFullName = typeof(FluentPasswordFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentPasswordFieldComponent).FullName!;
    }
}
