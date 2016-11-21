using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentPlayerManager : MonoBehaviour {

    public Text playerName;
    public Text smarts;
    public Text moxie;
    public Text muscle;
    public Text firstAction;
    public Text secondAction;

    bool firstFlag = false;

    public void UpdateUI()
    {
        playerName.text = GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Name;
        smarts.text = GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Smarts.ToString();
        moxie.text = GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Moxie.ToString();
        muscle.text = GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Muscle.ToString();
    }

    public void UpdateActions(string action)
    {
        if (!firstFlag)
        {
            firstAction.text = "1: " + action;
            firstFlag = true;
        }
        else
            secondAction.text = "2: " + action;
    }

    public void WipeActions()
    {
        firstAction.text = "1:";
        secondAction.text = "2:";

        firstFlag = false;
    }
}