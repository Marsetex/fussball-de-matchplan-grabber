using FDMatchplanGrabber.DesktopApp.ViewModels;
using FDMatchplanGrabber.Business.Dtos;

namespace FDMatchplanGrabber.DesktopApp.Mappers
{
    internal static class MainWindowMapper
    {
        internal static MatchesFileWriteDto MapToArguments(this MainWindowViewModel viewModel)
        {
            return new MatchesFileWriteDto
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
