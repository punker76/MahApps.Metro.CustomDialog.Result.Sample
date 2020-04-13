using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace CustomDialogSample
{
    /// <summary>
    /// Interaction logic for MyCustomDialog.xaml
    /// </summary>
    public partial class MyCustomDialog : CustomDialog
    {
        private TaskCompletionSource<bool> tcs;

        public MyCustomDialog()
            : this(null, null)
        {
        }

        public MyCustomDialog(MetroWindow parentWindow)
            : this(parentWindow, null)
        {
        }

        public MyCustomDialog(MetroDialogSettings settings)
            : this(null, settings)
        {
        }

        public MyCustomDialog(MetroWindow parentWindow, MetroDialogSettings settings)
            : base(parentWindow, settings)
        {
            InitializeComponent();

            tcs = new TaskCompletionSource<bool>();
        }

        private void PART_AffirmativeButton_OnClick(object sender, RoutedEventArgs e)
        {
            tcs.SetResult(true);
        }

        private void PART_NegativeButton_OnClick(object sender, RoutedEventArgs e)
        {
            tcs.SetResult(false);
        }

        public Task<bool> WaitForClosingAsync()
        {
            return tcs.Task;
        }
    }
}