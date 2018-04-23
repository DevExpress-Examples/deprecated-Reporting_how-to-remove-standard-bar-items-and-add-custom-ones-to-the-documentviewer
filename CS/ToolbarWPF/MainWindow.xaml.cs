using System.Globalization;
using System.Windows;
using DevExpress.Xpf.Printing;
// ...

namespace ToolbarWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        string[] data;

        MainWindowViewModel ViewModel {
            get { return DataContext as MainWindowViewModel; }
        }

        public MainWindow() {
            InitializeComponent();

            // Create a document to display.
            data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;

            SimpleLink link = new SimpleLink();
            link.DetailTemplate = (DataTemplate)Resources["dayNameTemplate"];
            link.DetailCount = data.Length;
            link.CreateDetail += link_CreateDetail;

            ((LinkPreviewModel)ViewModel.PreviewModel).Link = link;
            documentPreview1.Model = ViewModel.PreviewModel;

            ViewModel.CreateDocumentCommand.Execute(null);
        }

        void link_CreateDetail(object sender, CreateAreaEventArgs e) {
            e.Data = data[e.DetailIndex];
        }
    }
}