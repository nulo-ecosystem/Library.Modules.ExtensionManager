namespace Nulo.Modules.ExtensionManager {

    public abstract class MenuItem {

        #region Properties

        public virtual string Text { get; }

        public virtual Bitmap Icon { get; }

        #endregion Properties

        #region Methods

        public virtual void OnClick(object sender, EventArgs args) {
        }

        #endregion Methods
    }
}