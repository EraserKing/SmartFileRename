namespace SmartFileRename
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.filePanel = new System.Windows.Forms.Panel();
            this.filePanelSplitter = new System.Windows.Forms.SplitContainer();
            this.subtitleGroupBox = new System.Windows.Forms.GroupBox();
            this.subtitleAutoFilter = new System.Windows.Forms.Button();
            this.subtitleAutoSort = new System.Windows.Forms.CheckBox();
            this.subtitleClear = new System.Windows.Forms.Button();
            this.subtitleRemoveEntry = new System.Windows.Forms.Button();
            this.subtitleAddFolder = new System.Windows.Forms.Button();
            this.subtitleAddFile = new System.Windows.Forms.Button();
            this.subtitleFileCount = new System.Windows.Forms.Label();
            this.subtitleFilterButton = new System.Windows.Forms.Button();
            this.subtitleFilterBox = new System.Windows.Forms.TextBox();
            this.subtitleListView = new System.Windows.Forms.ListView();
            this.subtitleFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subtitleMoveBottom = new System.Windows.Forms.Button();
            this.subtitleMoveDown = new System.Windows.Forms.Button();
            this.subtitleMoveUp = new System.Windows.Forms.Button();
            this.subtitleMoveTop = new System.Windows.Forms.Button();
            this.movieGroupBox = new System.Windows.Forms.GroupBox();
            this.movieAutoFilter = new System.Windows.Forms.Button();
            this.movieAutoSort = new System.Windows.Forms.CheckBox();
            this.movieClear = new System.Windows.Forms.Button();
            this.movieListView = new System.Windows.Forms.ListView();
            this.movieFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.movieRemoveEntry = new System.Windows.Forms.Button();
            this.movieMovieBottom = new System.Windows.Forms.Button();
            this.movieAddFolder = new System.Windows.Forms.Button();
            this.movieMovieDown = new System.Windows.Forms.Button();
            this.movieAddFile = new System.Windows.Forms.Button();
            this.movieMovieTop = new System.Windows.Forms.Button();
            this.movieFileCount = new System.Windows.Forms.Label();
            this.movieMovieUp = new System.Windows.Forms.Button();
            this.movieFilterButton = new System.Windows.Forms.Button();
            this.movieFilterBox = new System.Windows.Forms.TextBox();
            this.subtitleAddFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.movieAddFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.subtitleAddFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.movieAddFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.optionGroupBox = new System.Windows.Forms.GroupBox();
            this.optionDisplayModeGroupBox = new System.Windows.Forms.GroupBox();
            this.displayModeDiscrepancyName = new System.Windows.Forms.RadioButton();
            this.displayModeFileName = new System.Windows.Forms.RadioButton();
            this.displayModeFullName = new System.Windows.Forms.RadioButton();
            this.optionMoveToMovieFolder = new System.Windows.Forms.CheckBox();
            this.optionLanguage = new System.Windows.Forms.TextBox();
            this.optionSpecifyLanguage = new System.Windows.Forms.CheckBox();
            this.renameTemplateLabel = new System.Windows.Forms.Label();
            this.optionSpecifyExtension = new System.Windows.Forms.CheckBox();
            this.renameTemplateTextBox = new System.Windows.Forms.TextBox();
            this.optionSubtitleGroup = new System.Windows.Forms.TextBox();
            this.optionExtension = new System.Windows.Forms.TextBox();
            this.optionSpecifySubtitleGroup = new System.Windows.Forms.CheckBox();
            this.previewButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.deleteAllPanel = new System.Windows.Forms.Panel();
            this.autoDropPanel = new System.Windows.Forms.Panel();
            this.movieSort = new System.Windows.Forms.Button();
            this.subtitleSort = new System.Windows.Forms.Button();
            this.filePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePanelSplitter)).BeginInit();
            this.filePanelSplitter.Panel1.SuspendLayout();
            this.filePanelSplitter.Panel2.SuspendLayout();
            this.filePanelSplitter.SuspendLayout();
            this.subtitleGroupBox.SuspendLayout();
            this.movieGroupBox.SuspendLayout();
            this.optionGroupBox.SuspendLayout();
            this.optionDisplayModeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // filePanel
            // 
            this.filePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePanel.Controls.Add(this.filePanelSplitter);
            this.filePanel.Location = new System.Drawing.Point(13, 12);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(1159, 439);
            this.filePanel.TabIndex = 0;
            // 
            // filePanelSplitter
            // 
            this.filePanelSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePanelSplitter.Location = new System.Drawing.Point(3, 3);
            this.filePanelSplitter.Name = "filePanelSplitter";
            // 
            // filePanelSplitter.Panel1
            // 
            this.filePanelSplitter.Panel1.Controls.Add(this.subtitleGroupBox);
            this.filePanelSplitter.Panel1MinSize = 565;
            // 
            // filePanelSplitter.Panel2
            // 
            this.filePanelSplitter.Panel2.Controls.Add(this.movieGroupBox);
            this.filePanelSplitter.Panel2MinSize = 565;
            this.filePanelSplitter.Size = new System.Drawing.Size(1153, 433);
            this.filePanelSplitter.SplitterDistance = 575;
            this.filePanelSplitter.TabIndex = 0;
            // 
            // subtitleGroupBox
            // 
            this.subtitleGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleGroupBox.Controls.Add(this.subtitleSort);
            this.subtitleGroupBox.Controls.Add(this.subtitleAutoFilter);
            this.subtitleGroupBox.Controls.Add(this.subtitleAutoSort);
            this.subtitleGroupBox.Controls.Add(this.subtitleClear);
            this.subtitleGroupBox.Controls.Add(this.subtitleRemoveEntry);
            this.subtitleGroupBox.Controls.Add(this.subtitleAddFolder);
            this.subtitleGroupBox.Controls.Add(this.subtitleAddFile);
            this.subtitleGroupBox.Controls.Add(this.subtitleFileCount);
            this.subtitleGroupBox.Controls.Add(this.subtitleFilterButton);
            this.subtitleGroupBox.Controls.Add(this.subtitleFilterBox);
            this.subtitleGroupBox.Controls.Add(this.subtitleListView);
            this.subtitleGroupBox.Controls.Add(this.subtitleMoveBottom);
            this.subtitleGroupBox.Controls.Add(this.subtitleMoveDown);
            this.subtitleGroupBox.Controls.Add(this.subtitleMoveUp);
            this.subtitleGroupBox.Controls.Add(this.subtitleMoveTop);
            this.subtitleGroupBox.Location = new System.Drawing.Point(3, 3);
            this.subtitleGroupBox.Name = "subtitleGroupBox";
            this.subtitleGroupBox.Size = new System.Drawing.Size(570, 427);
            this.subtitleGroupBox.TabIndex = 0;
            this.subtitleGroupBox.TabStop = false;
            this.subtitleGroupBox.Text = "Subtitles";
            // 
            // subtitleAutoFilter
            // 
            this.subtitleAutoFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleAutoFilter.Location = new System.Drawing.Point(158, 399);
            this.subtitleAutoFilter.Name = "subtitleAutoFilter";
            this.subtitleAutoFilter.Size = new System.Drawing.Size(40, 23);
            this.subtitleAutoFilter.TabIndex = 22;
            this.subtitleAutoFilter.Text = "Auto";
            this.subtitleAutoFilter.UseVisualStyleBackColor = true;
            this.subtitleAutoFilter.Click += new System.EventHandler(this.subtitleAutoFilter_Click);
            // 
            // subtitleAutoSort
            // 
            this.subtitleAutoSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleAutoSort.AutoSize = true;
            this.subtitleAutoSort.Location = new System.Drawing.Point(250, 403);
            this.subtitleAutoSort.Name = "subtitleAutoSort";
            this.subtitleAutoSort.Size = new System.Drawing.Size(70, 17);
            this.subtitleAutoSort.TabIndex = 30;
            this.subtitleAutoSort.Text = "Auto Sort";
            this.subtitleAutoSort.UseVisualStyleBackColor = true;
            this.subtitleAutoSort.CheckedChanged += new System.EventHandler(this.subtitleAutoSort_CheckedChanged);
            // 
            // subtitleClear
            // 
            this.subtitleClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleClear.Location = new System.Drawing.Point(509, 399);
            this.subtitleClear.Name = "subtitleClear";
            this.subtitleClear.Size = new System.Drawing.Size(23, 23);
            this.subtitleClear.TabIndex = 43;
            this.subtitleClear.Text = "X";
            this.subtitleClear.UseVisualStyleBackColor = true;
            this.subtitleClear.Click += new System.EventHandler(this.subtitleClear_Click);
            // 
            // subtitleRemoveEntry
            // 
            this.subtitleRemoveEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleRemoveEntry.Location = new System.Drawing.Point(480, 399);
            this.subtitleRemoveEntry.Name = "subtitleRemoveEntry";
            this.subtitleRemoveEntry.Size = new System.Drawing.Size(23, 23);
            this.subtitleRemoveEntry.TabIndex = 42;
            this.subtitleRemoveEntry.Text = "-";
            this.subtitleRemoveEntry.UseVisualStyleBackColor = true;
            this.subtitleRemoveEntry.Click += new System.EventHandler(this.subtitleRemoveEntry_Click);
            // 
            // subtitleAddFolder
            // 
            this.subtitleAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleAddFolder.Location = new System.Drawing.Point(424, 399);
            this.subtitleAddFolder.Name = "subtitleAddFolder";
            this.subtitleAddFolder.Size = new System.Drawing.Size(50, 23);
            this.subtitleAddFolder.TabIndex = 41;
            this.subtitleAddFolder.Text = "+Folder";
            this.subtitleAddFolder.UseVisualStyleBackColor = true;
            this.subtitleAddFolder.Click += new System.EventHandler(this.subtitleAddFolder_Click);
            // 
            // subtitleAddFile
            // 
            this.subtitleAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleAddFile.Location = new System.Drawing.Point(367, 399);
            this.subtitleAddFile.Name = "subtitleAddFile";
            this.subtitleAddFile.Size = new System.Drawing.Size(50, 23);
            this.subtitleAddFile.TabIndex = 40;
            this.subtitleAddFile.Text = "+File";
            this.subtitleAddFile.UseVisualStyleBackColor = true;
            this.subtitleAddFile.Click += new System.EventHandler(this.subtitleAddFile_Click);
            // 
            // subtitleFileCount
            // 
            this.subtitleFileCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleFileCount.AutoSize = true;
            this.subtitleFileCount.Location = new System.Drawing.Point(204, 404);
            this.subtitleFileCount.Name = "subtitleFileCount";
            this.subtitleFileCount.Size = new System.Drawing.Size(40, 13);
            this.subtitleFileCount.TabIndex = 23;
            this.subtitleFileCount.Text = "0 file(s)";
            // 
            // subtitleFilterButton
            // 
            this.subtitleFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleFilterButton.Location = new System.Drawing.Point(112, 399);
            this.subtitleFilterButton.Name = "subtitleFilterButton";
            this.subtitleFilterButton.Size = new System.Drawing.Size(40, 23);
            this.subtitleFilterButton.TabIndex = 21;
            this.subtitleFilterButton.Text = "Filter";
            this.subtitleFilterButton.UseVisualStyleBackColor = true;
            this.subtitleFilterButton.Click += new System.EventHandler(this.subtitleFilterButton_Click);
            // 
            // subtitleFilterBox
            // 
            this.subtitleFilterBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleFilterBox.Location = new System.Drawing.Point(6, 400);
            this.subtitleFilterBox.Name = "subtitleFilterBox";
            this.subtitleFilterBox.Size = new System.Drawing.Size(100, 20);
            this.subtitleFilterBox.TabIndex = 20;
            // 
            // subtitleListView
            // 
            this.subtitleListView.AllowDrop = true;
            this.subtitleListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.subtitleFileName});
            this.subtitleListView.FullRowSelect = true;
            this.subtitleListView.GridLines = true;
            this.subtitleListView.Location = new System.Drawing.Point(6, 19);
            this.subtitleListView.Name = "subtitleListView";
            this.subtitleListView.Size = new System.Drawing.Size(526, 374);
            this.subtitleListView.TabIndex = 0;
            this.subtitleListView.UseCompatibleStateImageBehavior = false;
            this.subtitleListView.View = System.Windows.Forms.View.Details;
            this.subtitleListView.VirtualMode = true;
            this.subtitleListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.subtitleListView_ItemDrag);
            this.subtitleListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.subtitleListView_RetrieveVirtualItem);
            this.subtitleListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.subtitleListView_DragDrop);
            this.subtitleListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.subtitleListView_DragEnter);
            this.subtitleListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.subtitleListView_KeyDown);
            this.subtitleListView.Leave += new System.EventHandler(this.subtitleListView_Leave);
            // 
            // subtitleFileName
            // 
            this.subtitleFileName.Text = "File";
            this.subtitleFileName.Width = 500;
            // 
            // subtitleMoveBottom
            // 
            this.subtitleMoveBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleMoveBottom.Location = new System.Drawing.Point(538, 209);
            this.subtitleMoveBottom.Name = "subtitleMoveBottom";
            this.subtitleMoveBottom.Size = new System.Drawing.Size(23, 23);
            this.subtitleMoveBottom.TabIndex = 13;
            this.subtitleMoveBottom.Text = "B";
            this.subtitleMoveBottom.UseVisualStyleBackColor = true;
            this.subtitleMoveBottom.Click += new System.EventHandler(this.subtitleMoveBottom_Click);
            // 
            // subtitleMoveDown
            // 
            this.subtitleMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleMoveDown.Location = new System.Drawing.Point(538, 180);
            this.subtitleMoveDown.Name = "subtitleMoveDown";
            this.subtitleMoveDown.Size = new System.Drawing.Size(23, 23);
            this.subtitleMoveDown.TabIndex = 12;
            this.subtitleMoveDown.Text = "D";
            this.subtitleMoveDown.UseVisualStyleBackColor = true;
            this.subtitleMoveDown.Click += new System.EventHandler(this.subtitleMoveDown_Click);
            // 
            // subtitleMoveUp
            // 
            this.subtitleMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleMoveUp.Location = new System.Drawing.Point(538, 150);
            this.subtitleMoveUp.Name = "subtitleMoveUp";
            this.subtitleMoveUp.Size = new System.Drawing.Size(23, 23);
            this.subtitleMoveUp.TabIndex = 11;
            this.subtitleMoveUp.Text = "U";
            this.subtitleMoveUp.UseVisualStyleBackColor = true;
            this.subtitleMoveUp.Click += new System.EventHandler(this.subtitleMoveUp_Click);
            // 
            // subtitleMoveTop
            // 
            this.subtitleMoveTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleMoveTop.Location = new System.Drawing.Point(538, 120);
            this.subtitleMoveTop.Name = "subtitleMoveTop";
            this.subtitleMoveTop.Size = new System.Drawing.Size(23, 23);
            this.subtitleMoveTop.TabIndex = 10;
            this.subtitleMoveTop.Text = "T";
            this.subtitleMoveTop.UseVisualStyleBackColor = true;
            this.subtitleMoveTop.Click += new System.EventHandler(this.subtitleMoveTop_Click);
            // 
            // movieGroupBox
            // 
            this.movieGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.movieGroupBox.Controls.Add(this.movieSort);
            this.movieGroupBox.Controls.Add(this.movieAutoFilter);
            this.movieGroupBox.Controls.Add(this.movieAutoSort);
            this.movieGroupBox.Controls.Add(this.movieClear);
            this.movieGroupBox.Controls.Add(this.movieListView);
            this.movieGroupBox.Controls.Add(this.movieRemoveEntry);
            this.movieGroupBox.Controls.Add(this.movieMovieBottom);
            this.movieGroupBox.Controls.Add(this.movieAddFolder);
            this.movieGroupBox.Controls.Add(this.movieMovieDown);
            this.movieGroupBox.Controls.Add(this.movieAddFile);
            this.movieGroupBox.Controls.Add(this.movieMovieTop);
            this.movieGroupBox.Controls.Add(this.movieFileCount);
            this.movieGroupBox.Controls.Add(this.movieMovieUp);
            this.movieGroupBox.Controls.Add(this.movieFilterButton);
            this.movieGroupBox.Controls.Add(this.movieFilterBox);
            this.movieGroupBox.Location = new System.Drawing.Point(3, 3);
            this.movieGroupBox.Name = "movieGroupBox";
            this.movieGroupBox.Size = new System.Drawing.Size(571, 427);
            this.movieGroupBox.TabIndex = 0;
            this.movieGroupBox.TabStop = false;
            this.movieGroupBox.Text = "Movies";
            // 
            // movieAutoFilter
            // 
            this.movieAutoFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.movieAutoFilter.Location = new System.Drawing.Point(158, 399);
            this.movieAutoFilter.Name = "movieAutoFilter";
            this.movieAutoFilter.Size = new System.Drawing.Size(40, 23);
            this.movieAutoFilter.TabIndex = 22;
            this.movieAutoFilter.Text = "Auto";
            this.movieAutoFilter.UseVisualStyleBackColor = true;
            this.movieAutoFilter.Click += new System.EventHandler(this.movieAutoFilter_Click);
            // 
            // movieAutoSort
            // 
            this.movieAutoSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.movieAutoSort.AutoSize = true;
            this.movieAutoSort.Location = new System.Drawing.Point(250, 403);
            this.movieAutoSort.Name = "movieAutoSort";
            this.movieAutoSort.Size = new System.Drawing.Size(70, 17);
            this.movieAutoSort.TabIndex = 30;
            this.movieAutoSort.Text = "Auto Sort";
            this.movieAutoSort.UseVisualStyleBackColor = true;
            this.movieAutoSort.CheckedChanged += new System.EventHandler(this.movieAutoSort_CheckedChanged);
            // 
            // movieClear
            // 
            this.movieClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.movieClear.Location = new System.Drawing.Point(509, 399);
            this.movieClear.Name = "movieClear";
            this.movieClear.Size = new System.Drawing.Size(23, 23);
            this.movieClear.TabIndex = 43;
            this.movieClear.Text = "X";
            this.movieClear.UseVisualStyleBackColor = true;
            this.movieClear.Click += new System.EventHandler(this.movieClear_Click);
            // 
            // movieListView
            // 
            this.movieListView.AllowDrop = true;
            this.movieListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.movieListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.movieFileName});
            this.movieListView.FullRowSelect = true;
            this.movieListView.GridLines = true;
            this.movieListView.Location = new System.Drawing.Point(6, 19);
            this.movieListView.Name = "movieListView";
            this.movieListView.Size = new System.Drawing.Size(526, 374);
            this.movieListView.TabIndex = 0;
            this.movieListView.UseCompatibleStateImageBehavior = false;
            this.movieListView.View = System.Windows.Forms.View.Details;
            this.movieListView.VirtualMode = true;
            this.movieListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.movieListView_ItemDrag);
            this.movieListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.movieListView_RetrieveVirtualItem);
            this.movieListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.movieListView_DragDrop);
            this.movieListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.movieListView_DragEnter);
            this.movieListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.movieListView_KeyDown);
            this.movieListView.Leave += new System.EventHandler(this.movieListView_Leave);
            // 
            // movieFileName
            // 
            this.movieFileName.Text = "File";
            this.movieFileName.Width = 500;
            // 
            // movieRemoveEntry
            // 
            this.movieRemoveEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.movieRemoveEntry.Location = new System.Drawing.Point(480, 399);
            this.movieRemoveEntry.Name = "movieRemoveEntry";
            this.movieRemoveEntry.Size = new System.Drawing.Size(23, 23);
            this.movieRemoveEntry.TabIndex = 42;
            this.movieRemoveEntry.Text = "-";
            this.movieRemoveEntry.UseVisualStyleBackColor = true;
            this.movieRemoveEntry.Click += new System.EventHandler(this.movieRemoveEntry_Click);
            // 
            // movieMovieBottom
            // 
            this.movieMovieBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.movieMovieBottom.Location = new System.Drawing.Point(538, 209);
            this.movieMovieBottom.Name = "movieMovieBottom";
            this.movieMovieBottom.Size = new System.Drawing.Size(23, 23);
            this.movieMovieBottom.TabIndex = 13;
            this.movieMovieBottom.Text = "B";
            this.movieMovieBottom.UseVisualStyleBackColor = true;
            this.movieMovieBottom.Click += new System.EventHandler(this.movieMovieBottom_Click);
            // 
            // movieAddFolder
            // 
            this.movieAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.movieAddFolder.Location = new System.Drawing.Point(424, 399);
            this.movieAddFolder.Name = "movieAddFolder";
            this.movieAddFolder.Size = new System.Drawing.Size(50, 23);
            this.movieAddFolder.TabIndex = 41;
            this.movieAddFolder.Text = "+Folder";
            this.movieAddFolder.UseVisualStyleBackColor = true;
            this.movieAddFolder.Click += new System.EventHandler(this.movieAddFolder_Click);
            // 
            // movieMovieDown
            // 
            this.movieMovieDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.movieMovieDown.Location = new System.Drawing.Point(538, 180);
            this.movieMovieDown.Name = "movieMovieDown";
            this.movieMovieDown.Size = new System.Drawing.Size(23, 23);
            this.movieMovieDown.TabIndex = 12;
            this.movieMovieDown.Text = "D";
            this.movieMovieDown.UseVisualStyleBackColor = true;
            this.movieMovieDown.Click += new System.EventHandler(this.movieMovieDown_Click);
            // 
            // movieAddFile
            // 
            this.movieAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.movieAddFile.Location = new System.Drawing.Point(367, 399);
            this.movieAddFile.Name = "movieAddFile";
            this.movieAddFile.Size = new System.Drawing.Size(50, 23);
            this.movieAddFile.TabIndex = 40;
            this.movieAddFile.Text = "+File";
            this.movieAddFile.UseVisualStyleBackColor = true;
            this.movieAddFile.Click += new System.EventHandler(this.movieAddFile_Click);
            // 
            // movieMovieTop
            // 
            this.movieMovieTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.movieMovieTop.Location = new System.Drawing.Point(538, 120);
            this.movieMovieTop.Name = "movieMovieTop";
            this.movieMovieTop.Size = new System.Drawing.Size(23, 23);
            this.movieMovieTop.TabIndex = 10;
            this.movieMovieTop.Text = "T";
            this.movieMovieTop.UseVisualStyleBackColor = true;
            this.movieMovieTop.Click += new System.EventHandler(this.movieMovieTop_Click);
            // 
            // movieFileCount
            // 
            this.movieFileCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.movieFileCount.AutoSize = true;
            this.movieFileCount.Location = new System.Drawing.Point(204, 404);
            this.movieFileCount.Name = "movieFileCount";
            this.movieFileCount.Size = new System.Drawing.Size(40, 13);
            this.movieFileCount.TabIndex = 23;
            this.movieFileCount.Text = "0 file(s)";
            // 
            // movieMovieUp
            // 
            this.movieMovieUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.movieMovieUp.Location = new System.Drawing.Point(538, 150);
            this.movieMovieUp.Name = "movieMovieUp";
            this.movieMovieUp.Size = new System.Drawing.Size(23, 23);
            this.movieMovieUp.TabIndex = 11;
            this.movieMovieUp.Text = "U";
            this.movieMovieUp.UseVisualStyleBackColor = true;
            this.movieMovieUp.Click += new System.EventHandler(this.movieMovieUp_Click);
            // 
            // movieFilterButton
            // 
            this.movieFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.movieFilterButton.Location = new System.Drawing.Point(112, 399);
            this.movieFilterButton.Name = "movieFilterButton";
            this.movieFilterButton.Size = new System.Drawing.Size(40, 23);
            this.movieFilterButton.TabIndex = 21;
            this.movieFilterButton.Text = "Filter";
            this.movieFilterButton.UseVisualStyleBackColor = true;
            this.movieFilterButton.Click += new System.EventHandler(this.movieFilterButton_Click);
            // 
            // movieFilterBox
            // 
            this.movieFilterBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.movieFilterBox.Location = new System.Drawing.Point(6, 400);
            this.movieFilterBox.Name = "movieFilterBox";
            this.movieFilterBox.Size = new System.Drawing.Size(100, 20);
            this.movieFilterBox.TabIndex = 20;
            // 
            // subtitleAddFileDialog
            // 
            this.subtitleAddFileDialog.Filter = "Subtitle files|*.ass;*.ssa;*.srt;*.idx;*.sub|All files|*.*";
            this.subtitleAddFileDialog.Multiselect = true;
            // 
            // movieAddFileDialog
            // 
            this.movieAddFileDialog.Filter = "Movie files|*.mkv;*.mp4;*.avi;*.wmv|All files|*.*";
            this.movieAddFileDialog.Multiselect = true;
            // 
            // optionGroupBox
            // 
            this.optionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.optionGroupBox.Controls.Add(this.optionDisplayModeGroupBox);
            this.optionGroupBox.Controls.Add(this.optionMoveToMovieFolder);
            this.optionGroupBox.Controls.Add(this.optionLanguage);
            this.optionGroupBox.Controls.Add(this.optionSpecifyLanguage);
            this.optionGroupBox.Controls.Add(this.renameTemplateLabel);
            this.optionGroupBox.Controls.Add(this.optionSpecifyExtension);
            this.optionGroupBox.Controls.Add(this.renameTemplateTextBox);
            this.optionGroupBox.Controls.Add(this.optionSubtitleGroup);
            this.optionGroupBox.Controls.Add(this.optionExtension);
            this.optionGroupBox.Controls.Add(this.optionSpecifySubtitleGroup);
            this.optionGroupBox.Location = new System.Drawing.Point(19, 457);
            this.optionGroupBox.Name = "optionGroupBox";
            this.optionGroupBox.Size = new System.Drawing.Size(579, 192);
            this.optionGroupBox.TabIndex = 1;
            this.optionGroupBox.TabStop = false;
            this.optionGroupBox.Text = "Options";
            // 
            // optionDisplayModeGroupBox
            // 
            this.optionDisplayModeGroupBox.Controls.Add(this.displayModeDiscrepancyName);
            this.optionDisplayModeGroupBox.Controls.Add(this.displayModeFileName);
            this.optionDisplayModeGroupBox.Controls.Add(this.displayModeFullName);
            this.optionDisplayModeGroupBox.Location = new System.Drawing.Point(291, 147);
            this.optionDisplayModeGroupBox.Name = "optionDisplayModeGroupBox";
            this.optionDisplayModeGroupBox.Size = new System.Drawing.Size(282, 39);
            this.optionDisplayModeGroupBox.TabIndex = 60;
            this.optionDisplayModeGroupBox.TabStop = false;
            this.optionDisplayModeGroupBox.Text = "Display Mode";
            // 
            // displayModeDiscrepancyName
            // 
            this.displayModeDiscrepancyName.AutoSize = true;
            this.displayModeDiscrepancyName.Location = new System.Drawing.Point(163, 18);
            this.displayModeDiscrepancyName.Name = "displayModeDiscrepancyName";
            this.displayModeDiscrepancyName.Size = new System.Drawing.Size(115, 17);
            this.displayModeDiscrepancyName.TabIndex = 2;
            this.displayModeDiscrepancyName.Text = "Discrepancy Name";
            this.displayModeDiscrepancyName.UseVisualStyleBackColor = true;
            this.displayModeDiscrepancyName.CheckedChanged += new System.EventHandler(this.displayModeDiscrepancyName_CheckedChanged);
            // 
            // displayModeFileName
            // 
            this.displayModeFileName.AutoSize = true;
            this.displayModeFileName.Location = new System.Drawing.Point(85, 18);
            this.displayModeFileName.Name = "displayModeFileName";
            this.displayModeFileName.Size = new System.Drawing.Size(72, 17);
            this.displayModeFileName.TabIndex = 1;
            this.displayModeFileName.TabStop = true;
            this.displayModeFileName.Text = "File Name";
            this.displayModeFileName.UseVisualStyleBackColor = true;
            this.displayModeFileName.CheckedChanged += new System.EventHandler(this.displayModeFileName_CheckedChanged);
            // 
            // displayModeFullName
            // 
            this.displayModeFullName.AutoSize = true;
            this.displayModeFullName.Checked = true;
            this.displayModeFullName.Location = new System.Drawing.Point(7, 18);
            this.displayModeFullName.Name = "displayModeFullName";
            this.displayModeFullName.Size = new System.Drawing.Size(72, 17);
            this.displayModeFullName.TabIndex = 0;
            this.displayModeFullName.TabStop = true;
            this.displayModeFullName.Text = "Full Name";
            this.displayModeFullName.UseVisualStyleBackColor = true;
            this.displayModeFullName.CheckedChanged += new System.EventHandler(this.displayModeFullName_CheckedChanged);
            // 
            // optionMoveToMovieFolder
            // 
            this.optionMoveToMovieFolder.AutoSize = true;
            this.optionMoveToMovieFolder.Location = new System.Drawing.Point(21, 160);
            this.optionMoveToMovieFolder.Name = "optionMoveToMovieFolder";
            this.optionMoveToMovieFolder.Size = new System.Drawing.Size(125, 17);
            this.optionMoveToMovieFolder.TabIndex = 50;
            this.optionMoveToMovieFolder.Text = "Move to movie folder";
            this.optionMoveToMovieFolder.UseVisualStyleBackColor = true;
            // 
            // optionLanguage
            // 
            this.optionLanguage.Enabled = false;
            this.optionLanguage.Location = new System.Drawing.Point(154, 77);
            this.optionLanguage.Name = "optionLanguage";
            this.optionLanguage.Size = new System.Drawing.Size(167, 20);
            this.optionLanguage.TabIndex = 31;
            // 
            // optionSpecifyLanguage
            // 
            this.optionSpecifyLanguage.AutoSize = true;
            this.optionSpecifyLanguage.Location = new System.Drawing.Point(21, 79);
            this.optionSpecifyLanguage.Name = "optionSpecifyLanguage";
            this.optionSpecifyLanguage.Size = new System.Drawing.Size(108, 17);
            this.optionSpecifyLanguage.TabIndex = 30;
            this.optionSpecifyLanguage.Text = "Specify language";
            this.optionSpecifyLanguage.UseVisualStyleBackColor = true;
            this.optionSpecifyLanguage.CheckedChanged += new System.EventHandler(this.optionSpecifyLanguage_CheckedChanged);
            // 
            // renameTemplateLabel
            // 
            this.renameTemplateLabel.AutoSize = true;
            this.renameTemplateLabel.Location = new System.Drawing.Point(18, 27);
            this.renameTemplateLabel.Name = "renameTemplateLabel";
            this.renameTemplateLabel.Size = new System.Drawing.Size(51, 13);
            this.renameTemplateLabel.TabIndex = 10;
            this.renameTemplateLabel.Text = "Template";
            // 
            // optionSpecifyExtension
            // 
            this.optionSpecifyExtension.AutoSize = true;
            this.optionSpecifyExtension.Location = new System.Drawing.Point(21, 105);
            this.optionSpecifyExtension.Name = "optionSpecifyExtension";
            this.optionSpecifyExtension.Size = new System.Drawing.Size(109, 17);
            this.optionSpecifyExtension.TabIndex = 40;
            this.optionSpecifyExtension.Text = "Specify extension";
            this.optionSpecifyExtension.UseVisualStyleBackColor = true;
            this.optionSpecifyExtension.CheckedChanged += new System.EventHandler(this.optionSpecifyExtension_CheckedChanged);
            // 
            // renameTemplateTextBox
            // 
            this.renameTemplateTextBox.Location = new System.Drawing.Point(76, 24);
            this.renameTemplateTextBox.Name = "renameTemplateTextBox";
            this.renameTemplateTextBox.Size = new System.Drawing.Size(494, 20);
            this.renameTemplateTextBox.TabIndex = 11;
            this.renameTemplateTextBox.Text = "{MovieFileName}{.?SubtitleGroup}{.?Language}{.Extension}";
            // 
            // optionSubtitleGroup
            // 
            this.optionSubtitleGroup.Enabled = false;
            this.optionSubtitleGroup.Location = new System.Drawing.Point(154, 50);
            this.optionSubtitleGroup.Name = "optionSubtitleGroup";
            this.optionSubtitleGroup.Size = new System.Drawing.Size(167, 20);
            this.optionSubtitleGroup.TabIndex = 21;
            // 
            // optionExtension
            // 
            this.optionExtension.Enabled = false;
            this.optionExtension.Location = new System.Drawing.Point(154, 103);
            this.optionExtension.Name = "optionExtension";
            this.optionExtension.Size = new System.Drawing.Size(167, 20);
            this.optionExtension.TabIndex = 41;
            // 
            // optionSpecifySubtitleGroup
            // 
            this.optionSpecifySubtitleGroup.AutoSize = true;
            this.optionSpecifySubtitleGroup.Location = new System.Drawing.Point(21, 54);
            this.optionSpecifySubtitleGroup.Name = "optionSpecifySubtitleGroup";
            this.optionSpecifySubtitleGroup.Size = new System.Drawing.Size(127, 17);
            this.optionSpecifySubtitleGroup.TabIndex = 20;
            this.optionSpecifySubtitleGroup.Text = "Specify subtitle group";
            this.optionSpecifySubtitleGroup.UseVisualStyleBackColor = true;
            this.optionSpecifySubtitleGroup.CheckedChanged += new System.EventHandler(this.optionSpecifySubtitleGroup_CheckedChanged);
            // 
            // previewButton
            // 
            this.previewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previewButton.Location = new System.Drawing.Point(1016, 626);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(75, 23);
            this.previewButton.TabIndex = 10;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.renameButton.Location = new System.Drawing.Point(1097, 626);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(75, 23);
            this.renameButton.TabIndex = 11;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // deleteAllPanel
            // 
            this.deleteAllPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteAllPanel.BackgroundImage = global::SmartFileRename.Properties.Resources.rubbish_bin;
            this.deleteAllPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deleteAllPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deleteAllPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteAllPanel.Location = new System.Drawing.Point(797, 462);
            this.deleteAllPanel.Name = "deleteAllPanel";
            this.deleteAllPanel.Size = new System.Drawing.Size(187, 187);
            this.deleteAllPanel.TabIndex = 13;
            this.deleteAllPanel.Click += new System.EventHandler(this.deleteAllPanel_Click);
            // 
            // autoDropPanel
            // 
            this.autoDropPanel.AllowDrop = true;
            this.autoDropPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autoDropPanel.BackgroundImage = global::SmartFileRename.Properties.Resources.funnel;
            this.autoDropPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.autoDropPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.autoDropPanel.Location = new System.Drawing.Point(604, 462);
            this.autoDropPanel.Name = "autoDropPanel";
            this.autoDropPanel.Size = new System.Drawing.Size(187, 187);
            this.autoDropPanel.TabIndex = 12;
            this.autoDropPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.autoDropPanel_DragDrop);
            this.autoDropPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.autoDropPanel_DragEnter);
            // 
            // movieSort
            // 
            this.movieSort.Location = new System.Drawing.Point(321, 399);
            this.movieSort.Name = "movieSort";
            this.movieSort.Size = new System.Drawing.Size(40, 23);
            this.movieSort.TabIndex = 31;
            this.movieSort.Text = "Sort";
            this.movieSort.UseVisualStyleBackColor = true;
            this.movieSort.Click += new System.EventHandler(this.movieSort_Click);
            // 
            // subtitleSort
            // 
            this.subtitleSort.Location = new System.Drawing.Point(321, 399);
            this.subtitleSort.Name = "subtitleSort";
            this.subtitleSort.Size = new System.Drawing.Size(40, 23);
            this.subtitleSort.TabIndex = 31;
            this.subtitleSort.Text = "Sort";
            this.subtitleSort.UseVisualStyleBackColor = true;
            this.subtitleSort.Click += new System.EventHandler(this.subtitleSort_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.deleteAllPanel);
            this.Controls.Add(this.autoDropPanel);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.optionGroupBox);
            this.Controls.Add(this.filePanel);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "MainForm";
            this.Text = "Smart File Renamer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.filePanel.ResumeLayout(false);
            this.filePanelSplitter.Panel1.ResumeLayout(false);
            this.filePanelSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filePanelSplitter)).EndInit();
            this.filePanelSplitter.ResumeLayout(false);
            this.subtitleGroupBox.ResumeLayout(false);
            this.subtitleGroupBox.PerformLayout();
            this.movieGroupBox.ResumeLayout(false);
            this.movieGroupBox.PerformLayout();
            this.optionGroupBox.ResumeLayout(false);
            this.optionGroupBox.PerformLayout();
            this.optionDisplayModeGroupBox.ResumeLayout(false);
            this.optionDisplayModeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.SplitContainer filePanelSplitter;
        private System.Windows.Forms.GroupBox subtitleGroupBox;
        private System.Windows.Forms.GroupBox movieGroupBox;
        private System.Windows.Forms.Button subtitleMoveBottom;
        private System.Windows.Forms.Button subtitleMoveDown;
        private System.Windows.Forms.Button subtitleMoveUp;
        private System.Windows.Forms.Button subtitleMoveTop;
        private System.Windows.Forms.Button movieMovieBottom;
        private System.Windows.Forms.Button movieMovieDown;
        private System.Windows.Forms.Button movieMovieTop;
        private System.Windows.Forms.Button movieMovieUp;
        private System.Windows.Forms.CheckBox subtitleAutoSort;
        private System.Windows.Forms.Button subtitleClear;
        private System.Windows.Forms.Button subtitleRemoveEntry;
        private System.Windows.Forms.Button subtitleAddFolder;
        private System.Windows.Forms.Button subtitleAddFile;
        private System.Windows.Forms.Label subtitleFileCount;
        private System.Windows.Forms.Button subtitleFilterButton;
        private System.Windows.Forms.TextBox subtitleFilterBox;
        private System.Windows.Forms.ListView subtitleListView;
        private System.Windows.Forms.CheckBox movieAutoSort;
        private System.Windows.Forms.Button movieClear;
        private System.Windows.Forms.ListView movieListView;
        private System.Windows.Forms.Button movieRemoveEntry;
        private System.Windows.Forms.Button movieAddFolder;
        private System.Windows.Forms.Button movieAddFile;
        private System.Windows.Forms.Label movieFileCount;
        private System.Windows.Forms.Button movieFilterButton;
        private System.Windows.Forms.TextBox movieFilterBox;
        private System.Windows.Forms.OpenFileDialog subtitleAddFileDialog;
        private System.Windows.Forms.OpenFileDialog movieAddFileDialog;
        private System.Windows.Forms.FolderBrowserDialog subtitleAddFolderDialog;
        private System.Windows.Forms.FolderBrowserDialog movieAddFolderDialog;
        private System.Windows.Forms.Button subtitleAutoFilter;
        private System.Windows.Forms.Button movieAutoFilter;
        private System.Windows.Forms.GroupBox optionGroupBox;
        private System.Windows.Forms.CheckBox optionSpecifySubtitleGroup;
        private System.Windows.Forms.TextBox optionExtension;
        private System.Windows.Forms.CheckBox optionSpecifyExtension;
        private System.Windows.Forms.TextBox optionSubtitleGroup;
        private System.Windows.Forms.ColumnHeader subtitleFileName;
        private System.Windows.Forms.ColumnHeader movieFileName;
        private System.Windows.Forms.CheckBox optionMoveToMovieFolder;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.GroupBox optionDisplayModeGroupBox;
        private System.Windows.Forms.RadioButton displayModeDiscrepancyName;
        private System.Windows.Forms.RadioButton displayModeFileName;
        private System.Windows.Forms.RadioButton displayModeFullName;
        private System.Windows.Forms.TextBox renameTemplateTextBox;
        private System.Windows.Forms.Label renameTemplateLabel;
        private System.Windows.Forms.TextBox optionLanguage;
        private System.Windows.Forms.CheckBox optionSpecifyLanguage;
        private System.Windows.Forms.Panel autoDropPanel;
        private System.Windows.Forms.Panel deleteAllPanel;
        private System.Windows.Forms.Button subtitleSort;
        private System.Windows.Forms.Button movieSort;
    }
}

