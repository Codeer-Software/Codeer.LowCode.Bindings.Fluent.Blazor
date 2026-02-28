using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Blazor.Repository.Design;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    [IgnoreBaseProperties(nameof(Variant), nameof(Icon), nameof(ImageResourceSet))]
    public class FluentSubmitButtonFieldDesign : SubmitButtonFieldDesign
    {
        [Designer]
        public Appearance Appearance { get; set; }

        public FluentSubmitButtonFieldDesign() => TypeFullName = typeof(FluentSubmitButtonFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentSubmitButtonFieldComponent).FullName!;
    }
}
