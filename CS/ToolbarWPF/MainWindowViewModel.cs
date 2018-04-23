using System.ComponentModel;
using DevExpress.Xpf.Mvvm;
using DevExpress.Xpf.Printing;
// ...

namespace ToolbarWPF {
    class MainWindowViewModel {
        public LinkPreviewModel PreviewModel { get; private set; }
        public DelegateCommand CreateDocumentCommand { get; private set; }
        public DelegateCommand ClearDocumentCommand { get; private set; }

        public MainWindowViewModel() {
            CreateDocumentCommand = new DelegateCommand(ExecuteCreateDocumentCommand);
            ClearDocumentCommand = new DelegateCommand(ExecuteClearDocumentCommand, CanExecuteClearDocumentCommand);
            PreviewModel = new LinkPreviewModel();
        }

        void ExecuteCreateDocumentCommand() {
            PreviewModel.Link.CreateDocument(true);
            ClearDocumentCommand.RaiseCanExecuteChanged();
        }

        bool CanExecuteClearDocumentCommand() {
            return !PreviewModel.IsEmptyDocument;
        }

        void ExecuteClearDocumentCommand() {
            PreviewModel.Link.PrintingSystem.ClearContent();
            ClearDocumentCommand.RaiseCanExecuteChanged();
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