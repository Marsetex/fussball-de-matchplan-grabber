using System.ComponentModel;
using System;
using System.Collections;

namespace FDMatchplanGrabber.DesktopApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        public readonly ErrorViewModel _errorViewModel;

        private string _urlToMatchplan = "https://fussball.de";
        private string _exportDirectory = "C:\\Temp";
        private string _fileName = "spielplan_export";
        private string _fileFormat;
        private string _dateFormat;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool CanCreate => !HasErrors;

        public bool HasErrors => _errorViewModel.HasErrors;

        public string UrlToMatchplan
        {
            get
            {
                return _urlToMatchplan;
            }
            set
            {
                _errorViewModel.ClearErrors(nameof(UrlToMatchplan));
                _urlToMatchplan = value;
                if (string.IsNullOrWhiteSpace(value))
                {
                    _errorViewModel.AddError(nameof(UrlToMatchplan), "Url is required");
                }
                else
                {
                    
                    OnPropertyChanged(nameof(UrlToMatchplan));
                }
            }
        }

        public string ExportDirectory
        {
            get
            {
                return _exportDirectory;
            }
            set
            {
                if (_exportDirectory != value)
                {
                    _exportDirectory = value;
                    OnPropertyChanged(nameof(ExportDirectory));
                }
            }
        }

        public string FileName
        {
            get { return _fileName; }
            set
            {
                _errorViewModel.ClearErrors(nameof(FileName));
                _fileName = value;
                if (string.IsNullOrWhiteSpace(value))
                {
                    _errorViewModel.AddError(nameof(FileName), "File name is required");
                }
                else
                {
                    OnPropertyChanged(nameof(FileName));
                }
            }
        }

        public string FileFormat
        {
            get { return _fileFormat; }
            set
            {
                if (_fileFormat != value)
                {
                    _fileFormat = value;
                    OnPropertyChanged(nameof(FileFormat));
                }
            }
        }

        public string DateFormat
        {
            get { return _dateFormat; }
            set
            {
                if (_dateFormat != value)
                {
                    _dateFormat = value;
                    OnPropertyChanged(nameof(DateFormat));
                }
            }
        }

        public MainWindowViewModel()
        {
            _errorViewModel = new();
            _errorViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorViewModel.GetErrors(propertyName);
        }

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(CanCreate));
        }
    }
}
