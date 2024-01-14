namespace Nulo.Core.Pages {
    partial class MainPage {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            DockPanel = new Panel();
            MenuStrip = new MenuStrip();
            ToolStrip = new ToolStrip();
            ToolStripWorkspaces = new ToolStripDropDownButton();
            StatusStrip = new StatusStrip();
            TopPanel = new Panel();
            ToolStrip.SuspendLayout();
            TopPanel.SuspendLayout();
            SuspendLayout();
            // 
            // DockPanel
            // 
            DockPanel.Dock = DockStyle.Fill;
            DockPanel.Location = new Point(0, 39);
            DockPanel.Name = "DockPanel";
            DockPanel.Size = new Size(1058, 603);
            DockPanel.TabIndex = 0;
            // 
            // MenuStrip
            // 
            MenuStrip.Dock = DockStyle.Fill;
            MenuStrip.ImageScalingSize = new Size(24, 24);
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(1012, 39);
            MenuStrip.TabIndex = 0;
            // 
            // ToolStrip
            // 
            ToolStrip.Dock = DockStyle.Right;
            ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            ToolStrip.ImageScalingSize = new Size(24, 24);
            ToolStrip.Items.AddRange(new ToolStripItem[] { ToolStripWorkspaces });
            ToolStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            ToolStrip.Location = new Point(1012, 0);
            ToolStrip.Name = "ToolStrip";
            ToolStrip.Size = new Size(46, 39);
            ToolStrip.TabIndex = 0;
            // 
            // ToolStripWorkspaces
            // 
            ToolStripWorkspaces.Alignment = ToolStripItemAlignment.Right;
            ToolStripWorkspaces.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ToolStripWorkspaces.Image = Properties.Resources.IconWorkspaces;
            ToolStripWorkspaces.ImageTransparentColor = Color.Magenta;
            ToolStripWorkspaces.Name = "ToolStripWorkspaces";
            ToolStripWorkspaces.Size = new Size(42, 34);
            // 
            // StatusStrip
            // 
            StatusStrip.ImageScalingSize = new Size(24, 24);
            StatusStrip.Location = new Point(0, 642);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(1058, 22);
            StatusStrip.TabIndex = 0;
            // 
            // TopPanel
            // 
            TopPanel.Controls.Add(MenuStrip);
            TopPanel.Controls.Add(ToolStrip);
            TopPanel.Dock = DockStyle.Top;
            TopPanel.Location = new Point(0, 0);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(1058, 39);
            TopPanel.TabIndex = 0;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 664);
            Controls.Add(DockPanel);
            Controls.Add(TopPanel);
            Controls.Add(StatusStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MenuStrip;
            MinimumSize = new Size(1080, 720);
            Name = "MainPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Extension Manager Forms";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainPage_FormClosing;
            ToolStrip.ResumeLayout(false);
            ToolStrip.PerformLayout();
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel DockPanel;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripDropDownButton ToolStripWorkspaces;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.MenuStrip MenuStrip;
    }
}