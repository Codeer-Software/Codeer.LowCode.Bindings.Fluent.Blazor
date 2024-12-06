using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Bindings.Fluent.Blazor.Search;
using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    public class FluentRadioGroupFieldDesign : RadioGroupFieldDesign
    {
        public FluentRadioGroupFieldDesign() => TypeFullName = typeof(FluentRadioGroupFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentRadioGroupFieldComponent).FullName!;
        public override string GetSearchWebComponentTypeFullName() => typeof(FluentRadioGroupComponent).FullName!;
    }
}
