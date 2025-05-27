using LocalResources.Properties;
using Utilities;

namespace NetInterfaces
{
    public enum JpsFileState
    {
        [LocalizedEnum("")]
        None,
        //  [LocalizedEnum("DeString", NameResourceType = typeof(Resources))]
        [LocalizedEnum("CheckStateString", NameResourceType = typeof(Resources))]
        CheckState,
        [LocalizedEnum("DownloadingString", NameResourceType = typeof(Resources))]
        Cashing,
        //  [LocalizedEnum("AddedToDailyString", NameResourceType = typeof(Resources))]
        //   AddedToDaily,
        [LocalizedEnum("DownloadedString", NameResourceType = typeof(Resources))]
        Ready,
        [LocalizedEnum("Waiting", NameResourceType = typeof(Resources))]
        Waiting,
        Test,
        [LocalizedEnum("AutoProcessingString", NameResourceType = typeof(Resources))]
        AutoProccesing,
        [LocalizedEnum("UserProcessingString", NameResourceType = typeof(Resources))]
        UserProccesing,
        [LocalizedEnum("ProcessedString", NameResourceType = typeof(Resources))]
        Processed,
        Deleted

    }
}
