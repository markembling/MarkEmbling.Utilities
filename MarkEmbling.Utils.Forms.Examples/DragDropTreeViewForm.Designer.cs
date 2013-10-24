namespace MarkEmbling.Utils.Forms.Examples {
    partial class DragDropTreeViewForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DragDropTreeViewForm));
            this.addFolderButton = new System.Windows.Forms.Button();
            this.addLeafButton = new System.Windows.Forms.Button();
            this.removeNodeButton = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.treeView = new MarkEmbling.Utils.Forms.Controls.DragDropTreeView();
            this.SuspendLayout();
            // 
            // addFolderButton
            // 
            this.addFolderButton.Location = new System.Drawing.Point(12, 12);
            this.addFolderButton.Name = "addFolderButton";
            this.addFolderButton.Size = new System.Drawing.Size(75, 23);
            this.addFolderButton.TabIndex = 1;
            this.addFolderButton.Text = "Add Folder";
            this.addFolderButton.UseVisualStyleBackColor = true;
            this.addFolderButton.Click += new System.EventHandler(this.addFolderButton_Click);
            // 
            // addLeafButton
            // 
            this.addLeafButton.Location = new System.Drawing.Point(93, 12);
            this.addLeafButton.Name = "addLeafButton";
            this.addLeafButton.Size = new System.Drawing.Size(75, 23);
            this.addLeafButton.TabIndex = 2;
            this.addLeafButton.Text = "Add Leaf";
            this.addLeafButton.UseVisualStyleBackColor = true;
            this.addLeafButton.Click += new System.EventHandler(this.addLeafButton_Click);
            // 
            // removeNodeButton
            // 
            this.removeNodeButton.Location = new System.Drawing.Point(369, 12);
            this.removeNodeButton.Name = "removeNodeButton";
            this.removeNodeButton.Size = new System.Drawing.Size(111, 23);
            this.removeNodeButton.TabIndex = 3;
            this.removeNodeButton.Text = "Remove Selected";
            this.removeNodeButton.UseVisualStyleBackColor = true;
            this.removeNodeButton.Click += new System.EventHandler(this.removeNodeButton_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.png");
            this.imageList.Images.SetKeyName(1, "tag_green.png");
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(12, 41);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(468, 354);
            this.treeView.TabIndex = 0;
            this.treeView.UseNativeAppearance = true;
            this.treeView.AcceptingDraggedNode += new MarkEmbling.Utils.Forms.Controls.AcceptingDraggedNodeHandler(this.treeView_AcceptingDraggedNode);
            // 
            // DragDropTreeViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 407);
            this.Controls.Add(this.removeNodeButton);
            this.Controls.Add(this.addLeafButton);
            this.Controls.Add(this.addFolderButton);
            this.Controls.Add(this.treeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DragDropTreeViewForm";
            this.Text = "DragDropTreeView";
            this.ResumeLayout(false);

        }

        #endregion

        private MarkEmbling.Utils.Forms.Controls.DragDropTreeView treeView;
        private System.Windows.Forms.Button addFolderButton;
        private System.Windows.Forms.Button addLeafButton;
        private System.Windows.Forms.Button removeNodeButton;
        private System.Windows.Forms.ImageList imageList;
    }
}