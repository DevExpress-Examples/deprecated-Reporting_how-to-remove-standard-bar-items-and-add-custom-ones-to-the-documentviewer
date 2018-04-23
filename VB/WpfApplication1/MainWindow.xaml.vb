Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Globalization
Imports System.Windows
Imports DevExpress.Xpf.Printing
' ...

Namespace WpfApplication1
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Private ReadOnly Property ViewModel() As MainWindowViewModel
			Get
				Return TryCast(DataContext, MainWindowViewModel)
			End Get
		End Property
		Public Sub New()
			InitializeComponent()

			' Create a document to display.
			Dim data() As String = CultureInfo.CurrentCulture.DateTimeFormat.DayNames

			Dim link As SimpleLink = New SimpleLink With {.DetailTemplate = CType(Resources("dayNameTemplate"), DataTemplate), .DetailCount = data.Length}
			AddHandler link.CreateDetail, Function(s, e) e.Data = data(e.DetailIndex)

			ViewModel.PreviewModel.Link = link
			documentViewer1.Model = ViewModel.PreviewModel
			link.CreateDocument()
			ViewModel.CreateDocumentCommand.Execute(Nothing)
		End Sub

	End Class
End Namespace
