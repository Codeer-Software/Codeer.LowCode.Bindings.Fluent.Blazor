using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Blazor.Repository.Design;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    [IgnoreBaseProperties(nameof(Variant), nameof(Icon), nameof(ImageResourceSet), nameof(ShowTextInToolTip))]
    public class FluentButtonFieldDesign : ButtonFieldDesign
    {
        [Designer]
        [EnumIgnore(Appearance.Hypertext)]
        [EnumIgnore(Appearance.Filled)]
        public Appearance Appearance { get; set; }

        public FluentButtonFieldDesign() => TypeFullName = typeof(FluentButtonFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentButtonFieldComponent).FullName!;
    }
}
