namespace Nulo.Modules.ExtensionManager {

    internal sealed class BinaryHeap<TValue> {
        private readonly List<Tuple<byte, TValue>> values = [];

        public void Insert(byte key, TValue value) {
            values.Add(new Tuple<byte, TValue>(key, value));
            int index = values.Count - 1;
            while(index > 0 && values[(index - 1) / 2].Item1 > values[index].Item1) {
                Swap(index, (index - 1) / 2);
                index = (index - 1) / 2;
            }
        }

        public TValue Next() {
            if(values.Count != 0) {
                var item = values[0];
                values.RemoveAt(0);
                Heapify(values, values.Count - 1);
                return item.Item2;
            } else {
                return default;
            }
        }

        public TValue Exists(byte key) {
            if(values.FirstOrDefault(a => a.Item1 == key) is Tuple<byte, TValue> value) {
                return value.Item2;
            } else {
                return default;
            }
        }

        public List<Tuple<byte, TValue>> GetList() {
            return values;
        }

        private void Swap(int i, int j) {
            (values[j], values[i]) = (values[i], values[j]);
        }

        private static void Heapify(List<Tuple<byte, TValue>> items, int n, int i = 0) {
            int smallest = i, left = 2 * i + 1, right = 2 * i + 2;
            if(left < n && items[left].Item1 < items[smallest].Item1) { smallest = left; }
            if(right < n && items[right].Item1 < items[smallest].Item1) { smallest = right; }
            if(smallest != i) {
                (items[smallest], items[i]) = (items[i], items[smallest]);
                Heapify(items, n, smallest);
            }
        }
    }
}