namespace Nulo.Modules.ExtensionManager {

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class Location(byte value) : Attribute {
        public byte Value { get; private set; } = value;
    }
}