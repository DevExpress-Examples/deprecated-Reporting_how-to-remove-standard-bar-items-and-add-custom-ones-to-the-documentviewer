using System.Globalization;
using System.Windows;
using DevExpress.Xpf.Printing;
// ...

namespace ToolbarWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        MainWindowViewModel ViewModel {
            get { return DataContext as MainWindowViewModel; }
        }

        public MainWindow() {
            InitializeComponent();

            // Create a document to display.
            string[] data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;

            var link = new SimpleLink {
                DetailTemplate = (DataTemplate)Resources["dayNameTemplate"],
                DetailCount = data.Length
            };
            link.CreateDetail += (s, e) => e.Data = data[e.DetailIndex];

            ViewModel.PreviewModel.Link = link;
            documentPreview1.Model = ViewModel.PreviewModel;

            ViewModel.CreateDocumentCommand.Execute(null);
        }
    }
}