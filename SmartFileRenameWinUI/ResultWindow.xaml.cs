using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System.Collections.Generic;

namespace SmartFileRenameWinUI
{
    public class RenameResultItem
    {
        public string OriginalDisplay { get; set; }
        public string NewDisplay { get; set; }
        public bool HasError { get; set; }
    }

    public sealed partial class ResultWindow : Window
    {
        private readonly FileList _originalFilePath;
        private readonly FileList _finalFilePath;
        private readonly IList<string> _errorEntries;

        public ResultWindow(FileList originalFilePath, FileList finalFilePath, IList<string> errorEntries = null)
        {
            this.InitializeComponent();
            _originalFilePath = originalFilePath;
            _finalFilePath = finalFilePath;
            _errorEntries = errorEntries;

            // Set window size
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new Windows.Graphics.SizeInt32(850, 500));

            PopulateList(false);
        }

        public void SetTitle(string title) => Title = title;

        private void PopulateList(bool showFileNameOnly)
        {
            var items = new List<RenameResultItem>();
            for (int i = 0; i < _originalFilePath.Count; i++)
            {
                items.Add(new RenameResultItem
                {
                    OriginalDisplay = showFileNameOnly
                        ? _originalFilePath[i].FileFullName
                        : _originalFilePath[i].FilePath,
                    NewDisplay = showFileNameOnly
                        ? _finalFilePath[i].FileFullName
                        : _finalFilePath[i].FilePath,
                    HasError = _errorEntries?.Contains(_originalFilePath[i].FilePath) ?? false
                });
            }
            resultListView.ItemsSource = items;
        }

        private void ShowFileNameOnly_Changed(object sender, RoutedEventArgs e)
        {
            PopulateList(showFileNameOnly.IsChecked == true);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ResultListView_ContainerContentChanging(
            ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            if (args.Item is RenameResultItem item && item.HasError)
            {
                args.ItemContainer.Foreground =
                    new SolidColorBrush(Microsoft.UI.Colors.Red);
            }
        }
    }
}
