using System.Collections.Generic;

namespace LocalizationTool
{
    public class LocalizationSystem
    {
       public enum Language
       {
           Ukrainian,
           English
       }
       
       private static Language CurrentLanguage = Language.Ukrainian;
       
       private static Dictionary<string, string> _localizedUA;
       private static Dictionary<string, string> _localizedEN;
       
       public static bool _isInitialized = false;

       public static void Initialize()
       {
           CSVLoader loader = new CSVLoader();
           loader.LoadCsv();

           _localizedEN = loader.GetDictionaryValues("en");
           _localizedUA = loader.GetDictionaryValues("ua");
           
           _isInitialized = true;
       }

       public static void SwitchLanguage(Language language)
       {
           CurrentLanguage  = language;
       }

       public static string GetLocalizedString(string key)
       {
           if (!_isInitialized)
               Initialize();

           var value = key;
           
           switch (CurrentLanguage)
           {
               case Language.English:
                   _localizedEN.TryGetValue(key, out value);
                   break;
               case Language.Ukrainian:
                   _localizedUA.TryGetValue(key, out value);
                   break;
           }
           return value;
       }
    }
}
