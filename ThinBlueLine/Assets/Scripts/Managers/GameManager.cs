using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Managers;
using Assets.Scripts;
using System.Collections.Generic;

/// <summary>
/// Singleton class which manages the state of the game
/// </summary>
public class GameManager
{
    #region Fields

    // store the players sprites
    public Sprite player1Avat;
    public Sprite player2Avat;
    public Sprite player3Avat;
    public Sprite player4Avat;

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
    PlayerScript currentPlayer;
    List<PlayerScript> players;

    // store the crimes & situations
    MajorCrimeScript majorCrime;
    List<SituationScript> situations;

    // store the mob boss & police chief
    MobBossScript mobBoss;
    PoliceChiefScript policeChief;

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
            { instance = new GameManager(); }
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
    /// Culls the objects which shall be inactive
    /// </summary>
    public void CullInactive()
    { }

    /// <summary>
    /// Player W is clicked
    /// </summary>
    public void PlayerWClicked()
    {
        ResetPlayers();
        playerWWindow.GetComponent<Image>().color = Constants.ACTIVE;
        playerWWindow.GetComponent<Button>().interactable = false;
        avatThumb.sprite = player1Avat;
    }

    /// <summary>
    /// Player X is clicked
    /// </summary>
    public void PlayerXCLicked()
    {
        ResetPlayers();
        playerXWindow.GetComponent<Image>().color = Constants.ACTIVE;
        playerXWindow.GetComponent<Button>().interactable = false;
        avatThumb.sprite = player2Avat;
    }

    /// <summary>
    /// Player Y is clicked
    /// </summary>
    public void PlayerYClicked()
    {
        ResetPlayers();
        playerYWindow.GetComponent<Image>().color = Constants.ACTIVE;
        playerYWindow.GetComponent<Button>().interactable = false;
        avatThumb.sprite = player3Avat;
    }

    /// <summary>
    /// Player Z is clicked
    /// </summary>
    public void PlayerZClicked()
    {
        ResetPlayers();
        playerZWindow.GetComponent<Image>().color = Constants.ACTIVE;
        playerZWindow.GetComponent<Button>().interactable = false;
        avatThumb.sprite = player4Avat;
    }

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