using Codeer.LowCode.Bindings.Fluent.Blazor.Components;
using Codeer.LowCode.Bindings.Fluent.Blazor.Search;
using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Designs
{
    public class FluentTextFieldDesign : TextFieldDesign
    {
        public FluentTextFieldDesign() => TypeFullName = typeof(FluentTextFieldDesign).FullName!;
        public override string GetWebComponentTypeFullName() => typeof(FluentTextFieldComponent).FullName!;
        public override string GetSearchWebComponentTypeFullName() => typeof(FluentTextComponent).FullName!;
   }
}
