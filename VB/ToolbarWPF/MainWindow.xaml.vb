Imports Microsoft.VisualBasic
Imports System.Globalization
Imports System.Windows
Imports DevExpress.Xpf.Printing
' ...

Namespace ToolbarWPF
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Private data() As String

		Private ReadOnly Property ViewModel() As MainWindowViewModel
			Get
				Return TryCast(DataContext, MainWindowViewModel)
			End Get
		End Property

		Public Sub New()
			InitializeComponent()

			' Create a document to display.
			data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames

			Dim link As New SimpleLink()
			link.DetailTemplate = CType(Resources("dayNameTemplate"), DataTemplate)
			link.DetailCount = data.Length
			AddHandler link.CreateDetail, AddressOf link_CreateDetail

			CType(ViewModel.PreviewModel, LinkPreviewModel).Link = link
			documentPreview1.Model = ViewModel.PreviewModel

			ViewModel.CreateDocumentCommand.Execute(Nothing)
		End Sub

		Private Sub link_CreateDetail(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
			e.Data = data(e.DetailIndex)
		End Sub
	End Class
End Namespace