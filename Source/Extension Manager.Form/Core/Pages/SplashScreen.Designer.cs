namespace Nulo.Core.Pages {
    partial class SplashScreen {
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
            SplashImage = new PictureBox();
            ContentPanel = new TableLayoutPanel();
            CopyrighLabel = new Label();
            VersionLabel = new Label();
            StatusLabel = new Label();
            ApplicationPanel = new Panel();
            NameLabel = new Label();
            LogoPanel = new Panel();
            LogoImage = new PictureBox();
            SmallBarPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)SplashImage).BeginInit();
            ContentPanel.SuspendLayout();
            ApplicationPanel.SuspendLayout();
            LogoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoImage).BeginInit();
            SuspendLayout();
            // 
            // SplashImage
            // 
            SplashImage.BackColor = SystemColors.WindowFrame;
            SplashImage.Dock = DockStyle.Fill;
            SplashImage.Location = new Point(0, 0);
            SplashImage.Name = "SplashImage";
            SplashImage.Size = new Size(1080, 518);
            SplashImage.SizeMode = PictureBoxSizeMode.CenterImage;
            SplashImage.TabIndex = 0;
            SplashImage.TabStop = false;
            // 
            // ContentPanel
            // 
            ContentPanel.ColumnCount = 2;
            ContentPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            ContentPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            ContentPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            ContentPanel.Controls.Add(CopyrighLabel, 0, 1);
            ContentPanel.Controls.Add(VersionLabel, 1, 1);
            ContentPanel.Controls.Add(StatusLabel, 1, 0);
            ContentPanel.Controls.Add(ApplicationPanel, 0, 0);
            ContentPanel.Dock = DockStyle.Bottom;
            ContentPanel.Location = new Point(0, 525);
            ContentPanel.Name = "ContentPanel";
            ContentPanel.Padding = new Padding(0, 0, 0, 10);
            ContentPanel.RowCount = 2;
            ContentPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ContentPanel.RowStyles.Add(new RowStyle());
            ContentPanel.Size = new Size(1080, 195);
            ContentPanel.TabIndex = 1;
            // 
            // CopyrighLabel
            // 
            CopyrighLabel.AutoSize = true;
            CopyrighLabel.Dock = DockStyle.Fill;
            CopyrighLabel.ForeColor = SystemColors.GrayText;
            CopyrighLabel.Location = new Point(3, 137);
            CopyrighLabel.Name = "CopyrighLabel";
            CopyrighLabel.Padding = new Padding(25, 0, 0, 0);
            CopyrighLabel.Size = new Size(750, 48);
            CopyrighLabel.TabIndex = 0;
            CopyrighLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.Dock = DockStyle.Fill;
            VersionLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            VersionLabel.ForeColor = Color.White;
            VersionLabel.Location = new Point(759, 137);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Padding = new Padding(0, 0, 20, 10);
            VersionLabel.Size = new Size(318, 48);
            VersionLabel.TabIndex = 1;
            VersionLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // StatusLabel
            // 
            StatusLabel.Dock = DockStyle.Fill;
            StatusLabel.ForeColor = SystemColors.GrayText;
            StatusLabel.Location = new Point(759, 0);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Padding = new Padding(0, 8, 24, 0);
            StatusLabel.Size = new Size(318, 137);
            StatusLabel.TabIndex = 2;
            // 
            // ApplicationPanel
            // 
            ApplicationPanel.Controls.Add(NameLabel);
            ApplicationPanel.Controls.Add(LogoPanel);
            ApplicationPanel.Dock = DockStyle.Fill;
            ApplicationPanel.Location = new Point(3, 3);
            ApplicationPanel.Name = "ApplicationPanel";
            ApplicationPanel.Size = new Size(750, 131);
            ApplicationPanel.TabIndex = 3;
            // 
            // NameLabel
            // 
            NameLabel.Dock = DockStyle.Fill;
            NameLabel.Font = new Font("Yu Gothic Medium", 18F, FontStyle.Bold);
            NameLabel.ForeColor = Color.White;
            NameLabel.Location = new Point(120, 0);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(630, 131);
            NameLabel.TabIndex = 1;
            NameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LogoPanel
            // 
            LogoPanel.Controls.Add(LogoImage);
            LogoPanel.Dock = DockStyle.Left;
            LogoPanel.Location = new Point(0, 0);
            LogoPanel.Name = "LogoPanel";
            LogoPanel.Padding = new Padding(10, 20, 0, 20);
            LogoPanel.Size = new Size(120, 131);
            LogoPanel.TabIndex = 2;
            // 
            // LogoImage
            // 
            LogoImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogoImage.Image = Properties.Resources.Icon;
            LogoImage.Location = new Point(13, 23);
            LogoImage.Name = "LogoImage";
            LogoImage.Size = new Size(107, 85);
            LogoImage.SizeMode = PictureBoxSizeMode.Zoom;
            LogoImage.TabIndex = 0;
            LogoImage.TabStop = false;
            // 
            // SmallBarPanel
            // 
            SmallBarPanel.BackColor = Color.FromArgb(0, 156, 180);
            SmallBarPanel.Dock = DockStyle.Bottom;
            SmallBarPanel.Location = new Point(0, 518);
            SmallBarPanel.Name = "SmallBarPanel";
            SmallBarPanel.Size = new Size(1080, 7);
            SmallBarPanel.TabIndex = 2;
            // 
            // SplashScreen
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoValidate = AutoValidate.Disable;
            BackColor = Color.Black;
            ClientSize = new Size(1080, 720);
            ControlBox = false;
            Controls.Add(SplashImage);
            Controls.Add(SmallBarPanel);
            Controls.Add(ContentPanel);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "SplashScreen";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Load += SplashScreen_Load;
            ((System.ComponentModel.ISupportInitialize)SplashImage).EndInit();
            ContentPanel.ResumeLayout(false);
            ContentPanel.PerformLayout();
            ApplicationPanel.ResumeLayout(false);
            LogoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogoImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox SplashImage;
        private TableLayoutPanel ContentPanel;
        private Panel SmallBarPanel;
        private Panel ApplicationPanel;
        private Label NameLabel;
        private PictureBox LogoImage;
        private Label CopyrighLabel;
        private Label VersionLabel;
        private Panel LogoPanel;
        private Label StatusLabel;
    }
}