using FDMatchplanGrabber.Service.Business.Services;
using FDMatchplanGrabber.Service.DesktopApp.Mappers;
using FDMatchplanGrabber.Service.DesktopApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace FDMatchplanGrabber.Service.DesktopApp
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MatchplanGrabberApplicationService _applicationService;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

            _applicationService = new MatchplanGrabberApplicationService();

            // Config file format Combobox
            fileFormatCb.Items.Add(".csv");
            fileFormatCb.SelectedIndex = 0;

            // Config date format Combobox
            dateFormatCb.Items.Add("dd/MM/yyyy");
            dateFormatCb.Items.Add("MM/dd/yyyy");
            dateFormatCb.Items.Add("yyyy/MM/dd");
            dateFormatCb.SelectedIndex = 0;
        }

        private void OnClickStorageLocationBtn(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog
            {
                AutoUpgradeEnabled = true
            };
            var dialogResult = dialog.ShowDialog();

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                var viewModel = this.DataContext as MainWindowViewModel;
                viewModel.ExportDirectory = dialog.SelectedPath;
            }
        }

        private void OnClickGrabMatchplanBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                var viewModel = this.DataContext as MainWindowViewModel;
                var exportedMatches = Task.Run(() => _applicationService.GetMatchesAndWriteToFile(viewModel.MapToArguments())).Result;

                var messageBoxText = $"{exportedMatches.Count()} matches exported to file.";
                ShowMessageBox("Success", messageBoxText, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                var messageBoxText = "An error occurred: " + ex.Message;
                ShowMessageBox("Error", messageBoxText, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowMessageBox(string caption, string messageBoxText, MessageBoxButton button, MessageBoxImage image)
        {
            System.Windows.MessageBox.Show(messageBoxText, caption, button, image);
        }
    }
}
