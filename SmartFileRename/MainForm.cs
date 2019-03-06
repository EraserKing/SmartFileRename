using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFileRename
{
    public partial class MainForm : Form
    {
        private FileList movieFilePathList = new FileList();
        private FileList subtitleFilePathList = new FileList();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        #region Option change
        private void optionSpecifySubtitleGroup_CheckedChanged(object sender, EventArgs e)
        {
            optionSubtitleGroup.Enabled = optionSpecifySubtitleGroup.Checked;
        }

        private void optionSpecifyLanguage_CheckedChanged(object sender, EventArgs e)
        {
            optionLanguage.Enabled = optionSpecifyLanguage.Checked;
        }

        private void optionSpecifyExtension_CheckedChanged(object sender, EventArgs e)
        {
            optionExtension.Enabled = optionSpecifyExtension.Checked;
        }
        #endregion

        #region Add File / Add Folder
        private void subtitleAddFile_Click(object sender, EventArgs e)
        {
            FormOperations.AddFile(subtitleAddFileDialog, subtitleFilePathList);
            FormOperations.RefreshListViewCount(subtitleFilePathList, subtitleListView, subtitleFileCount);
        }

        private void subtitleAddFolder_Click(object sender, EventArgs e)
        {
            FormOperations.AddFolder(subtitleAddFolderDialog, subtitleFilePathList);
            FormOperations.RefreshListViewCount(subtitleFilePathList, subtitleListView, subtitleFileCount);
        }

        private void movieAddFile_Click(object sender, EventArgs e)
        {
            FormOperations.AddFile(movieAddFileDialog, movieFilePathList);
            FormOperations.RefreshListViewCount(movieFilePathList, movieListView, movieFileCount);
        }

        private void movieAddFolder_Click(object sender, EventArgs e)
        {
            FormOperations.AddFolder(movieAddFolderDialog, movieFilePathList);
            FormOperations.RefreshListViewCount(movieFilePathList, movieListView, movieFileCount);
        }
        #endregion

        #region Remove Entry
        private void subtitleRemoveEntry_Click(object sender, EventArgs e)
        {
            FormOperations.RemoveEntries(subtitleFilePathList, subtitleListView.SelectedIndices.Cast<int>().ToList());
            FormOperations.RefreshListViewCount(subtitleFilePathList, subtitleListView, subtitleFileCount);
        }

        private void movieRemoveEntry_Click(object sender, EventArgs e)
        {
            FormOperations.RemoveEntries(movieFilePathList, movieListView.SelectedIndices.Cast<int>().ToList());
            FormOperations.RefreshListViewCount(movieFilePathList, movieListView, movieFileCount);
        }
        #endregion

        #region Clear
        private void subtitleClear_Click(object sender, EventArgs e)
        {
            FormOperations.ClearEntry(subtitleFilePathList);
            FormOperations.RefreshListViewCount(subtitleFilePathList, subtitleListView, subtitleFileCount);
        }

        private void movieClear_Click(object sender, EventArgs e)
        {
            FormOperations.ClearEntry(movieFilePathList);
            FormOperations.RefreshListViewCount(movieFilePathList, movieListView, movieFileCount);
        }

        private void deleteAllPanel_Click(object sender, EventArgs e)
        {
            FormOperations.ClearEntry(subtitleFilePathList);
            FormOperations.RefreshListViewCount(subtitleFilePathList, subtitleListView, subtitleFileCount);
            FormOperations.ClearEntry(movieFilePathList);
            FormOperations.RefreshListViewCount(movieFilePathList, movieListView, movieFileCount);
        }
        #endregion

        #region Filter
        private void subtitleFilterButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(subtitleFilterBox.Text))
            {
                MessageBox.Show("The filter key cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FormOperations.FilterEntry(subtitleFilePathList, subtitleFilterBox.Text);
            FormOperations.RefreshListViewCount(subtitleFilePathList, subtitleListView, subtitleFileCount);
        }

        private void subtitleAutoFilter_Click(object sender, EventArgs e)
        {
            FormOperations.FilterType(subtitleFilePathList, FileDataInfo.FileTypeEnum.Subtitle);
            FormOperations.RefreshListViewCount(subtitleFilePathList, subtitleListView, subtitleFileCount);
        }

        private void movieFilterButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(movieFilterBox.Text))
            {
                MessageBox.Show("The filter key cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FormOperations.FilterEntry(movieFilePathList, movieFilterBox.Text);
            FormOperations.RefreshListViewCount(movieFilePathList, movieListView, movieFileCount);
        }

        private void movieAutoFilter_Click(object sender, EventArgs e)
        {
            FormOperations.FilterType(movieFilePathList, FileDataInfo.FileTypeEnum.Movie);
            FormOperations.RefreshListViewCount(movieFilePathList, movieListView, movieFileCount);
        }
        #endregion

        #region Move
        private void subtitleMoveTop_Click(object sender, EventArgs e)
        {
            FormOperations.MoveListViewItemTop(subtitleListView, subtitleFilePathList);
            FormOperations.RefreshListViewCount(subtitleFilePathList, subtitleListView, subtitleFileCount);
            subtitleListView.Focus();
        }

        private void subtitleMoveUp_Click(object sender, EventArgs e)
        {
            FormOperations.MoveListViewItemUp(subtitleListView, subtitleFilePathList);
            FormOperations.RefreshListViewCount(subtitleFilePathList, subtitleListView, subtitleFileCount);
            subtitleListView.Focus();
        }

        private void subtitleMoveDown_Click(object sender, EventArgs e)
        {
            FormOperations.MoveListViewItemDown(subtitleListView, subtitleFilePathList);
            FormOperations.RefreshListViewCount(subtitleFilePathList, subtitleListView, subtitleFileCount);
            subtitleListView.Focus();
        }

        private void subtitleMoveBottom_Click(object sender, EventArgs e)
        {
            FormOperations.MoveListViewItemBottom(subtitleListView, subtitleFilePathList);
            FormOperations.RefreshListViewCount(subtitleFilePathList, subtitleListView, subtitleFileCount);
            subtitleListView.Focus();
        }

        private void movieMovieTop_Click(object sender, EventArgs e)
        {
            FormOperations.MoveListViewItemTop(movieListView, movieFilePathList);
            FormOperations.RefreshListViewCount(movieFilePathList, movieListView, movieFileCount);
            movieListView.Focus();
        }

        private void movieMovieUp_Click(object sender, EventArgs e)
        {
            FormOperations.MoveListViewItemUp(movieListView, movieFilePathList);
            FormOperations.RefreshListViewCount(movieFilePathList, movieListView, movieFileCount);
            movieListView.Focus();
        }

        private void movieMovieDown_Click(object sender, EventArgs e)
        {
            FormOperations.MoveListViewItemDown(movieListView, movieFilePathList);
            FormOperations.RefreshListViewCount(movieFilePathList, movieListView, movieFileCount);
            movieListView.Focus();
        }

        private void movieMovieBottom_Click(object sender, EventArgs e)
        {
            FormOperations.MoveListViewItemBottom(movieListView, movieFilePathList);
            FormOperations.RefreshListViewCount(movieFilePathList, movieListView, movieFileCount);
            movieListView.Focus();
        }
        #endregion

        #region Auto sort
        private void subtitleAutoSort_CheckedChanged(object sender, EventArgs e)
        {
            subtitleFilePathList.AutoSort = subtitleAutoSort.Checked;
        }

        private void movieAutoSort_CheckedChanged(object sender, EventArgs e)
        {
            movieFilePathList.AutoSort = movieAutoSort.Checked;
        }

        private void subtitleSort_Click(object sender, EventArgs e)
        {
            subtitleFilePathList.Sort();
            subtitleListView.VirtualListSize = 0;
            subtitleListView.VirtualListSize = subtitleFilePathList.Count;
        }

        private void movieSort_Click(object sender, EventArgs e)
        {
            movieFilePathList.Sort();
            movieListView.VirtualListSize = 0;
            movieListView.VirtualListSize = movieFilePathList.Count;
        }
        #endregion

        #region Drag & Drop
        private void subtitleListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            subtitleListView.DoDragDrop(subtitleListView.SelectedItems, DragDropEffects.Move);
        }

        private void subtitleListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)) || e.Data.GetDataPresent(typeof(ListView.SelectedIndexCollection)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void subtitleListView_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = subtitleListView.PointToClient(new Point(e.X, e.Y));
            var lvi = subtitleListView.GetItemAt(clientPoint.X, clientPoint.Y);

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                FormOperations.AddEntryByDragDrop(subtitleFilePathList, (string[])e.Data.GetData(DataFormats.FileDrop), lvi?.Index ?? null);
            }
            else if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)) || e.Data.GetDataPresent(typeof(ListView.SelectedIndexCollection)))
            {
                FormOperations.ReorderListViewItemByDragDrop(subtitleFilePathList, subtitleListView.SelectedIndices.Cast<int>().ToList(), lvi?.Index ?? null);
            }
            FormOperations.RefreshListViewCount(subtitleFilePathList, subtitleListView, subtitleFileCount);
        }

        private void movieListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            movieListView.DoDragDrop(movieListView.SelectedIndices, DragDropEffects.Move);
        }

        private void movieListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)) || e.Data.GetDataPresent(typeof(ListView.SelectedIndexCollection)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void movieListView_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = movieListView.PointToClient(new Point(e.X, e.Y));
            var lvi = movieListView.GetItemAt(clientPoint.X, clientPoint.Y);

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                FormOperations.AddEntryByDragDrop(movieFilePathList, (string[])e.Data.GetData(DataFormats.FileDrop), lvi?.Index ?? null);
            }
            else if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)) || e.Data.GetDataPresent(typeof(ListView.SelectedIndexCollection)))
            {
                FormOperations.ReorderListViewItemByDragDrop(movieFilePathList, movieListView.SelectedIndices.Cast<int>().ToList(), lvi?.Index ?? null);
            }
            FormOperations.RefreshListViewCount(movieFilePathList, movieListView, movieFileCount);
        }

        private void autoDropPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void autoDropPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] selectedPaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string selectedPath in selectedPaths)
                {
                    if (File.Exists(selectedPath))
                    {
                        if (FileDataInfo.ParseFileType(selectedPath) == FileDataInfo.FileTypeEnum.Movie)
                        {
                            movieFilePathList.Add(selectedPath);
                        }
                        else if (FileDataInfo.ParseFileType(selectedPath) == FileDataInfo.FileTypeEnum.Subtitle)
                        {
                            subtitleFilePathList.Add(selectedPath);
                        }
                    }

                    if (Directory.Exists(selectedPath))
                    {
                        subtitleFilePathList.AddRange(Directory.EnumerateFiles(selectedPath).Select(x => new FileDataInfo(x)).Where(x => x.FileType == FileDataInfo.FileTypeEnum.Subtitle));
                        movieFilePathList.AddRange(Directory.EnumerateFiles(selectedPath).Select(x => new FileDataInfo(x)).Where(x => x.FileType == FileDataInfo.FileTypeEnum.Movie));
                    }
                }
            }
            FormOperations.RefreshListViewCount(subtitleFilePathList, subtitleListView, subtitleFileCount);
            FormOperations.RefreshListViewCount(movieFilePathList, movieListView, movieFileCount);
        }
        #endregion

        #region Preview / Rename
        private void previewButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckFileTypeMatch())
                {
                    MessageBox.Show("Preview aborted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                FileList finalFilePaths = InitializeRenameList();

                ResultForm previewForm = new ResultForm(subtitleFilePathList, finalFilePaths);
                previewForm.RenameTitle("Preview");
                previewForm.ShowDialog();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("An error occurred\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckFileTypeMatch())
                {
                    MessageBox.Show("Rename aborted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                FileList finalFilePaths = InitializeRenameList();
                List<string> errorList = RenameOperations.RenameFiles(subtitleFilePathList, finalFilePaths);

                if (errorList.Count > 0)
                {
                    if (
                        MessageBox.Show("At least an error occurred during renaming. Do you want to check details?", "Warning", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ResultForm previewForm = new ResultForm(subtitleFilePathList, finalFilePaths, errorList);
                        previewForm.RenameTitle("Result");
                        previewForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("All files have been renamed successfully.", "Conguratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("An error occurred\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool CheckFileTypeMatch()
        {
            if (subtitleFilePathList.Any(x => x.FileType != FileDataInfo.FileTypeEnum.Subtitle) && MessageBox.Show("Some files in subtitle list may not be subtitle files, continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                return false;
            }

            if (movieFilePathList.Any(x => x.FileType != FileDataInfo.FileTypeEnum.Movie) && MessageBox.Show("Some files in movie list may not be movie files, continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
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

                SpecifySubtitleGroup = optionSpecifySubtitleGroup.Checked,
                SubtitleGroup = optionSubtitleGroup.Text,

                SpecifyLanguage = optionSpecifyLanguage.Checked,
                Language = optionLanguage.Text,

                SpecifyExtension = optionSpecifyExtension.Checked,
                Extension = optionExtension.Text,

                MoveToMovieFolder = optionMoveToMovieFolder.Checked
            };

            return RenameOperations.GenerateRenameList(renameOptions);
        }
        #endregion

        #region Display Mode
        private void displayModeFullName_CheckedChanged(object sender, EventArgs e)
        {
            FormOperations.DisplayMode = DisplayModeOption.Full;
            subtitleFilePathList.DisplayMode = DisplayModeOption.Full;
            movieFilePathList.DisplayMode = DisplayModeOption.Full;

            FormOperations.RefreshListViewItemDisplayMode(subtitleListView);
            FormOperations.RefreshListViewItemDisplayMode(movieListView);
        }

        private void displayModeFileName_CheckedChanged(object sender, EventArgs e)
        {
            FormOperations.DisplayMode = DisplayModeOption.NameOnly;
            subtitleFilePathList.DisplayMode = DisplayModeOption.NameOnly;
            movieFilePathList.DisplayMode = DisplayModeOption.NameOnly;

            FormOperations.RefreshListViewItemDisplayMode(subtitleListView);
            FormOperations.RefreshListViewItemDisplayMode(movieListView);
        }

        private void displayModeDiscrepancyName_CheckedChanged(object sender, EventArgs e)
        {
            FormOperations.DisplayMode = DisplayModeOption.DiscrepancyOnly;
            subtitleFilePathList.DisplayMode = DisplayModeOption.DiscrepancyOnly;
            movieFilePathList.DisplayMode = DisplayModeOption.DiscrepancyOnly;

            FormOperations.RefreshListViewItemDisplayMode(subtitleListView);
            FormOperations.RefreshListViewItemDisplayMode(movieListView);
        }
        #endregion

        #region Grid Virtual Mode
        private void subtitleListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = new ListViewItem(subtitleFilePathList.GetDisplayValue(e.ItemIndex));
            if (subtitleFilePathList[e.ItemIndex].IsSelected)
            {
                subtitleFilePathList[e.ItemIndex].IsSelected = false;
                subtitleListView.SelectedIndices.Add(e.ItemIndex);
            }
        }

        private void movieListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = new ListViewItem(movieFilePathList.GetDisplayValue(e.ItemIndex));
            if (movieFilePathList[e.ItemIndex].IsSelected)
            {
                movieFilePathList[e.ItemIndex].IsSelected = false;
                movieListView.SelectedIndices.Add(e.ItemIndex);
            }
        }

        private void subtitleListView_Leave(object sender, EventArgs e)
        {
            subtitleFilePathList.ClearSelection();
        }

        private void movieListView_Leave(object sender, EventArgs e)
        {
            movieFilePathList.ClearSelection();
        }
        #endregion

        #region Keyboard Actions
        private void subtitleListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                subtitleRemoveEntry.PerformClick();
            }
        }

        private void movieListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                movieRemoveEntry.PerformClick();
            }
        }
        #endregion
    }
}
