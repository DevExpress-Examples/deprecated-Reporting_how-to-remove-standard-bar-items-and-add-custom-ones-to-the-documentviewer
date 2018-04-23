Imports DevExpress.Xpf.Mvvm
Imports DevExpress.Xpf.Printing
' ...

Namespace ToolbarWPF
    Public Class MainWindowViewModel
        Public Property PreviewModel() As LinkPreviewModel
        Public Property CreateDocumentCommand() As DelegateCommand
        Public Property ClearDocumentCommand() As DelegateCommand

        Public Sub New()
            CreateDocumentCommand = New DelegateCommand(AddressOf ExecuteCreateDocumentCommand)
            ClearDocumentCommand = New DelegateCommand(AddressOf ExecuteClearDocumentCommand, AddressOf CanExecuteClearDocumentCommand)
            PreviewModel = New LinkPreviewModel()
        End Sub

        Sub ExecuteCreateDocumentCommand()
            PreviewModel.Link.CreateDocument(True)
            ClearDocumentCommand.RaiseCanExecuteChanged()
        End Sub

        Function CanExecuteClearDocumentCommand() As Boolean
            Return Not PreviewModel.IsEmptyDocument
        End Function

        Sub ExecuteClearDocumentCommand()
            PreviewModel.Link.PrintingSystem.ClearContent()
            ClearDocumentCommand.RaiseCanExecuteChanged()
        End Sub
    End Class
End Namespace