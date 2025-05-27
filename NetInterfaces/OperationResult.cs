using LocalResources.Properties;
using Utilities;

namespace NetInterfaces
{
    public enum OperationResult
    {
        [LocalizedEnum(@"")]
        None,
        [LocalizedEnum("", NameResourceType = typeof(Resources))]
        Sucsess,
        [LocalizedEnum("ErrorString", NameResourceType = typeof(Resources))]
        Error,
        [LocalizedEnum("CanceledString", NameResourceType = typeof(Resources))]
        Canceled,
        [LocalizedEnum("Started", NameResourceType = typeof(Resources))]
        Started,
        [LocalizedEnum("Fld command", NameResourceType = typeof(Resources))]
        FldError

    }
}
