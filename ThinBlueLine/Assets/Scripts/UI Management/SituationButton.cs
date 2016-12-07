using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;
using UnityEngine.EventSystems;

// class attached to the button
public class SituationButton : MonoBehaviour {

    // ui gameobjects
    public GameObject button;
    public Text situationName;
    public Text cost;
    public Text smartsMod;
    public Text moxieMod;
    public Text musclesMod;
    public Text posResolution;
    public Text negResolution;
    public Text desc;
    public Text immEffect;
    public Text ongEffect;

    public SituationScript situation;           // pointer to the situation
    public Neighborhood neighborhood;

    void Awake()
    {
        button = gameObject;
    }

    // pulls up the resolve situation menu
    public void ClickSituation()
    {
        if (GameManager.Instance.CurrentPlayerObj.Neighborhood == neighborhood)
        // tell ui manager to spawn a resolve situation panel with this situation;
        UIManager.instance.ResolveSituation(situation);
    }

    public void UpdateCost(float i)
    {
        cost.text = "Cost:           " + (situation.Cost - i).ToString();
        situation.Cost -= i;

        if (situation.Cost <= 0)
        {
            situation.TriggerPositive();
            GameManager.Instance.SituationsCleared++;
            GameLibrary.instance.SituationList.Remove(situation);
            Destroy(gameObject);
        }
    }
}
