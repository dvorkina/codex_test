using NetInterfaces;
using System;
using System.ComponentModel;
using System.Globalization;
using Utilities;

namespace Gnss
{

    public class JpsFile : INotifyPropertyChanged, IObserver<IFileLoadStatus>
    {
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private UUID _uuid = UUID.Random();
        private string _name;
        private long _size;
        private DateTime _modified;
        //private bool _isRecA;
        //private bool _isRecB;
        private JpsFileState _state;
        private long _cashed;
        private char _port;
        private bool _isRecording;
        private OperationResult _processingResult = OperationResult.None;

      //  private double _speed;
   //     public DateTime StartCash { get; set; }

        private string _info;
        private string _path;

        [Db]
        public UUID Uuid
        {
            get { return _uuid; }
            set { _uuid = value; }
        }

        [Db]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Db]
        public long Size
        {
            get { return _size; }
            set { _size = value;
                RaisePropertyChanged("Size");
                RaisePropertyChanged("SizeString");
            }
        }

        [Db]
        public DateTime Modified
        {
            get { return _modified; }
            set {
                _modified = value;
                RaisePropertyChanged("Modified");
            }
        }

        //public string CacheParts
        //{
        //    get { return _cacheParts; }
        //    set { _cacheParts = value; }
        //}

        //public bool IsRecA
        //{
        //    get {
        //        return _isRecA; }
        //    set {
        //        _isRecA = value;
        //        RaisePropertyChanged("IsRecA");
        //    }
        //}

        //public bool IsRecB
        //{
        //    get { return _isRecB; }
        //    set { _isRecB = value;
        //        RaisePropertyChanged("IsRecB");
        //    }
        //}

        public bool IsRecording
        {
            get
            {
                return _isRecording;
            }
            set
            {
                _isRecording = value;
                RaisePropertyChanged("IsRecording");
            }
        }

        //public bool IsRecording
        //{
        //    get { return IsRecA || IsRecB; }
        //}

        public bool IsHidden
        {
            get { return Name.StartsWith(".", StringComparison.Ordinal) || Name == "firmware"; }
        }
        public string CashPath { get; set; }

        [Db]
        public UUID ReceiverId { get; set; }
        [Db]
        public string Hash2k { get; set; }

        [Db]
        public JpsFileState State
        {
            get { return _state; }
            set
            {
                _state = value;
                RaisePropertyChanged("State");
            }
        }

        public long Cashed
        {
            get { return _cashed; }
            set
            {
                _cashed = value;
                RaisePropertyChanged("Cashed");
                RaisePropertyChanged("CashedString");
                RaisePropertyChanged("CashedPersent");
            }
        }

        public char Port
        {
            get { return _port; }
            set {
                _port = value;
                RaisePropertyChanged("Port");
            }
        }

        //public double Speed
        //{
        //    get { return _speed; }
        //    set {
        //        _speed = value;
        //        RaisePropertyChanged("Speed");
        //    }
        //}

        public string CashedString
        {
            get
            {
                var conv = ConvertUtils.ConvertBytes(Cashed);
                return string.Format(CultureInfo.InvariantCulture, "{0:0.00} {1}", conv.Digit, conv.Unit);
            }
        }

        public string SizeString
        {
            get
            {
                var conv = ConvertUtils.ConvertBytes(Size);
                return string.Format(CultureInfo.InvariantCulture, "{0:0.00} {1} ({2})", conv.Digit, conv.Unit, Size);
            }
        }

        public bool IsCashing
        {
            get { return State == JpsFileState.Cashing; }
        }

        public bool IsWaiting
        {
            get { return State == JpsFileState.Waiting; }
        }

        public DateTime StartDate { get; set; }

        public OperationResult ProcessingResult
        {
            get { return _processingResult; }
            set
            {
                _processingResult = value;
                RaisePropertyChanged("ProcessingResult");
            }
        }

        public long CashedPersent
        {
            get
            {
                if (Size == 0)
                    return 0;
                if (Cashed > Size)
                    return 100;
                return Cashed * 100 / Size;
            }
            //set
            //{
            //    _cashed = value;
            //    RaisePropertyChanged("CashedString");
            //}
        }

        public string Info
        {
            get { return _info; }
            set
            {
                _info = value;
                RaisePropertyChanged("Info");
            }
        }

        [Db]
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                RaisePropertyChanged("Path");
            }
        }

        public string Extension
        {
            get => System.IO.Path.GetExtension(Name);
        }


        public void OnNext(IFileLoadStatus value)
        {
         //   Debug.WriteLine(@"OnNext ");
            Cashed = value.FileLoaded;
            State = JpsFileState.Cashing;
        }

        public void OnError(Exception error)
        {
            State = JpsFileState.Waiting;
            ProcessingResult = OperationResult.Error;
            Info = error.Message.Trim();
            //Speed = Cashed / ((DateTime.UtcNow - StartCash).TotalSeconds);
            //StartCash = new DateTime();
        }

        public void OnCompleted()
        {
         //   Debug.WriteLine(@"OnCompleted " + Cashed + @" " + Size);
            if (Cashed == Size)
            {
                State = JpsFileState.Ready;
                ProcessingResult = OperationResult.Sucsess;
            }
            //else if (IsRecA || IsRecB)
            //{
            //    State = JpsFileState.Waiting;
            //}
            else
            {
                State = JpsFileState.None;
                ProcessingResult = OperationResult.Canceled;
            }
            //Speed = Cashed / ((DateTime.UtcNow - StartCash).TotalSeconds);
            //StartCash = new DateTime();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
