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
        overallPC.text = GameManager.Instance.CurrentPC.ToString();
        overallCH.text = GameManager.Instance.CurrentCH.ToString();
        overallMP.text = GameManager.Instance.CurrentMP.ToString();

        stonyGatePC.text = "0";
        stonyGateCH.text = "0";
        stonyGateMP.text = "0";

        suburbiaPC.text = "0";
        suburbiaCH.text = "0";
        suburbiaMP.text = "0";

        downtownPC.text = "0";
        downtownCH.text = "0";
        downtownMP.text = "0";

        boxesPC.text = "0";
        boxesCH.text = "0";
        boxesMP.text = "0";

        portsidePC.text = "0";
        portsideCH.text = "0";
        portsideMP.text = "0";
    }

    #endregion
}