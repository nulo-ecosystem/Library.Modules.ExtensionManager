namespace Nulo.Core.Utilities {

    internal static class DataAssembly {
        private static Assembly assembly;
        private static FileVersionInfo fileVersionInfo;

        private static FileVersionInfo GetInfo() {
            try {
                assembly ??= Assembly.GetExecutingAssembly();
                fileVersionInfo ??= FileVersionInfo.GetVersionInfo(assembly.Location);
                return fileVersionInfo;
            } catch {
                return null;
            }
        }

        public static string GetCopyright() {
            return GetInfo() is FileVersionInfo info ? info.LegalCopyright : string.Empty;
        }

        public static string GetSmallVersion() {
            return GetInfo() is FileVersionInfo info ? $"{info.ProductMajorPart}.{info.ProductMinorPart}" : string.Empty;
        }

        public static string GetProductName() {
            return GetInfo() is FileVersionInfo info ? info.ProductName.Replace(" ®", "®") : string.Empty;
        }
    }
}