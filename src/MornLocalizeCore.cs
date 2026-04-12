using System;
using UniRx;

namespace MornLib
{
    public static class MornLocalizeCore
    {
        private static readonly Subject<string> _languageChangeSubject = new();
        public static IObservable<string> OnLanguageChanged => _languageChangeSubject;
        public static string CurrentLanguage { get; private set; }

        public static void ChangeLanguage(string language)
        {
            CurrentLanguage = language;
            _languageChangeSubject.OnNext(language);
        }
    }
}