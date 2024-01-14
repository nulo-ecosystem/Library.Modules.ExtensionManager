namespace Nulo.Modules.ExtensionManager {

    [AttributeUsage(AttributeTargets.Class)]
    public class MenuItem : Attribute {
        public IMenuItem Instance { get; set; }
    }
}

//public string Route { get; set; } = route;
//public bool IsOnClick { get; private set; } = isOnClick;
//public byte Position { get; private set; } = position;
//public byte SubPosition { get; private set; } = subPosition;