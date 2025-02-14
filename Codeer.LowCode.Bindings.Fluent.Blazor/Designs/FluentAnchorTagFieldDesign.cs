using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Blazor.Repository.Design;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    [IgnoreBaseProperties(nameof(Style))]
    public class FluentAnchorTagFieldDesign : AnchorTagFieldDesign
    {
        [Designer]
        public Appearance Appearance { get; set; } = Appearance.Hypertext;

        public FluentAnchorTagFieldDesign() => TypeFullName = typeof(FluentAnchorTagFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentAnchorTagFieldComponent).FullName!;
    }
}
