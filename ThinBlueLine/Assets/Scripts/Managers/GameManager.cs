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

    #endregion

    #region Properties

    public Players CurrentPlayer
    {
        get { return currentPlayer; }
    }

    #endregion

    #region Public Methods

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

    #endregion

    
}