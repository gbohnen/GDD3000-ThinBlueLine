using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Managers;
using Assets.Scripts;
using System.Collections.Generic;

/// <summary>
/// Singleton class which manages the state of the game
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Fields    

    // store an Instance of the game manager
    public static GameManager Instance;

    // store the players
    Players currentPlayer;

    // store the crimes & situations
    MajorCrimeScript majorCrime;
    List<SituationScript> situations;

    // store the mob boss & police chief
    MobBossScript mobBoss;
    PoliceChiefScript policeChief;

    #region UI

    // player UI fields
    public Text playerWName;
    public Text playerWSma;
    public Text playerWMox;
    public Text playerWMus;

    public Text playerXName;
    public Text playerXSma;
    public Text playerXMox;
    public Text playerXMus;

    public Text playerYName;
    public Text playerYSma;
    public Text playerYMox;
    public Text playerYMus;

    public Text playerZName;
    public Text playerZSma;
    public Text playerZMox;
    public Text playerZMus;

    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets the current player
    /// </summary>
    public Players CurrentPlayer
    { get { return currentPlayer; } }

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets or sets the audio manager
    /// </summary>
    public AudioManager Audio
    { get; private set; }

    // Use this for initialization
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        currentPlayer = Players.Player1;

        UIManager.instance.AddSituation(GameLibrary.instance.SituationList[3]);
        UIManager.instance.UpdateUI();
    }

    /// <summary>
    /// Updates the UI
    /// </summary>
    public void UpdateUI()
    {
        // player one
        playerWName.text = GameLibrary.instance.Players[Players.Player1].Name;
        playerWSma.text = GameLibrary.instance.Players[Players.Player1].Smarts.ToString();
        playerWMox.text = GameLibrary.instance.Players[Players.Player1].Moxie.ToString();
        playerWMus.text = GameLibrary.instance.Players[Players.Player1].Strength.ToString();

        // player two
        playerXName.text = GameLibrary.instance.Players[Players.Player2].Name;
        playerXSma.text = GameLibrary.instance.Players[Players.Player2].Smarts.ToString();
        playerXMox.text = GameLibrary.instance.Players[Players.Player2].Moxie.ToString();
        playerXMus.text = GameLibrary.instance.Players[Players.Player2].Strength.ToString();

        // player three
        playerYName.text = GameLibrary.instance.Players[Players.Player3].Name;
        playerYSma.text = GameLibrary.instance.Players[Players.Player3].Smarts.ToString();
        playerYMox.text = GameLibrary.instance.Players[Players.Player3].Moxie.ToString();
        playerYMus.text = GameLibrary.instance.Players[Players.Player3].Strength.ToString();

        // player four
        playerZName.text = GameLibrary.instance.Players[Players.Player4].Name;
        playerZSma.text = GameLibrary.instance.Players[Players.Player4].Smarts.ToString();
        playerZMox.text = GameLibrary.instance.Players[Players.Player4].Moxie.ToString();
        playerZMus.text = GameLibrary.instance.Players[Players.Player4].Strength.ToString();
    }

    /// <summary>
    /// Passes the current turn to the next player
    /// </summary>
    public void PassTurn()
    { }

    /// <summary>
    /// Loads the save game, if it exists
    /// </summary>
    public void LoadGame()
    { }

    /// <summary>
    /// Ends the game
    /// </summary>
    public void EndGame()
    { }

    public void ClickDrawSituation()
    {
        UIManager.instance.DrawSituation(GameLibrary.instance.GetNewSituation());
    }

    public void ClickLowerCrime()
    {
        UIManager.instance.LowerCrime();
    }

    public void ClickSpecialAbility()
    {
        UIManager.instance.SpecialAbility();
    }

    #endregion
}