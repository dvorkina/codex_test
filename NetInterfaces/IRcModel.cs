using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gnss;

namespace NetInterfaces
{
    public interface IRcModel
    {
        ObservableCollection<JpsFile> JpsFiles { get; }
        ReceiverInfoParams InfoParams { get; }

        bool Connected { get; set; }
        string Model { get; set; }
        ReceiverAction CurrentAction { get; }
        OperationResult ActionResult { get; }

        void ClearAction();
        void StartAction(ReceiverAction action);
        void FinishAction(OperationResult result);
        void FinishCancel();
        void FinishError(string message);

        Task<bool> DeleteFile(string fileName);
        Task<bool> DeleteFiles(string[] fileNames);
        Task<bool> DeleteAllFiles();
        Task<bool> CheckFileExists(string fileName);
        Task<string> CreateFile(string fileName, char port);
        Task<string> SetCurFile(string fileName, char port);
        Task<string> SetCurFileParams(char port, double mask, double interval, string msgSet);
        Task<string> StartFile(char port, double interval, string msgSet);
        Task<OperationResult> StartNewFileAsync(string fileName, char port, int mask, double interval, string msgSet);
        Task<string[]> GetCurFileParams(char port);
        Task<string> StoptFile(char port);
        Task<OperationResult> StopRecordingAsync(char port);
        Task SendFreeEvent(string site, string antId, string height, bool slant);
        Task StartDownload();
        void CancelDownLoadingFiles(JpsFile[] jpsFiles);
        void CancelDownLoadingFiles();
        Task RefreshFileList();
        Task UpdateInfoParamsAsync();
    }
}
