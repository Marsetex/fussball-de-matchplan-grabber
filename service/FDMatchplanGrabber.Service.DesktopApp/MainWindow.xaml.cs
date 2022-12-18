using FDMatchplanGrabber.Service.Business.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace FDMatchplanGrabber.Service.DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MatchplanGrabberApplicationService _applicationService;

        public MainWindow()
        {
            InitializeComponent();

            _applicationService = new MatchplanGrabberApplicationService();

            linkToMatchplanTb.MaxLines = 1;

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
                storageLocationTb.Text = dialog.SelectedPath;
            }
        }

        private void OnClickGrabMatchplanBtn(object sender, RoutedEventArgs e)
        {
            var url = linkToMatchplanTb.Text;
            var storageDirectory = storageLocationTb.Text;
            var fileName = fileNameTb.Text;
            var fileFormat = fileFormatCb.Text;
            var dateFormat = dateFormatCb.Text;

            try
            {
                var exportedMatches = Task.Run(() => _applicationService.GetMatchesAndWriteToFile(url, storageDirectory, fileName, fileFormat, dateFormat)).Result;
                System.Windows.MessageBox.Show($"{exportedMatches.Count()} matches exported to file.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("An error occured: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
