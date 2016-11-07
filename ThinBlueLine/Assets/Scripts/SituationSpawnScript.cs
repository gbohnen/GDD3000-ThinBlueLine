using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

/// <summary>
/// Handles the situations
/// </summary>
public class SituationSpawnScript : MonoBehaviour
{
    #region Fields

    // store the prefab object
    public GameObject situationCardPrefab;

    // store the situations information
    public Text situationName;
    public Text cost;
    //public Text smartsCost;
    //public Text moxieCost;
    //public Text strengthCost;
    public Text description;

    // store the demo situation
    SituationScript demoSitch;

    #endregion

    #region Public Methods

    // Use this for initilization
    void Start()
    {
        demoSitch = new SituationScript(LoadGameData.LoadSituations()[0]);
        UpdateFields();
    }

    /// <summary>
    /// Updates the information for the situation card
    /// </summary>
    public void UpdateFields()
    {
        situationName.text = demoSitch.Name;
        cost.text = demoSitch.Cost.ToString();
        description.text = demoSitch.Description;
    }

    /// <summary>
    /// Closes the window
    /// </summary>
    public void Close()
    { Destroy(this); }

    #endregion
}