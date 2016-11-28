using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewNeighborhoodCard : MonoBehaviour {

    public Text neighborhoodName;
    public Text corruption;
    public Text mafiaPresence;
    public Text chaos;

    Neighborhood curr;

    public void Initialize(Neighborhood neighborhood)
    {
        neighborhoodName.text = neighborhood.ToString();
        corruption.text = GameLibrary.instance.Neighborhoods[neighborhood].Corruption.ToString();
        chaos.text = GameLibrary.instance.Neighborhoods[neighborhood].Chaos.ToString();
        mafiaPresence.text = GameLibrary.instance.Neighborhoods[neighborhood].MafiaPresence.ToString();

        curr = neighborhood;
    }

    public Neighborhood CurrentNeighborhood
    {
        get { return curr; }
    }
}
