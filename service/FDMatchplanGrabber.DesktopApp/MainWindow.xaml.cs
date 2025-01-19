using FDMatchplanGrabber.Business.Services.Contracts;
using FDMatchplanGrabber.DesktopApp.Mappers;
using FDMatchplanGrabber.DesktopApp.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace FDMatchplanGrabber.DesktopApp;

public partial class MainWindow : Window
{
    private readonly IMatchplanGrabberApplicationService _matchplanGrabberApplicationService;

    public MainWindow(IMatchplanGrabberApplicationService matchplanGrabberApplicationService)
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel();
        _matchplanGrabberApplicationService = matchplanGrabberApplicationService;

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
            var viewModel = (MainWindowViewModel)this.DataContext;
            viewModel.ExportDirectory = dialog.SelectedPath;
        }
    }

    private void OnClickGrabMatchplanBtn(object sender, RoutedEventArgs e)
    {
        try
        {
            var viewModel = (MainWindowViewModel)this.DataContext;
            if(viewModel.HasErrors)
            {
                return;
            }

            var exportedMatches = Task.Run(() => _matchplanGrabberApplicationService.GetMatchesAndWriteToFile(viewModel.MapToArguments())).Result;

            var messageBoxText = $"{exportedMatches.Count()} matches exported to file. Would you like to open the file output directory?";
            var result = ShowMessageBox("Success", messageBoxText, MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)
            {
                Process.Start("explorer.exe" ,viewModel.ExportDirectory);
            }
        }
        catch (Exception ex)
        {
            var messageBoxText = "An error occurred: " + ex.Message;
            ShowMessageBox("Error", messageBoxText, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private static MessageBoxResult ShowMessageBox(string caption, string messageBoxText, MessageBoxButton button, MessageBoxImage image)
    {
        return System.Windows.MessageBox.Show(messageBoxText, caption, button, image);
    }
}
