using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;
using UnityEngine.SceneManagement;

/// <summary>
/// Script which handles the City Info UI
/// </summary>
public class CityInfoManager : MonoBehaviour
{
    #region Fields

    // City Info UI Fields
    public Text overallPC;
    public Text overallCH;
    public Text overallMP;

    public Text stonyGatePC;
    public Text stonyGateCH;
    public Text stonyGateMP;

    public Text suburbiaPC;
    public Text suburbiaCH;
    public Text suburbiaMP;

    public Text downtownPC;
    public Text downtownCH;
    public Text downtownMP;

    public Text boxesPC;
    public Text boxesCH;
    public Text boxesMP;

    public Text portsidePC;
    public Text portsideCH;
    public Text portsideMP;

    #endregion

    #region Public Methods
    
    /// <summary>
    /// Updates the city info UI
    /// </summary>

    public void UpdateUI()
    {
        // overall
		overallPC.text = GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Corruption.ToString();
		overallCH.text = GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Chaos.ToString();
		overallMP.text = GameLibrary.instance.Neighborhoods[Neighborhood.Overall].MafiaPresence.ToString();

        // stony gate
		stonyGatePC.text = GameLibrary.instance.Neighborhoods[Neighborhood.StonyGate].Corruption.ToString();
		stonyGateCH.text = GameLibrary.instance.Neighborhoods[Neighborhood.StonyGate].Chaos.ToString();
		stonyGateMP.text = GameLibrary.instance.Neighborhoods[Neighborhood.StonyGate].MafiaPresence.ToString();

        // suburbia
		suburbiaPC.text = GameLibrary.instance.Neighborhoods[Neighborhood.Suburbia].Corruption.ToString();
		suburbiaCH.text = GameLibrary.instance.Neighborhoods[Neighborhood.Suburbia].Chaos.ToString();
		suburbiaMP.text = GameLibrary.instance.Neighborhoods[Neighborhood.Suburbia].MafiaPresence.ToString();

        // downtown
		downtownPC.text = GameLibrary.instance.Neighborhoods[Neighborhood.Downtown].Corruption.ToString();
		downtownCH.text = GameLibrary.instance.Neighborhoods[Neighborhood.Downtown].Chaos.ToString();
		downtownMP.text = GameLibrary.instance.Neighborhoods[Neighborhood.Downtown].MafiaPresence.ToString();

        // the boxes
		boxesPC.text = GameLibrary.instance.Neighborhoods[Neighborhood.TheBoxes].Corruption.ToString();
		boxesCH.text = GameLibrary.instance.Neighborhoods[Neighborhood.TheBoxes].Chaos.ToString();
		boxesMP.text = GameLibrary.instance.Neighborhoods[Neighborhood.TheBoxes].MafiaPresence.ToString();

        // portside
		portsidePC.text = GameLibrary.instance.Neighborhoods[Neighborhood.Portside].Corruption.ToString();
		portsideCH.text = GameLibrary.instance.Neighborhoods[Neighborhood.Portside].Chaos.ToString();
		portsideMP.text = GameLibrary.instance.Neighborhoods[Neighborhood.Portside].MafiaPresence.ToString();
    }

    public void CheckStats()
    {
        // check portside stats
        if (GameLibrary.instance.Neighborhoods[Neighborhood.Portside].Corruption >= Constants.MAX_NEIGHBORHOOD_POLICE_CORR || 
            GameLibrary.instance.Neighborhoods[Neighborhood.Portside].Chaos >= Constants.MAX_NEIGHBORHOOD_CHAOS || 
            GameLibrary.instance.Neighborhoods[Neighborhood.Portside].MafiaPresence >= Constants.MAX_NEIGHBORHOOD_MAFIA_PRES)
        {
            // TODO: Add stats to overall
        }

        // check stony gate stats
        if (GameLibrary.instance.Neighborhoods[Neighborhood.StonyGate].Corruption >= Constants.MAX_NEIGHBORHOOD_POLICE_CORR ||
            GameLibrary.instance.Neighborhoods[Neighborhood.StonyGate].Chaos >= Constants.MAX_NEIGHBORHOOD_MAFIA_PRES ||
            GameLibrary.instance.Neighborhoods[Neighborhood.StonyGate].MafiaPresence >= Constants.MAX_NEIGHBORHOOD_MAFIA_PRES)
        {
            // TODO: Add stats to overall
        }

        // get suburbia stats
        if (GameLibrary.instance.Neighborhoods[Neighborhood.Suburbia].Corruption >= Constants.MAX_NEIGHBORHOOD_POLICE_CORR ||
            GameLibrary.instance.Neighborhoods[Neighborhood.Suburbia].Chaos >= Constants.MAX_NEIGHBORHOOD_CHAOS ||
            GameLibrary.instance.Neighborhoods[Neighborhood.Suburbia].MafiaPresence >= Constants.MAX_NEIGHBORHOOD_MAFIA_PRES)
        {
            // TODO: Add stats to overall
        }

        // check downtown stats
        if (GameLibrary.instance.Neighborhoods[Neighborhood.Downtown].Corruption >= Constants.MAX_NEIGHBORHOOD_POLICE_CORR ||
            GameLibrary.instance.Neighborhoods[Neighborhood.Downtown].Chaos >= Constants.MAX_NEIGHBORHOOD_CHAOS ||
            GameLibrary.instance.Neighborhoods[Neighborhood.Downtown].MafiaPresence >= Constants.MAX_NEIGHBORHOOD_MAFIA_PRES)
        {
            // TODO: Add stats to overall
        }

        // check the boxes stats
        if (GameLibrary.instance.Neighborhoods[Neighborhood.TheBoxes].Corruption >= Constants.MAX_NEIGHBORHOOD_POLICE_CORR ||
            GameLibrary.instance.Neighborhoods[Neighborhood.TheBoxes].Chaos >= Constants.MAX_NEIGHBORHOOD_CHAOS ||
            GameLibrary.instance.Neighborhoods[Neighborhood.TheBoxes].MafiaPresence >= Constants.MAX_NEIGHBORHOOD_MAFIA_PRES)
        {
            // TODO: Add stats to overall
        }
        // check for the overall stats above 10
        if (GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Corruption >= Constants.MAX_CITY_POLICE_CORR &&
            GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Chaos >= Constants.MAX_CITY_CHAOS &&
            GameLibrary.instance.Neighborhoods[Neighborhood.Overall].MafiaPresence >= Constants.MAX_CITY_MAFIA_PRES)
        { SceneManager.LoadScene(Constants.GAME_OVER_SCENE); }
    }

    #endregion
}