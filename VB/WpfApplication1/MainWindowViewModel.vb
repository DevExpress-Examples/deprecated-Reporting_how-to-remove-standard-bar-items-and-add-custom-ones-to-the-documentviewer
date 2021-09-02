Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Printing
' ...

Namespace WpfApplication1
	Friend Class MainWindowViewModel
		Private privatePreviewModel As LinkPreviewModel
		Public Property PreviewModel() As LinkPreviewModel
			Get
				Return privatePreviewModel
			End Get
			Private Set(ByVal value As LinkPreviewModel)
				privatePreviewModel = value
			End Set
		End Property
		Private privateCreateDocumentCommand As DelegateCommand
		Public Property CreateDocumentCommand() As DelegateCommand
			Get
				Return privateCreateDocumentCommand
			End Get
			Private Set(ByVal value As DelegateCommand)
				privateCreateDocumentCommand = value
			End Set
		End Property
		Private privateClearDocumentCommand As DelegateCommand
		Public Property ClearDocumentCommand() As DelegateCommand
			Get
				Return privateClearDocumentCommand
			End Get
			Private Set(ByVal value As DelegateCommand)
				privateClearDocumentCommand = value
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

		#Region "INotifyPropertyChanged"

		Public Event PropertyChanged As PropertyChangedEventHandler

		Private Sub RaisePropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
		#End Region

	End Class
End Namespace
