Imports System.Globalization
Imports System.Windows
Imports DevExpress.Xpf.Printing

Namespace CustomizePreviewToolbar

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Private link As SimpleLink

        Public Sub New()
            Me.InitializeComponent()
            ' Creates a document to display.
            Dim data As String() = CultureInfo.CurrentCulture.DateTimeFormat.DayNames
            link = New SimpleLink With {.DetailTemplate = CType(Resources("dayNameTemplate"), DataTemplate), .DetailCount = data.Length}
            AddHandler link.CreateDetail, Sub(s, e) e.Data = data(e.DetailIndex)
            Me.preview.DocumentSource = link
            link.CreateDocument()
        End Sub

        Private Sub CreateDocument_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            link.CreateDocument()
        End Sub

        Private Sub ClearPreview_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            link.PrintingSystem.ClearContent()
        End Sub
    End Class
End Namespace
