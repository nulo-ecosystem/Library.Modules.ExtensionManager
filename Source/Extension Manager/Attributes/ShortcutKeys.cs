namespace Nulo.Modules.ExtensionManager {

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ShortcutKeys(Keys value) : Attribute {
        public Keys Value { get; private set; } = value;
    }
}