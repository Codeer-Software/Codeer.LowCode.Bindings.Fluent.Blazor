using Codeer.LowCode.Blazor.Components;
using Codeer.LowCode.Blazor.OperatingModel;
using Codeer.LowCode.Blazor.Repository.Design;

namespace Codeer.LowCode.Bindings.Fluent.Blazor.Infrastructure
{
    public class FluentFieldComponentBase<TField, TBase> : FieldComponentBase<TField>
        where TField : FieldBase where TBase : FieldDesignBase
    {
        protected TBase FluentDesign => (TBase)Field.Design;
    }
}
