using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NeighborhoodManager : MonoBehaviour {

    public Animator indicator;

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
    }

	public void ChangeStonyGate()
    {
        GameManager.Instance.activeNeighborhood = Neighborhood.StonyGate;
        GameManager.Instance.LogAction("Neighborhood Changed");
        indicator.SetInteger("CurrNeigh", 1);
    }
    public void ChangeSuburbia()
    {
        GameManager.Instance.activeNeighborhood = Neighborhood.Suburbia;
        GameManager.Instance.LogAction("Neighborhood Changed");
        indicator.SetInteger("CurrNeigh", 2);
    }
    public void ChangeDowntown()
    {
        GameManager.Instance.activeNeighborhood = Neighborhood.Downtown;
        GameManager.Instance.LogAction("Neighborhood Changed");
        indicator.SetInteger("CurrNeigh", 3);
    }
    public void ChangeBoxes()
    {
        GameManager.Instance.activeNeighborhood = Neighborhood.TheBoxes;
        GameManager.Instance.LogAction("Neighborhood Changed");
        indicator.SetInteger("CurrNeigh", 4);
    }
    public void ChangeDocks()
    {
        GameManager.Instance.activeNeighborhood = Neighborhood.TheDocks;
        GameManager.Instance.LogAction("Neighborhood Changed");
        indicator.SetInteger("CurrNeigh", 5);
    }
}
