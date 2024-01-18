using Nulo.Modules.ExtensionManager;

namespace Nulo.Core.Menus {

    [Route("window/workspaces"), Group(20)]
    internal sealed class Window : MenuItem {
        public override Bitmap Icon => Properties.Resources.IconWorkspaces;

        public override string Text => "Ok";

        public override void OnClick(object sender, EventArgs args) {
        }
    }
}