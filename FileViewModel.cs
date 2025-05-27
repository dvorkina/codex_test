using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Gnss;
using NetInterfaces;

namespace ReceiverControls
{
    /// <summary>
    /// Simple view model used by <see cref="FileViewControl"/>.
    /// This implementation provides only minimal logic required
    /// for the sample control to work inside the repository.
    /// </summary>
    public class FileViewModel : INotifyPropertyChanged, IJpsFilesModel
    {
        private bool _connected;
        private string _model = string.Empty;
        private ReceiverAction _currentAction = ReceiverAction.None;
        private OperationResult _actionResult = OperationResult.None;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<JpsFile> JpsFiles { get; } = new ObservableCollection<JpsFile>();

        public ReceiverInfoParams InfoParams { get; } = new ReceiverInfoParams();

        public bool Connected
        {
            get => _connected;
            set
            {
                if (_connected != value)
                {
                    _connected = value;
                    RaisePropertyChanged(nameof(Connected));
                }
            }
        }

        public string Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                    RaisePropertyChanged(nameof(Model));
                }
            }
        }

        public ReceiverAction CurrentAction
        {
            get => _currentAction;
            private set
            {
                if (_currentAction != value)
                {
                    _currentAction = value;
                    RaisePropertyChanged(nameof(CurrentAction));
                }
            }
        }

        public OperationResult ActionResult
        {
            get => _actionResult;
            private set
            {
                if (_actionResult != value)
                {
                    _actionResult = value;
                    RaisePropertyChanged(nameof(ActionResult));
                }
            }
        }

        public void ClearAction()
        {
            CurrentAction = ReceiverAction.None;
            ActionResult = OperationResult.None;
        }

        public void StartAction(ReceiverAction action)
        {
            CurrentAction = action;
            ActionResult = OperationResult.Started;
        }

        public void FinishAction(OperationResult result)
        {
            ActionResult = result;
            CurrentAction = ReceiverAction.None;
        }

        public void FinishCancel()
        {
            ActionResult = OperationResult.Canceled;
            CurrentAction = ReceiverAction.None;
        }

        public void FinishError(string message)
        {
            ActionResult = OperationResult.Error;
            InfoParams.CurMem = message;
            CurrentAction = ReceiverAction.None;
        }

        // ------------------------- file operations -------------------------

        public Task<bool> DeleteFile(string fileName)
        {
            var file = JpsFiles.FirstOrDefault(f => f.Name == fileName);
            if (file != null)
            {
                JpsFiles.Remove(file);
            }
            return Task.FromResult(true);
        }

        public Task<bool> DeleteFiles(string[] fileNames)
        {
            foreach (var name in fileNames)
            {
                var f = JpsFiles.FirstOrDefault(j => j.Name == name);
                if (f != null)
                {
                    JpsFiles.Remove(f);
                }
            }
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAllFiles()
        {
            JpsFiles.Clear();
            return Task.FromResult(true);
        }

        public Task<bool> CheckFileExists(string fileName)
        {
            return Task.FromResult(JpsFiles.Any(f => f.Name == fileName));
        }

        public Task<string> CreateFile(string fileName, char port)
        {
            JpsFiles.Add(new JpsFile
            {
                Name = fileName,
                Modified = DateTime.UtcNow,
                State = JpsFileState.None,
                Port = port
            });
            return Task.FromResult(string.Empty);
        }

        public Task<string> SetCurFile(string fileName, char port)
        {
            // stub implementation just updates modified date
            var file = JpsFiles.FirstOrDefault(f => f.Name == fileName);
            if (file != null)
            {
                file.Modified = DateTime.UtcNow;
                file.Port = port;
            }
            return Task.FromResult(string.Empty);
        }

        public Task<string> SetCurFileParams(char port, double mask, double interval, string msgSet)
        {
            // parameters are not used in this simple sample
            return Task.FromResult(string.Empty);
        }

        public Task<string> StartFile(char port, double interval, string msgSet)
        {
            return Task.FromResult(string.Empty);
        }

        public Task<string[]> GetCurFileParams(char port)
        {
            return Task.FromResult(new string[3]);
        }

        public Task<string> StoptFile(char port)
        {
            return Task.FromResult(string.Empty);
        }

        public Task SendFreeEvent(string site, string antId, string height, bool slant)
        {
            // nothing to do in stub
            return Task.CompletedTask;
        }

        public Task StartDownload()
        {
            // nothing to download in this stub
            return Task.CompletedTask;
        }

        public void CancelDownLoadingFiles(JpsFile[] jpsFiles)
        {
            foreach (var f in jpsFiles)
            {
                f.State = JpsFileState.None;
            }
        }

        public void CancelDownLoadingFiles()
        {
            CancelDownLoadingFiles(JpsFiles.Where(f => f.State == JpsFileState.Cashing || f.State == JpsFileState.Waiting).ToArray());
        }

        public Task RefreshFileList()
        {
            return Task.CompletedTask;
        }

        public Task UpdateInfoParamsAsync()
        {
            return Task.CompletedTask;
        }
    }
}
