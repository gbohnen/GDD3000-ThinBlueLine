using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChiefsOrdersManager : MonoBehaviour {

    public Text body;

    public void Load(List<string> dialogue)
    {
        string text = "";

        foreach (string str in dialogue)
        {
            text += str;
            text += "\\n";
        }

        body.text = text;
    }
}
