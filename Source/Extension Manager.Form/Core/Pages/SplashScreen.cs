namespace Nulo.Core.Pages {

    internal partial class SplashScreen : Form {

        public SplashScreen() => InitializeComponent();

        private void SplashScreen_Load(object sender, EventArgs e) {
            NameLabel.Text = GetProductName();
            VersionLabel.Text = GetSmallVersion();
            CopyrighLabel.Text = GetCopyright();
        }

        public void SetStatusLabel(string message) {
            StatusLabel.Text = message;
            Application.DoEvents();
        }

        #region Private Methods

        private FileVersionInfo fileVersionInfo;

        private FileVersionInfo GetInfo() {
            try {
                fileVersionInfo ??= FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
                return fileVersionInfo;
            } catch {
                return null;
            }
        }

        private string GetCopyright() {
            return GetInfo() is FileVersionInfo info ? info.LegalCopyright : string.Empty;
        }

        private string GetSmallVersion() {
            return GetInfo() is FileVersionInfo info ? $"{info.ProductMajorPart}.{info.ProductMinorPart}" : string.Empty;
        }

        public string GetProductName() {
            return GetInfo() is FileVersionInfo info ? info.ProductName.Replace(" ®", "®") : string.Empty;
        }

        #endregion Private Methods
    }
}