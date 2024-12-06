using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Blazor.Repository.Design;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    [IgnoreBaseProperties(nameof(Variant), nameof(Icon))]
    public class FluentButtonFieldDesign : ButtonFieldDesign
    {
        [Designer]
        public Appearance Appearance { get; set; }

        public FluentButtonFieldDesign() => TypeFullName = typeof(FluentButtonFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentButtonFieldComponent).FullName!;
    }
}
