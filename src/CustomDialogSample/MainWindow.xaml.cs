using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace CustomDialogSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel(DialogCoordinator.Instance);
        }
    }
}