using System.Windows;

namespace ReceiverControls
{
    /// <summary>
    /// Main application window hosting <see cref="FileViewControl"/>.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModelService _service = new ViewModelService();

        public MainWindow()
        {
            InitializeComponent();
            FileView.DataContext = _service.GetViewModel<FileViewModel>();
        }
    }
}
