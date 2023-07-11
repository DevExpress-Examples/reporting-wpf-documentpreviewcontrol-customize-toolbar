using System.Globalization;
using System.Windows;
using DevExpress.Xpf.Printing;

namespace CustomizePreviewToolbar {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private SimpleLink link;

        public MainWindow() {
            InitializeComponent();

            // Creates a document to display.
            string[] data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;

            link = new SimpleLink {
                DetailTemplate = (DataTemplate)Resources["dayNameTemplate"],
                DetailCount = data.Length
            };
            link.CreateDetail += (s, e) => e.Data = data[e.DetailIndex];

            preview.DocumentSource = link;
            link.CreateDocument();
        }

        private void CreateDocument_ItemClick(object sender, 
            DevExpress.Xpf.Bars.ItemClickEventArgs e) 
        {
            link.CreateDocument();
        }

        private void ClearPreview_ItemClick(object sender, 
            DevExpress.Xpf.Bars.ItemClickEventArgs e) 
        {
            link.PrintingSystem.ClearContent();
        }
    }
}
