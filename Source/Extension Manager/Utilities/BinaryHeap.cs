namespace Nulo.Modules.ExtensionManager {

    internal sealed class BinaryHeap<T> {
        private readonly Func<T, T, int> priorityCriteria;
        private readonly T[] data;
        private int cursor;

        public BinaryHeap(int maxCapacity, Func<T, T, int> priorityCriteria) {
            this.priorityCriteria = priorityCriteria;
            data = new T[maxCapacity];
            cursor = 0;
        }
    }
}