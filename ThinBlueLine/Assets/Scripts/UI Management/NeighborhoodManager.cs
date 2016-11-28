using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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

	public void ChangeStonyGate()
    {
        GameManager.Instance.activeNeighborhood = Neighborhood.StonyGate;
        GameManager.Instance.LogAction("Neighborhood Changed");
        animators[GameManager.Instance.CurrentPlayer].SetInteger("CurrNeigh", 1);
    }
    public void ChangeSuburbia()
    {
        GameManager.Instance.activeNeighborhood = Neighborhood.Suburbia;
        GameManager.Instance.LogAction("Neighborhood Changed");
        animators[GameManager.Instance.CurrentPlayer].SetInteger("CurrNeigh", 2);
    }
    public void ChangeDowntown()
    {
        GameManager.Instance.activeNeighborhood = Neighborhood.Downtown;
        GameManager.Instance.LogAction("Neighborhood Changed");
        animators[GameManager.Instance.CurrentPlayer].SetInteger("CurrNeigh", 3);
    }
    public void ChangeBoxes()
    {
        GameManager.Instance.activeNeighborhood = Neighborhood.TheBoxes;
        GameManager.Instance.LogAction("Neighborhood Changed");
        animators[GameManager.Instance.CurrentPlayer].SetInteger("CurrNeigh", 4);
    }
    public void ChangeDocks()
    {
        GameManager.Instance.activeNeighborhood = Neighborhood.Portside;
        GameManager.Instance.LogAction("Neighborhood Changed");
        animators[GameManager.Instance.CurrentPlayer].SetInteger("CurrNeigh", 5);
    }
}
