using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation {

    [SerializeField]
    private Dictionary<SystemLanguage, string> _translatedText = new Dictionary<SystemLanguage, string>();

    public Translation(Dictionary<SystemLanguage, string> translation)
    {
        _translatedText = translation;
    }

    public string GetString(SystemLanguage targetLang)
    {
        if (!_translatedText.ContainsKey(targetLang))
        {
            Debug.LogError("Unkown translation language " + targetLang.ToString());
            return "";
        }

        return  _translatedText[targetLang];
    }
}
