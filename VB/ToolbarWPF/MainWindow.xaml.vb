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
        'Private data() As String

        ReadOnly Property ViewModel() As MainWindowViewModel
            Get
                Return CType(DataContext, MainWindowViewModel)
            End Get
        End Property

        Public Sub New()
            InitializeComponent()

            ' Create a document to display.
            Dim data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames

            Dim link As New SimpleLink With {
                .DetailTemplate = CType(Resources("dayNameTemplate"), DataTemplate),
                .DetailCount = data.Length
            }
            AddHandler link.CreateDetail, Sub(s, e)
                                              e.Data = data(e.DetailIndex)
                                          End Sub

            ViewModel.PreviewModel.Link = link
            documentPreview1.Model = ViewModel.PreviewModel

            ViewModel.CreateDocumentCommand.Execute(Nothing)
        End Sub
    End Class
End Namespace