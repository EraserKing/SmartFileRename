namespace SmartFileRename
{
    partial class ResultForm
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
            this.previewListView = new System.Windows.Forms.ListView();
            this.originalFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.finalFinal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonClose = new System.Windows.Forms.Button();
            this.showFileNameOnly = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // previewListView
            // 
            this.previewListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.originalFile,
            this.finalFinal});
            this.previewListView.HideSelection = false;
            this.previewListView.Location = new System.Drawing.Point(12, 12);
            this.previewListView.Name = "previewListView";
            this.previewListView.Size = new System.Drawing.Size(810, 408);
            this.previewListView.TabIndex = 0;
            this.previewListView.UseCompatibleStateImageBehavior = false;
            this.previewListView.View = System.Windows.Forms.View.Details;
            // 
            // originalFile
            // 
            this.originalFile.Text = "Before rename";
            this.originalFile.Width = 400;
            // 
            // finalFinal
            // 
            this.finalFinal.Text = "After rename";
            this.finalFinal.Width = 400;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(747, 426);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // showFileNameOnly
            // 
            this.showFileNameOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showFileNameOnly.AutoSize = true;
            this.showFileNameOnly.Location = new System.Drawing.Point(12, 432);
            this.showFileNameOnly.Name = "showFileNameOnly";
            this.showFileNameOnly.Size = new System.Drawing.Size(120, 17);
            this.showFileNameOnly.TabIndex = 1;
            this.showFileNameOnly.Text = "Show file name only";
            this.showFileNameOnly.UseVisualStyleBackColor = true;
            this.showFileNameOnly.CheckedChanged += new System.EventHandler(this.showFileNameOnly_CheckedChanged);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.showFileNameOnly);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.previewListView);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "ResultForm";
            this.Text = "Preview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView previewListView;
        private System.Windows.Forms.ColumnHeader originalFile;
        private System.Windows.Forms.ColumnHeader finalFinal;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.CheckBox showFileNameOnly;
    }
}