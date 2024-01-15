namespace Nulo.Modules.ExtensionManager {

    [AttributeUsage(AttributeTargets.Class)]
    public class Group(byte value) : Attribute {
        public byte Value { get; private set; } = value;
    }
}