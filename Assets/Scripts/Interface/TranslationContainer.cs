using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationContainer : MonoBehaviour {

    private Dictionary<string, Translation> _translations = new Dictionary<string, Translation>();
    private static SystemLanguage _selectedLanguage;

    public void Start()
    {
        _selectedLanguage = Application.systemLanguage;

        _translations["BUTTON_START_GAME"] = new Translation(new Dictionary<SystemLanguage, string>() {
            { SystemLanguage.English, "Start Game" },
            { SystemLanguage.French, "Commencer" }
        });

        _translations["BUTTON_HELP_PANEL"] = new Translation(new Dictionary<SystemLanguage, string>() {
            { SystemLanguage.English, "Help me !" },
            { SystemLanguage.French, "À l'aide !" }
        });
    }

	public string getTranslation(string key)
    {
        if(!_translations.ContainsKey(key))
        {
            Debug.LogError("Unkown translation key " + key);
            return null;
        }

        return _translations[key].GetString(_selectedLanguage);
    }

    public void SwitchLanguage(SystemLanguage newLang)
    {
        _selectedLanguage = newLang;
    }
}
