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

    public void UpdateUI()
    {
        playerName.text = GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Name;
        smarts.text = GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Smarts.ToString();
        moxie.text = GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Moxie.ToString();
        muscle.text = GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Strength.ToString();
    }

    public void UpdateFirstAction()
    {

    }

    public void UpdateSecondAction()
    {

    }
}
