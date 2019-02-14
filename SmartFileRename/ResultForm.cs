using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFileRename
{
    public partial class ResultForm : Form
    {
        private readonly FileList _originalFilePath;
        private readonly FileList _finalFilePath;
        private readonly IList<string> _errorEntries;

        public ResultForm(FileList originalFilePath, FileList finalFilePath, IList<string> errorEntries = null)
        {
            InitializeComponent();
            _originalFilePath = originalFilePath;
            _finalFilePath = finalFilePath;
            _errorEntries = errorEntries;
            AddEntry(false);
        }

        public void RenameTitle(string title)
        {
            Text = title;
        }

        private void AddEntry(bool showFileNameOnly)
        {
            previewListView.BeginUpdate();
            previewListView.Items.Clear();
            for (int i = 0; i < _originalFilePath.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                if (_errorEntries != null && _errorEntries.Contains(_originalFilePath[i].FilePath))
                {
                    lvi.ForeColor = Color.Red;
                }
                lvi.Text = showFileNameOnly ? _originalFilePath[i].FileFullName : _originalFilePath[i].FilePath;
                lvi.SubItems.Add(showFileNameOnly ? _finalFilePath[i].FileFullName : _finalFilePath[i].FilePath);

                previewListView.Items.Add(lvi);
            }
            previewListView.EndUpdate();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showFileNameOnly_CheckedChanged(object sender, EventArgs e)
        {
            AddEntry(showFileNameOnly.Checked);
        }
    }
}
