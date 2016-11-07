using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class SituAlloUIScript : MonoBehaviour
{
    #region Fields

    // player stats
    public Text currPlayerSmarts;
    public Text currPlayerMoxie;
    public Text currPlayerStrength;
    public Text newPlayerSmarts;
    public Text newPlayerMoxie;
    public Text newPlayerStrength;

    // situation stats
    public Text currSitSmarts;
    public Text currSitMoxie;
    public Text currSitStrength;
    public Text changeSmarts;
    public Text changeMoxie;
    public Text changeStrength;
    public Text newSitSmarts;
    public Text newSitMoxie;
    public Text newSitStrength;

    // store the current situation
    SituationScript currentSituation;

    #endregion

    /// <summary>
    /// Updates the Situation Allocation UI
    /// </summary>
    public void UpdateSituationUI()
    {
        // players current stats
        currPlayerSmarts.text = GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Smarts.ToString();
        currPlayerMoxie.text = GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Moxie.ToString();
        currPlayerStrength.text = GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Strength.ToString();

        // TODO: players new stats

        // TODO: change stats

        // TODO: situations new stats
    }

    // Use this for initialization
    void Start()
    {
        UpdateSituationUI();
    }

    // Update is called once per frame
    void Update()
    {

    }
}