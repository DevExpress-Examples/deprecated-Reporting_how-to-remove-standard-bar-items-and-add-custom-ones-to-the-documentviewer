using System.ComponentModel;
using System.Windows.Input;
using DevExpress.Xpf.Core.Commands;
using DevExpress.Xpf.Printing;
// ...

namespace ToolbarWPF {
    class MainWindowViewModel : INotifyPropertyChanged {
        readonly DelegateCommand<object> createDocumentCommand;
        readonly DelegateCommand<object> clearDocumentCommand;
        LinkPreviewModel previewModel;

        public IDocumentPreviewModel PreviewModel {
            get { return previewModel; }
            private set {
                if(previewModel == value)
                    return;
                previewModel = (LinkPreviewModel)value;
                RaisePropertyChanged("PreviewModel");
            }
        }
        public ICommand CreateDocumentCommand { get { return createDocumentCommand; } }
        public ICommand ClearDocumentCommand { get { return clearDocumentCommand; } }

        public MainWindowViewModel() {
            createDocumentCommand = new DelegateCommand<object>(ExecuteCreateDocumentCommand, CanExecuteCreateDocumentCommand);
            clearDocumentCommand = new DelegateCommand<object>(ExecuteClearDocumentCommand, CanExecuteClearDocumentCommand);
            PreviewModel = new LinkPreviewModel();
        }

        bool CanExecuteCreateDocumentCommand(object parameter) {
            return true;
        }

        void ExecuteCreateDocumentCommand(object parameter) {
            previewModel.Link.CreateDocument(true);
            clearDocumentCommand.RaiseCanExecuteChanged();
        }

        bool CanExecuteClearDocumentCommand(object parameter) {
            return !PreviewModel.IsEmptyDocument;
        }

        void ExecuteClearDocumentCommand(object parameter) {
            previewModel.Link.PrintingSystem.ClearContent();
            clearDocumentCommand.RaiseCanExecuteChanged();
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string propertyName) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}