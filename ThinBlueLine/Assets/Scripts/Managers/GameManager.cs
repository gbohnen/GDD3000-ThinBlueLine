using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Singleton class which manages the state of the game
/// </summary>
public class GameManager
{
    #region Fields

    public Sprite player1Avat;
    public Sprite player2Avat;
    public Sprite player3Avat;
    public Sprite player4Avat;

    public GameObject playerWWindow;
    public GameObject playerXWindow;
    public GameObject playerYWindow;
    public GameObject playerZWindow;

    public Image avatThumb;

    Color32 active = new Color32(50, 194, 255, 255);
    Color32 inactive = new Color32(255, 255, 255, 100);

    static GameManager instance;
    //Player currentPlyer;
    //List<Player> players;
    //MajorCrime majorCrime;
    //List<Situations> situations;
    //MobBoss mobBoss;
    //PoliceChief policeChief;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the singleton instance of the game manager
    /// </summary>
    public static GameManager Instance
    {
        get
        {
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
    { }

    #endregion

    #region Public Methods

    public void PlayerWClicked()
    {
        ResetPlayers();
        playerWWindow.GetComponent<Image>().color = active;
        playerWWindow.GetComponent<Button>().interactable = false;
        avatThumb.sprite = player1Avat;
    }

    public void PlayerXCLicked()
    {
        ResetPlayers();
        playerXWindow.GetComponent<Image>().color = active;
        playerXWindow.GetComponent<Button>().interactable = false;
        avatThumb.sprite = player2Avat;
    }

    public void PlayerYClicked()
    {
        ResetPlayers();
        playerYWindow.GetComponent<Image>().color = active;
        playerYWindow.GetComponent<Button>().interactable = false;
        avatThumb.sprite = player3Avat;
    }

    public void PlayerZClicked()
    {
        ResetPlayers();
        playerZWindow.GetComponent<Image>().color = active;
        playerZWindow.GetComponent<Button>().interactable = false;
        avatThumb.sprite = player4Avat;
    }

    void ResetPlayers()
    {
        playerWWindow.GetComponent<Image>().color = inactive;
        playerXWindow.GetComponent<Image>().color = inactive;
        playerYWindow.GetComponent<Image>().color = inactive;
        playerZWindow.GetComponent<Image>().color = inactive;

        playerWWindow.GetComponent<Button>().interactable = true;
        playerXWindow.GetComponent<Button>().interactable = true;
        playerYWindow.GetComponent<Button>().interactable = true;
        playerZWindow.GetComponent<Button>().interactable = true;
    }

    #endregion
}