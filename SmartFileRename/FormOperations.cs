using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace SmartFileRename
{
    public static partial class FormOperations
    {
        public static DisplayModeOption DisplayMode;

        public static void RefreshListViewItemDisplayMode(ListView listView)
        {
            switch (DisplayMode)
            {
                case DisplayModeOption.Full:
                    listView.Columns[0].Text = "Full Name";
                    break;

                case DisplayModeOption.NameOnly:
                    listView.Columns[0].Text = "File Name";
                    break;

                case DisplayModeOption.DiscrepancyOnly:
                    listView.Columns[0].Text = "Discrepancy Name";
                    break;
            }

            listView.BeginUpdate();
            int virtualListSize = listView.VirtualListSize;
            listView.VirtualListSize = 0;
            listView.VirtualListSize = virtualListSize;
            listView.EndUpdate();
        }

        public static void RefreshListViewCount(FileList filePathList, ListView listView, Label fileCountLabel)
        {
            listView.BeginUpdate();
            fileCountLabel.Text = $"{filePathList.Count} file(s)";
            listView.VirtualListSize = 0;
            listView.VirtualListSize = filePathList.Count;
            listView.EndUpdate();
        }

        public static void AddFile(OpenFileDialog openFileDialog, FileList filePathList)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathList.AddRange(openFileDialog.FileNames);
            }
        }

        public static void AddFolder(FolderBrowserDialog folderBrowseDialog, FileList filePathList)
        {
            if (folderBrowseDialog.ShowDialog() == DialogResult.OK)
            {
                filePathList.AddRange(Directory.EnumerateFiles(folderBrowseDialog.SelectedPath));
            }
        }

        public static void RemoveEntry(FileList filePathList, int indexToRemove)
        {
            filePathList.RemoveAt(indexToRemove);
        }

        public static void RemoveEntries(FileList filePathList, IList<int> indexesToRemove)
        {
            filePathList.RemoveAt(indexesToRemove);
        }

        public static void ClearEntry(FileList filePathList)
        {
            filePathList.ClearAll();
        }

        public static void FilterEntry(FileList filePathList, string key)
        {
            filePathList.RemoveAll(key.Split(';'));
        }

        public static void FilterType(FileList filePathList, FileDataInfo.FileTypeEnum fileType)
        {
            filePathList.RemoveAll(x => x.FileType != fileType);
        }

        public static void MoveListViewItemUp(ListView listView, FileList fileList)
        {
            fileList.MoveUp(listView.SelectedIndices.Cast<int>().ToArray());
        }

        public static void MoveListViewItemDown(ListView listView, FileList fileList)
        {
            fileList.MoveDown(listView.SelectedIndices.Cast<int>().ToArray());
        }

        public static void MoveListViewItemTop(ListView listView, FileList fileList)
        {
            fileList.MoveTop(listView.SelectedIndices.Cast<int>().ToArray());
        }

        public static void MoveListViewItemBottom(ListView listView, FileList fileList)
        {
            fileList.MoveBottom(listView.SelectedIndices.Cast<int>().ToArray());
        }

        #region ToFix
        public static void ReorderListViewItemByDragDrop(FileList fileList, IList<int> selectedIndexes, int newPosition)
        {
            fileList.MoveToIndex(newPosition, selectedIndexes);
        }

        public static void AddEntryByDragDrop(FileList fileList, string[] filesPathsToAdd, int newPosition)
        {
            fileList.InsertRange(newPosition, filesPathsToAdd.Select(x => new FileDataInfo(x)));
        }

        private static bool CanFindInListViewItem(string entryName, ListView listView)
        {
            return listView.Items.Cast<ListViewItem>().Any(lvi => lvi.Text == entryName);
        }
        #endregion ToFix
    }
}
