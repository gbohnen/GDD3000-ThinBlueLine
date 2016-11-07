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

    // store the player ame objects
    public GameObject playerWWindow;
    public GameObject playerXWindow;
    public GameObject playerYWindow;
    public GameObject playerZWindow;

    // store the players avatar
    public Image avatThumb;

    // store an instance of the game manager
    static GameManager instance;

    // store the players
    Players currentPlayer;
    Dictionary<Players, PlayerScript> players;

    // store the crimes & situations
    MajorCrimeScript majorCrime;
    List<SituationScript> situations;

    // store the mob boss & police chief
    MobBossScript mobBoss;
    PoliceChiefScript policeChief;

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

    #region Properties

    /// <summary>
    /// Gets the singleton instance of the game manager
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            // check if there is already an instance of the game manager
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    private GameManager()
    {
        // initialize the audio manager
        Audio = new AudioManager();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets or sets the audio manager
    /// </summary>
    public AudioManager Audio
    { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        UpdateUI();
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

    /// <summary>
    /// Resets the players image and button
    /// </summary>
    void ResetPlayers()
    {
        playerWWindow.GetComponent<Image>().color = Constants.INACTIVE;
        playerXWindow.GetComponent<Image>().color = Constants.INACTIVE;
        playerYWindow.GetComponent<Image>().color = Constants.INACTIVE;
        playerZWindow.GetComponent<Image>().color = Constants.INACTIVE;

        playerWWindow.GetComponent<Button>().interactable = true;
        playerXWindow.GetComponent<Button>().interactable = true;
        playerYWindow.GetComponent<Button>().interactable = true;
        playerZWindow.GetComponent<Button>().interactable = true;
    }

    #endregion
}