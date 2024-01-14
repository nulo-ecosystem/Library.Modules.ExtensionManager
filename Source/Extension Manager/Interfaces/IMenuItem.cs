namespace Nulo.Modules.ExtensionManager {

    public interface IMenuItem {

        string Text { get; }

        Bitmap Icon { get; }

        void OnClick(object sender, EventArgs e);
    }
}