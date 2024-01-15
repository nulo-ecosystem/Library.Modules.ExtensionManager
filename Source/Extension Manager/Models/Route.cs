namespace Nulo.Modules.ExtensionManager {

    [AttributeUsage(AttributeTargets.Class)]
    public class Route(string value) : Attribute {
        public string Value { get; private set; } = value.Trim().ToLower();
    }
}