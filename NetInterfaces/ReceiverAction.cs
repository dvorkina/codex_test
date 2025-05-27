using LocalResources.Properties;
using Utilities;
namespace NetInterfaces
{
    public enum ReceiverAction
    {
        [LocalizedEnum(@"")]
        None,
        [LocalizedEnum("Hyperlink323", NameResourceType = typeof(Resources))]
        Reset,
        [LocalizedEnum("ParInitString", NameResourceType = typeof(Resources))]
        InitPar,
        [LocalizedEnum("ClearNVRAMString", NameResourceType = typeof(Resources))]
        ClearNVRam,
        [LocalizedEnum("FileSystemInitString", NameResourceType = typeof(Resources))]
        InitFileSystem,
        [LocalizedEnum("InfoReportPreparationString", NameResourceType = typeof(Resources))]
        InfoReport,
        [LocalizedEnum("OptionsReportPreparationString", NameResourceType = typeof(Resources))]
        OptionsReport,
        [LocalizedEnum("ParamsReportPreparationString", NameResourceType = typeof(Resources))]
        ParametersReport,
        [LocalizedEnum("FsReportPreparationString", NameResourceType = typeof(Resources))]
        FsReport,
        [LocalizedEnum("FileListString", NameResourceType = typeof(Resources))]
        FileList,
        [LocalizedEnum("UpdateFileListString", NameResourceType = typeof(Resources))]
        FileListUpdate,
        [LocalizedEnum("Window129", NameResourceType = typeof(Resources))]
        StartFile,
        [LocalizedEnum("StopRecordingString", NameResourceType = typeof(Resources))]
        StopFile,
        [LocalizedEnum("FileRemovingString", NameResourceType = typeof(Resources))]
        DeleteFiles,
        [LocalizedEnum("UploadingFileString", NameResourceType = typeof(Resources))]
        FileUploading,
        [LocalizedEnum("FileDownloadingString", NameResourceType = typeof(Resources))]
        FileDownloading,
        [LocalizedEnum("FileTransferingString", NameResourceType = typeof(Resources))]
        FileTransfer,
        [LocalizedEnum("FirmwareStatus", NameResourceType = typeof(Resources))]
        FwUploading,
        [LocalizedEnum("FirmwareDownloading", NameResourceType = typeof(Resources))]
        FwDownloading,
        [LocalizedEnum("OptionFromWebString", NameResourceType = typeof(Resources))]
        OptionsFromWeb,
        [LocalizedEnum("OptionUploadingString", NameResourceType = typeof(Resources))]
        OptionsUploading,
        [LocalizedEnum("OptionActualString", NameResourceType = typeof(Resources))]
        OptionsLoading,
        [LocalizedEnum("ReconnectingString", NameResourceType = typeof(Resources))]
        Reconnecting,
        [LocalizedEnum("ResetRtkString", NameResourceType = typeof(Resources))]
        ResetRtk,
        [LocalizedEnum("Connecting", NameResourceType = typeof(Resources))]
        Connecting,
        [LocalizedEnum("DaisyChainOnString", NameResourceType = typeof(Resources))]
        DaisyChainOn,
        [LocalizedEnum("DaisyChainOffString", NameResourceType = typeof(Resources))]
        DaisyChainOff,
        [LocalizedEnum("ConfiguringReceiverString", NameResourceType = typeof(Resources))]
        Configuring,
        [LocalizedEnum("ConfiguringModemDriverString", NameResourceType = typeof(Resources))]
        ConfiguringModemDriver,
        [LocalizedEnum("InnerModemDetectingString", NameResourceType = typeof(Resources))]
        ModemDetecting,
        [LocalizedEnum("PairingProcessString", NameResourceType = typeof(Resources))]
        ModemPairing,
        [LocalizedEnum("UnpairingProcessString", NameResourceType = typeof(Resources))]
        ModemUnpairing,
        [LocalizedEnum("ModemDriverInfoString", NameResourceType = typeof(Resources))]
        ModemDriverInfo,
        [LocalizedEnum("SpecInit", NameResourceType = typeof(Resources))]
        GnssSpecInit,
        [LocalizedEnum("SpecCollect", NameResourceType = typeof(Resources))]
        GnssSpecCollect,
        [LocalizedEnum("SpecStop", NameResourceType = typeof(Resources))]
        GnssSpecStop,
        [LocalizedEnum("CashingDataString", NameResourceType = typeof(Resources))]
        GnssSpecCash,
        [LocalizedEnum("GnssSpecWaitingString", NameResourceType = typeof(Resources))]
        WaitingGnss,
        [LocalizedEnum("SpecRenderString", NameResourceType = typeof(Resources))]
        SpecRender,
        [LocalizedEnum("SpecStatisticString", NameResourceType = typeof(Resources))]
        GnssSpecStatistic,
        [LocalizedEnum("StartingRadioSpecString", NameResourceType = typeof(Resources))]
        RadioSpecStarting,
        [LocalizedEnum("CollectingRadioSpecString", NameResourceType = typeof(Resources))]
        RadioSpecCollect,
        [LocalizedEnum("SpoofDetectString", NameResourceType = typeof(Resources))]
        SpoofDetect,
        [LocalizedEnum("CompassCalibratingString", NameResourceType = typeof(Resources))]
        CompassCalibration,
        [LocalizedEnum("AccelCalibratingString", NameResourceType = typeof(Resources))]
        AccelCalibration,
        [LocalizedEnum("SaveCalibrationString", NameResourceType = typeof(Resources))]
        SaveCalibration,
        [LocalizedEnum("CancelCalibrationString", NameResourceType = typeof(Resources))]
        CancelCalibration,
        [LocalizedEnum("ReportGeneratingSrting", NameResourceType = typeof(Resources))]
        CalibrationReport,
        [LocalizedEnum("GyroCalibratingString", NameResourceType = typeof(Resources))]
        GyroCalibration,
        [LocalizedEnum("GyroClearString", NameResourceType = typeof(Resources))]
        GyroClear,
        [LocalizedEnum("TableSpinUpString", NameResourceType = typeof(Resources))]
        GyroSpinUp,
        [LocalizedEnum("StopTableString", NameResourceType = typeof(Resources))]
        GyroStop,
        [LocalizedEnum("Waiting for the receiver", NameResourceType = typeof(Resources))]
        WaitingForReceiver,
        //[LocalizedEnum("PortsRefreshString", NameResourceType = typeof(Resources))]
        //PortsRefresh,
        [LocalizedEnum("SpecRadioStop", NameResourceType = typeof(Resources))]
        RadioSpecStop,
        [LocalizedEnum("StartRtpkFileString", NameResourceType = typeof(Resources))]
        StartRtpkFile,
        [LocalizedEnum("StopRtpkFileString", NameResourceType = typeof(Resources))]
        StopRtpkFile,
        [LocalizedEnum("RtpkProcessingString", NameResourceType = typeof(Resources))]
        RtpkFileProcessing,
        //[LocalizedEnum("ModemResetingString", NameResourceType = typeof(Resources))]
        //ModemReseting
        [LocalizedEnum("ImuCalibratingString", NameResourceType = typeof(Resources))]
        ImuCalibration,
        [LocalizedEnum("FwUnzippingString", NameResourceType = typeof(Resources))]
        FwFileUnzipping,
        [LocalizedEnum("FirmwareStatus", NameResourceType = typeof(Resources))]
        FwUploaded,
        [LocalizedEnum("StartDriversString", NameResourceType = typeof(Resources))]
        StartCompass,
        [LocalizedEnum("StopDriversString", NameResourceType = typeof(Resources))]
        StopCompass,
        [LocalizedEnum("BlCalibratingString", NameResourceType = typeof(Resources))]
        BlCalibration,
        [LocalizedEnum("ClearAPListString", NameResourceType = typeof(Resources))]
        ClearApList,
        [LocalizedEnum("ResetImuString", NameResourceType = typeof(Resources))]
        ResetImu,
        [LocalizedEnum("ResetTiltString", NameResourceType = typeof(Resources))]
        ResetTilt,
        [LocalizedEnum("ResetInsString", NameResourceType = typeof(Resources))]
        ResetIns
    }
}
