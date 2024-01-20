using Nulo.Modules.ExtensionManager;

namespace Nulo.Core.Menus {

    [Route("home"), Group(10)]
    internal sealed class Home : MenuItem {
    }

    [Route("home/profile"), Group(50)]
    internal sealed class HomeProfile : MenuItem {
    }

    [Route("home/exit"), Group(100)]
    internal sealed class HomeExit : MenuItem {
    }

    [Route("home/settings"), Group(50), ShortcutKeys(Keys.Control | Keys.W)]
    internal sealed class HomeSettings : MenuItem {
    }
}