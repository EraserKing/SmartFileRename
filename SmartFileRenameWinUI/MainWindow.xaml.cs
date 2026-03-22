using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace SmartFileRenameWinUI
{
    public sealed partial class MainWindow : Window
    {
        private FileList subtitleFilePathList = new FileList();
        private FileList movieFilePathList = new FileList();

        public MainWindow()
        {
            this.InitializeComponent();
            Title = "Smart File Renamer";

            // Set window size
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new Windows.Graphics.SizeInt32(1200, 700));

            // Set defaults
            renameTemplateTextBox.Text = "{MovieFileName}{.?SubtitleGroup}{.?Language}{.Extension}";
            displayModeFullName.IsChecked = true;

            // Process command line arguments
            foreach (string arg in Environment.GetCommandLineArgs().Skip(1))
            {
                if (File.Exists(arg))
                {
                    if (FileDataInfo.ParseFileType(arg) == FileDataInfo.FileTypeEnum.Movie)
                        movieFilePathList.Add(arg);
                    else if (FileDataInfo.ParseFileType(arg) == FileDataInfo.FileTypeEnum.Subtitle)
                        subtitleFilePathList.Add(arg);
                }
                if (Directory.Exists(arg))
                {
                    subtitleFilePathList.AddRange(
                        Directory.EnumerateFiles(arg)
                            .Select(x => new FileDataInfo(x))
                            .Where(x => x.FileType == FileDataInfo.FileTypeEnum.Subtitle));
                    movieFilePathList.AddRange(
                        Directory.EnumerateFiles(arg)
                            .Select(x => new FileDataInfo(x))
                            .Where(x => x.FileType == FileDataInfo.FileTypeEnum.Movie));
                }
            }

            RefreshSubtitleListView();
            RefreshMovieListView();
        }

        #region Helpers
        private void RefreshSubtitleListView()
        {
            if (subtitleListView == null) return;
            var items = new List<string>();
            var selectedIndices = new List<int>();
            for (int i = 0; i < subtitleFilePathList.Count; i++)
            {
                items.Add(subtitleFilePathList.GetDisplayValue(i));
                if (subtitleFilePathList[i].IsSelected)
                {
                    selectedIndices.Add(i);
                    subtitleFilePathList[i].IsSelected = false;
                }
            }
            subtitleListView.ItemsSource = items;
            subtitleFileCount.Text = $"{subtitleFilePathList.Count} file(s)";
            foreach (int idx in selectedIndices)
                subtitleListView.SelectRange(new ItemIndexRange(idx, 1));
        }

        private void RefreshMovieListView()
        {
            if (movieListView == null) return;
            var items = new List<string>();
            var selectedIndices = new List<int>();
            for (int i = 0; i < movieFilePathList.Count; i++)
            {
                items.Add(movieFilePathList.GetDisplayValue(i));
                if (movieFilePathList[i].IsSelected)
                {
                    selectedIndices.Add(i);
                    movieFilePathList[i].IsSelected = false;
                }
            }
            movieListView.ItemsSource = items;
            movieFileCount.Text = $"{movieFilePathList.Count} file(s)";
            foreach (int idx in selectedIndices)
                movieListView.SelectRange(new ItemIndexRange(idx, 1));
        }

        private List<int> GetSelectedIndices(ListView listView)
        {
            var indices = new List<int>();
            foreach (var range in listView.SelectedRanges)
            {
                for (int i = range.FirstIndex; i <= range.LastIndex; i++)
                    indices.Add(i);
            }
            indices.Sort();
            return indices;
        }

        private IntPtr GetWindowHandle()
        {
            return WinRT.Interop.WindowNative.GetWindowHandle(this);
        }

        private async Task ShowErrorAsync(string message)
        {
            var dialog = new ContentDialog
            {
                Title = "Error",
                Content = message,
                CloseButtonText = "OK",
                XamlRoot = Content.XamlRoot
            };
            await dialog.ShowAsync();
        }

        private async Task ShowInfoAsync(string title, string message)
        {
            var dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "OK",
                XamlRoot = Content.XamlRoot
            };
            await dialog.ShowAsync();
        }

        private async Task<bool> ShowConfirmAsync(string title, string message)
        {
            var dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                PrimaryButtonText = "OK",
                CloseButtonText = "Cancel",
                XamlRoot = Content.XamlRoot
            };
            return await dialog.ShowAsync() == ContentDialogResult.Primary;
        }

        private async Task<ContentDialogResult> ShowYesNoAsync(string title, string message)
        {
            var dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                PrimaryButtonText = "Yes",
                CloseButtonText = "No",
                XamlRoot = Content.XamlRoot
            };
            return await dialog.ShowAsync();
        }
        #endregion

        #region Option Changes
        private void OptionSpecifySubtitleGroup_Changed(object sender, RoutedEventArgs e)
        {
            if (optionSubtitleGroup != null)
                optionSubtitleGroup.IsEnabled = optionSpecifySubtitleGroup.IsChecked == true;
        }

        private void OptionSpecifyLanguage_Changed(object sender, RoutedEventArgs e)
        {
            if (optionLanguage != null)
                optionLanguage.IsEnabled = optionSpecifyLanguage.IsChecked == true;
        }

        private void OptionSpecifyExtension_Changed(object sender, RoutedEventArgs e)
        {
            if (optionExtension != null)
                optionExtension.IsEnabled = optionSpecifyExtension.IsChecked == true;
        }
        #endregion

        #region Subtitle Add File / Add Folder
        private async void SubtitleAddFile_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".ass");
            picker.FileTypeFilter.Add(".ssa");
            picker.FileTypeFilter.Add(".srt");
            picker.FileTypeFilter.Add(".idx");
            picker.FileTypeFilter.Add(".sub");
            picker.FileTypeFilter.Add("*");
            WinRT.Interop.InitializeWithWindow.Initialize(picker, GetWindowHandle());

            var files = await picker.PickMultipleFilesAsync();
            if (files != null)
            {
                foreach (var file in files)
                    subtitleFilePathList.Add(file.Path);
                RefreshSubtitleListView();
            }
        }

        private async void SubtitleAddFolder_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FolderPicker();
            picker.FileTypeFilter.Add("*");
            WinRT.Interop.InitializeWithWindow.Initialize(picker, GetWindowHandle());

            var folder = await picker.PickSingleFolderAsync();
            if (folder != null)
            {
                subtitleFilePathList.Add(folder.Path);
                RefreshSubtitleListView();
            }
        }
        #endregion

        #region Movie Add File / Add Folder
        private async void MovieAddFile_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".mkv");
            picker.FileTypeFilter.Add(".mp4");
            picker.FileTypeFilter.Add(".avi");
            picker.FileTypeFilter.Add(".wmv");
            picker.FileTypeFilter.Add("*");
            WinRT.Interop.InitializeWithWindow.Initialize(picker, GetWindowHandle());

            var files = await picker.PickMultipleFilesAsync();
            if (files != null)
            {
                foreach (var file in files)
                    movieFilePathList.Add(file.Path);
                RefreshMovieListView();
            }
        }

        private async void MovieAddFolder_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FolderPicker();
            picker.FileTypeFilter.Add("*");
            WinRT.Interop.InitializeWithWindow.Initialize(picker, GetWindowHandle());

            var folder = await picker.PickSingleFolderAsync();
            if (folder != null)
            {
                movieFilePathList.Add(folder.Path);
                RefreshMovieListView();
            }
        }
        #endregion

        #region Remove Entry
        private void SubtitleRemoveEntry_Click(object sender, RoutedEventArgs e)
        {
            var indices = GetSelectedIndices(subtitleListView);
            subtitleFilePathList.RemoveAt(indices);
            RefreshSubtitleListView();
        }

        private void MovieRemoveEntry_Click(object sender, RoutedEventArgs e)
        {
            var indices = GetSelectedIndices(movieListView);
            movieFilePathList.RemoveAt(indices);
            RefreshMovieListView();
        }
        #endregion

        #region Clear
        private void ClearSubtitleList()
        {
            subtitleFilePathList.ClearAll();
            RefreshSubtitleListView();
        }

        private void ClearMovieList()
        {
            movieFilePathList.ClearAll();
            RefreshMovieListView();
        }

        private void SubtitleClear_Click(object sender, RoutedEventArgs e) => ClearSubtitleList();

        private void MovieClear_Click(object sender, RoutedEventArgs e) => ClearMovieList();

        private void DeleteAllPanel_Click(object sender, RoutedEventArgs e)
        {
            ClearSubtitleList();
            ClearMovieList();
        }
        #endregion

        #region Filter
        private async void SubtitleFilterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(subtitleFilterBox.Text))
            {
                await ShowErrorAsync("The filter key cannot be blank");
                return;
            }
            subtitleFilePathList.RemoveAll(subtitleFilterBox.Text.Split(';'));
            RefreshSubtitleListView();
        }

        private void SubtitleAutoFilter_Click(object sender, RoutedEventArgs e)
        {
            subtitleFilePathList.RemoveAll(x => x.FileType != FileDataInfo.FileTypeEnum.Subtitle);
            RefreshSubtitleListView();
        }

        private async void MovieFilterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(movieFilterBox.Text))
            {
                await ShowErrorAsync("The filter key cannot be blank");
                return;
            }
            movieFilePathList.RemoveAll(movieFilterBox.Text.Split(';'));
            RefreshMovieListView();
        }

        private void MovieAutoFilter_Click(object sender, RoutedEventArgs e)
        {
            movieFilePathList.RemoveAll(x => x.FileType != FileDataInfo.FileTypeEnum.Movie);
            RefreshMovieListView();
        }
        #endregion

        #region Move
        private void SubtitleMoveTop_Click(object sender, RoutedEventArgs e)
        {
            subtitleFilePathList.MoveTop(GetSelectedIndices(subtitleListView).ToArray());
            RefreshSubtitleListView();
            subtitleListView.Focus(FocusState.Programmatic);
        }

        private void SubtitleMoveUp_Click(object sender, RoutedEventArgs e)
        {
            subtitleFilePathList.MoveUp(GetSelectedIndices(subtitleListView).ToArray());
            RefreshSubtitleListView();
            subtitleListView.Focus(FocusState.Programmatic);
        }

        private void SubtitleMoveDown_Click(object sender, RoutedEventArgs e)
        {
            subtitleFilePathList.MoveDown(GetSelectedIndices(subtitleListView).ToArray());
            RefreshSubtitleListView();
            subtitleListView.Focus(FocusState.Programmatic);
        }

        private void SubtitleMoveBottom_Click(object sender, RoutedEventArgs e)
        {
            subtitleFilePathList.MoveBottom(GetSelectedIndices(subtitleListView).ToArray());
            RefreshSubtitleListView();
            subtitleListView.Focus(FocusState.Programmatic);
        }

        private void MovieMoveTop_Click(object sender, RoutedEventArgs e)
        {
            movieFilePathList.MoveTop(GetSelectedIndices(movieListView).ToArray());
            RefreshMovieListView();
            movieListView.Focus(FocusState.Programmatic);
        }

        private void MovieMoveUp_Click(object sender, RoutedEventArgs e)
        {
            movieFilePathList.MoveUp(GetSelectedIndices(movieListView).ToArray());
            RefreshMovieListView();
            movieListView.Focus(FocusState.Programmatic);
        }

        private void MovieMoveDown_Click(object sender, RoutedEventArgs e)
        {
            movieFilePathList.MoveDown(GetSelectedIndices(movieListView).ToArray());
            RefreshMovieListView();
            movieListView.Focus(FocusState.Programmatic);
        }

        private void MovieMoveBottom_Click(object sender, RoutedEventArgs e)
        {
            movieFilePathList.MoveBottom(GetSelectedIndices(movieListView).ToArray());
            RefreshMovieListView();
            movieListView.Focus(FocusState.Programmatic);
        }
        #endregion

        #region Auto Sort
        private void SubtitleAutoSort_Changed(object sender, RoutedEventArgs e)
        {
            subtitleFilePathList.AutoSort = subtitleAutoSort.IsChecked == true;
        }

        private void MovieAutoSort_Changed(object sender, RoutedEventArgs e)
        {
            movieFilePathList.AutoSort = movieAutoSort.IsChecked == true;
        }

        private void SubtitleSort_Click(object sender, RoutedEventArgs e)
        {
            subtitleFilePathList.Sort();
            RefreshSubtitleListView();
        }

        private void MovieSort_Click(object sender, RoutedEventArgs e)
        {
            movieFilePathList.Sort();
            RefreshMovieListView();
        }
        #endregion

        #region Drag & Drop
        private void SubtitleListView_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Link;
        }

        private async void SubtitleListView_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                foreach (var item in items)
                {
                    if (item is StorageFile file)
                        subtitleFilePathList.Add(file.Path);
                    else if (item is StorageFolder folder)
                        subtitleFilePathList.Add(folder.Path);
                }
                RefreshSubtitleListView();
            }
        }

        private void MovieListView_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Link;
        }

        private async void MovieListView_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                foreach (var item in items)
                {
                    if (item is StorageFile file)
                        movieFilePathList.Add(file.Path);
                    else if (item is StorageFolder folder)
                        movieFilePathList.Add(folder.Path);
                }
                RefreshMovieListView();
            }
        }

        private void AutoDropPanel_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Link;
        }

        private async void AutoDropPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                foreach (var item in items)
                {
                    if (item is StorageFile file)
                    {
                        if (FileDataInfo.ParseFileType(file.Path) == FileDataInfo.FileTypeEnum.Movie)
                            movieFilePathList.Add(file.Path);
                        else if (FileDataInfo.ParseFileType(file.Path) == FileDataInfo.FileTypeEnum.Subtitle)
                            subtitleFilePathList.Add(file.Path);
                    }
                    else if (item is StorageFolder folder)
                    {
                        foreach (var f in Directory.EnumerateFiles(folder.Path))
                        {
                            if (FileDataInfo.ParseFileType(f) == FileDataInfo.FileTypeEnum.Movie)
                                movieFilePathList.Add(f);
                            else if (FileDataInfo.ParseFileType(f) == FileDataInfo.FileTypeEnum.Subtitle)
                                subtitleFilePathList.Add(f);
                        }
                    }
                }
                RefreshSubtitleListView();
                RefreshMovieListView();
            }
        }
        #endregion

        #region Preview / Rename
        private async void PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!await CheckFileTypeMatch())
                {
                    await ShowInfoAsync("Info", "Preview aborted");
                    return;
                }
                FileList finalFilePaths = InitializeRenameList();
                var resultWindow = new ResultWindow(subtitleFilePathList, finalFilePaths);
                resultWindow.SetTitle("Preview");
                resultWindow.Activate();
            }
            catch (ArgumentException ex)
            {
                await ShowErrorAsync("An error occurred\n" + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                await ShowErrorAsync("An error occurred\n" + ex.Message);
            }
        }

        private async void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!await CheckFileTypeMatch())
                {
                    await ShowInfoAsync("Info", "Rename aborted");
                    return;
                }
                FileList finalFilePaths = InitializeRenameList();
                List<string> errorList = RenameOperations.RenameFiles(subtitleFilePathList, finalFilePaths);

                if (errorList.Count > 0)
                {
                    var result = await ShowYesNoAsync("Warning",
                        "At least an error occurred during renaming. Do you want to check details?");
                    if (result == ContentDialogResult.Primary)
                    {
                        var resultWindow = new ResultWindow(subtitleFilePathList, finalFilePaths, errorList);
                        resultWindow.SetTitle("Result");
                        resultWindow.Activate();
                    }
                }
                else
                {
                    await ShowInfoAsync("Congratulations", "All files have been renamed successfully.");

                    if (optionClearSubtitlesAfterRename.IsChecked == true)
                        ClearSubtitleList();
                    if (optionClearMoviesAfterRename.IsChecked == true)
                        ClearMovieList();
                }
            }
            catch (ArgumentException ex)
            {
                await ShowErrorAsync("An error occurred\n" + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                await ShowErrorAsync("An error occurred\n" + ex.Message);
            }
        }

        private async Task<bool> CheckFileTypeMatch()
        {
            if (subtitleFilePathList.Any(x => x.FileType != FileDataInfo.FileTypeEnum.Subtitle))
            {
                if (!await ShowConfirmAsync("Warning",
                    "Some files in subtitle list may not be subtitle files, continue?"))
                    return false;
            }
            if (movieFilePathList.Any(x => x.FileType != FileDataInfo.FileTypeEnum.Movie))
            {
                if (!await ShowConfirmAsync("Warning",
                    "Some files in movie list may not be movie files, continue?"))
                    return false;
            }
            return true;
        }

        private FileList InitializeRenameList()
        {
            RenameOptions renameOptions = new RenameOptions
            {
                SubtitleFileList = subtitleFilePathList,
                MovieFileList = movieFilePathList,
                Template = renameTemplateTextBox.Text,
                SpecifySubtitleGroup = optionSpecifySubtitleGroup.IsChecked == true,
                SubtitleGroup = optionSubtitleGroup.Text,
                SpecifyLanguage = optionSpecifyLanguage.IsChecked == true,
                Language = optionLanguage.Text,
                SpecifyExtension = optionSpecifyExtension.IsChecked == true,
                Extension = optionExtension.Text,
                MoveToMovieFolder = optionMoveToMovieFolder.IsChecked == true
            };

            return RenameOperations.GenerateRenameList(renameOptions);
        }
        #endregion

        #region Display Mode
        private void DisplayModeFullName_Checked(object sender, RoutedEventArgs e)
        {
            if (subtitleListView == null || movieListView == null) return;
            subtitleFilePathList.DisplayMode = DisplayModeOption.Full;
            movieFilePathList.DisplayMode = DisplayModeOption.Full;
            RefreshSubtitleListView();
            RefreshMovieListView();
        }

        private void DisplayModeFileName_Checked(object sender, RoutedEventArgs e)
        {
            if (subtitleListView == null || movieListView == null) return;
            subtitleFilePathList.DisplayMode = DisplayModeOption.NameOnly;
            movieFilePathList.DisplayMode = DisplayModeOption.NameOnly;
            RefreshSubtitleListView();
            RefreshMovieListView();
        }

        private void DisplayModeDiscrepancyName_Checked(object sender, RoutedEventArgs e)
        {
            if (subtitleListView == null || movieListView == null) return;
            subtitleFilePathList.DisplayMode = DisplayModeOption.DiscrepancyOnly;
            movieFilePathList.DisplayMode = DisplayModeOption.DiscrepancyOnly;
            RefreshSubtitleListView();
            RefreshMovieListView();
        }
        #endregion

        #region Keyboard
        private void SubtitleListView_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Delete)
                SubtitleRemoveEntry_Click(sender, e);
        }

        private void MovieListView_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Delete)
                MovieRemoveEntry_Click(sender, e);
        }
        #endregion

        #region LostFocus
        private void SubtitleListView_LostFocus(object sender, RoutedEventArgs e)
        {
            subtitleFilePathList.ClearSelection();
        }

        private void MovieListView_LostFocus(object sender, RoutedEventArgs e)
        {
            movieFilePathList.ClearSelection();
        }
        #endregion

        #region Always On Top
        private void OptionAlwaysOnTop_Changed(object sender, RoutedEventArgs e)
        {
            var hwnd = GetWindowHandle();
            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            if (appWindow.Presenter is Microsoft.UI.Windowing.OverlappedPresenter presenter)
            {
                presenter.IsAlwaysOnTop = optionAlwaysOnTop.IsChecked == true;
            }
        }
        #endregion
    }
}
