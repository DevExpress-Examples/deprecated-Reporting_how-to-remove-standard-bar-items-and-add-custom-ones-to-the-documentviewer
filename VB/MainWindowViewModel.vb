Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Printing

' ...
Namespace WpfApplication1

    Friend Class MainWindowViewModel

        Private _PreviewModel As LinkPreviewModel, _CreateDocumentCommand As DelegateCommand, _ClearDocumentCommand As DelegateCommand

        Public Property PreviewModel As LinkPreviewModel
            Get
                Return _PreviewModel
            End Get

            Private Set(ByVal value As LinkPreviewModel)
                _PreviewModel = value
            End Set
        End Property

        Public Property CreateDocumentCommand As DelegateCommand
            Get
                Return _CreateDocumentCommand
            End Get

            Private Set(ByVal value As DelegateCommand)
                _CreateDocumentCommand = value
            End Set
        End Property

        Public Property ClearDocumentCommand As DelegateCommand
            Get
                Return _ClearDocumentCommand
            End Get

            Private Set(ByVal value As DelegateCommand)
                _ClearDocumentCommand = value
            End Set
        End Property

        Public Sub New()
            CreateDocumentCommand = New DelegateCommand(AddressOf ExecuteCreateDocumentCommand)
            ClearDocumentCommand = New DelegateCommand(AddressOf ExecuteClearDocumentCommand, AddressOf CanExecuteClearDocumentCommand)
            PreviewModel = New LinkPreviewModel()
        End Sub

        Private Sub ExecuteCreateDocumentCommand()
            PreviewModel.Link.CreateDocument(True)
            ClearDocumentCommand.RaiseCanExecuteChanged()
        End Sub

        Private Function CanExecuteClearDocumentCommand() As Boolean
            Return Not PreviewModel.IsEmptyDocument
        End Function

        Private Sub ExecuteClearDocumentCommand()
            PreviewModel.Link.PrintingSystem.ClearContent()
            ClearDocumentCommand.RaiseCanExecuteChanged()
        End Sub

'#Region "INotifyPropertyChanged"
        Public Event PropertyChanged As PropertyChangedEventHandler

        Private Sub RaisePropertyChanged(ByVal propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
'#End Region
    End Class
End Namespace
