using Nulo.Core.Utilities;

namespace Nulo.Core.Pages {

    public partial class SplashScreen : Form {

        public SplashScreen() => InitializeComponent();

        private void SplashScreen_Load(object sender, EventArgs e) {
            NameLabel.Text = DataAssembly.GetProductName();
            VersionLabel.Text = DataAssembly.GetSmallVersion();
            CopyrighLabel.Text = DataAssembly.GetCopyright();
        }

        public void SetStatusLabel(string message) {
            StatusLabel.Text = message;
            Application.DoEvents();
        }
    }
}