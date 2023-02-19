using FDMatchplanGrabber.Service.Business.Arguments;
using FDMatchplanGrabber.Service.DesktopApp.Models;

namespace FDMatchplanGrabber.Service.DesktopApp.Mappers
{
    internal static class MainWindowMapper
    {
        public static MatchesFileWriteArguments MapToArguments(this MainWindowViewModel viewModel)
        {
            return new MatchesFileWriteArguments
            (
                viewModel.UrlToMatchplan,
                viewModel.ExportDirectory,
                viewModel.FileName,
                viewModel.FileFormat,
                viewModel.DateFormat
            );
        }
    }
}
