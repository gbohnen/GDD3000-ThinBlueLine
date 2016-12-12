using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets.Scripts;

public class NeighborhoodManager : MonoBehaviour {

    public Animator indicator1;
    public Animator indicator2;
    public Animator indicator3;
    public Animator indicator4;

    Dictionary<Players, Animator> animators;

    public static NeighborhoodManager instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        animators = new Dictionary<Players, Animator>();
        animators.Add(Players.Player1, indicator1);
        animators.Add(Players.Player2, indicator2);
        animators.Add(Players.Player3, indicator3);
        animators.Add(Players.Player4, indicator4);
    }

    public void ChangeNeighborhood(Neighborhood curr)
    {
        if (GameManager.Instance.CurrentPlayerObj.Neighborhood != curr)
        {
            GameManager.Instance.CurrentPlayerObj.Neighborhood = curr;
            GameManager.Instance.LogAction("Neighborhood Changed");
            StatTracker.TimesChangedNeighborhood(1);
            animators[GameManager.Instance.CurrentPlayer].SetInteger("CurrNeigh", (int)curr + 1);
        }
    }

	public void ChangeStonyGate()
    {
        if (GameManager.Instance.CurrentPlayerObj.Neighborhood != Neighborhood.StonyGate)
        {
            GameManager.Instance.CurrentPlayerObj.Neighborhood = Neighborhood.StonyGate;
            GameManager.Instance.LogAction("Neighborhood Changed");
            StatTracker.TimesChangedNeighborhood(1);
            animators[GameManager.Instance.CurrentPlayer].SetInteger("CurrNeigh", 1);
        }
    }
    public void ChangeSuburbia()
    {
        if (GameManager.Instance.CurrentPlayerObj.Neighborhood != Neighborhood.Suburbia)
        {
            GameManager.Instance.CurrentPlayerObj.Neighborhood = Neighborhood.Suburbia;
            GameManager.Instance.LogAction("Neighborhood Changed");
            StatTracker.TimesChangedNeighborhood(1);
            animators[GameManager.Instance.CurrentPlayer].SetInteger("CurrNeigh", 2);
        }
    }
    public void ChangeDowntown()
    {
        if (GameManager.Instance.CurrentPlayerObj.Neighborhood != Neighborhood.Downtown)
        {
            GameManager.Instance.CurrentPlayerObj.Neighborhood = Neighborhood.Downtown;
            GameManager.Instance.LogAction("Neighborhood Changed");
            StatTracker.TimesChangedNeighborhood(1);
            animators[GameManager.Instance.CurrentPlayer].SetInteger("CurrNeigh", 3);
        }
    }
    public void ChangeBoxes()
    {
        if (GameManager.Instance.CurrentPlayerObj.Neighborhood != Neighborhood.TheBoxes)
        {
            GameManager.Instance.CurrentPlayerObj.Neighborhood = Neighborhood.TheBoxes;
            GameManager.Instance.LogAction("Neighborhood Changed");
            StatTracker.TimesChangedNeighborhood(1);
            animators[GameManager.Instance.CurrentPlayer].SetInteger("CurrNeigh", 4);
        }
    }
    public void ChangeDocks()
    {
        if (GameManager.Instance.CurrentPlayerObj.Neighborhood != Neighborhood.Portside)
        {
            GameManager.Instance.CurrentPlayerObj.Neighborhood = Neighborhood.Portside;
            GameManager.Instance.LogAction("Neighborhood Changed");
            StatTracker.TimesChangedNeighborhood(1);
            animators[GameManager.Instance.CurrentPlayer].SetInteger("CurrNeigh", 5);
        }
    }
}
