using System.Globalization;

namespace Nulo.Modules.MultiLanguageManager {

    internal class LanguageData : ILanguageData {

        private readonly List<string> availableLanguages = [
            "en-US",
            "pt-BR"
        ];

        public string GetLanguage() {
            var language = Properties.Settings.Default.Language;
            if(!string.IsNullOrEmpty(language)) { return language; }

            var systemLanguage = CultureInfo.InstalledUICulture.Name;
            foreach(var availableLanguage in availableLanguages) {
                if(systemLanguage.Equals(availableLanguage)) { return availableLanguage; }
            }

            return availableLanguages[0];
        }

        public void SaveLanguage(string language) {
            Properties.Settings.Default.Language = language;
            Properties.Settings.Default.Save();
        }

        public List<string> GetAvailableLanguages() => availableLanguages;
    }
}