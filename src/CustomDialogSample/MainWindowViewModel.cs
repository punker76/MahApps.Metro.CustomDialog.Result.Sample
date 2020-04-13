using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Xaml.Behaviors.Core;

namespace CustomDialogSample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IDialogCoordinator _dialogCoordinator;

        public MainWindowViewModel(IDialogCoordinator dialogCoordinator)
        {
            _dialogCoordinator = dialogCoordinator;

            OpenDialogCommand = new ActionCommand(OpenDialog);
        }

        private async void OpenDialog()
        {
            var customDialog = new MyCustomDialog();

            await _dialogCoordinator.ShowMetroDialogAsync(this, customDialog);

            var result = await customDialog.WaitForClosingAsync();

            await _dialogCoordinator.HideMetroDialogAsync(this, customDialog);
        }

        public ICommand OpenDialogCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}