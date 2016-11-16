using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
		overallPC.text = GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Corruption.ToString();
		overallCH.text = GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Chaos.ToString();
		overallMP.text = GameLibrary.instance.Neighborhoods[Neighborhood.Overall].MafiaPresence.ToString();

		stonyGatePC.text = GameLibrary.instance.Neighborhoods[Neighborhood.StonyGate].Corruption.ToString();
		stonyGateCH.text = GameLibrary.instance.Neighborhoods[Neighborhood.StonyGate].Chaos.ToString();
		stonyGateMP.text = GameLibrary.instance.Neighborhoods[Neighborhood.StonyGate].MafiaPresence.ToString();

		suburbiaPC.text = GameLibrary.instance.Neighborhoods[Neighborhood.Suburbia].Corruption.ToString();
		suburbiaCH.text = GameLibrary.instance.Neighborhoods[Neighborhood.Suburbia].Chaos.ToString();
		suburbiaMP.text = GameLibrary.instance.Neighborhoods[Neighborhood.Suburbia].MafiaPresence.ToString();

		downtownPC.text = GameLibrary.instance.Neighborhoods[Neighborhood.Downtown].Corruption.ToString();
		downtownCH.text = GameLibrary.instance.Neighborhoods[Neighborhood.Downtown].Chaos.ToString();
		downtownMP.text = GameLibrary.instance.Neighborhoods[Neighborhood.Downtown].MafiaPresence.ToString();

		boxesPC.text = GameLibrary.instance.Neighborhoods[Neighborhood.TheBoxes].Corruption.ToString();
		boxesCH.text = GameLibrary.instance.Neighborhoods[Neighborhood.TheBoxes].Chaos.ToString();
		boxesMP.text = GameLibrary.instance.Neighborhoods[Neighborhood.TheBoxes].MafiaPresence.ToString();

		portsidePC.text = GameLibrary.instance.Neighborhoods[Neighborhood.TheDocks].Corruption.ToString();
		portsideCH.text = GameLibrary.instance.Neighborhoods[Neighborhood.TheDocks].Chaos.ToString();
		portsideMP.text = GameLibrary.instance.Neighborhoods[Neighborhood.TheDocks].MafiaPresence.ToString();
    }

    #endregion
}