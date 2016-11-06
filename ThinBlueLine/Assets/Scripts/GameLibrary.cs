using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;

public enum Players { Player1, Player2, Player3, Player4 }

public struct Player
{
    public string name;
    public string desc;
    public int muscle;
    public int smarts;
    public int moxie;
    public string special;
    public string story;
}

public class GameLibrary : MonoBehaviour {

    public static GameLibrary instance;

    List<PlayerScript> playerLib = new List<PlayerScript>();

    private Dictionary<Players, PlayerScript> players = new Dictionary<Players, PlayerScript>();
    
    //private List<Situation> situationDeck;
    //private List<MajorCrimes> crimeDeck;
    // etc.

    void Awake()
    {
        Initialize();

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    public void Initialize()
    {
        // load players
        List<Player> avatars = LoadGameData.LoadPlayers();
        foreach (Player play in avatars)
        {
            playerLib.Add(new PlayerScript(play));
        }


        Debug.Log(playerLib.Count);

        //situationDeck = LoadGameData.LoadSituations();
        //Shuffle(situationDeck);
        //crimeDeck = LoadGameData.LoadCrimes();
        //Shuffle(crimeDeck);
    }

    public List<PlayerScript> GetPlayerChoices()
    {
        List<PlayerScript> choices = new List<PlayerScript>();

        int index;

        for (int i = 0; i < 3; i++)
        {
            Debug.Log(playerLib.Count);
            do
            {
                index = Random.Range(0, playerLib.Count);                
            } while (choices.Contains(playerLib[index]) || players.ContainsValue(playerLib[index]));

            choices.Add(playerLib[index]);
        }

        return choices;
    }
 
    public List<PlayerScript> PlayerLib
    {
        get { return playerLib; }
    }

    public Dictionary<Players, PlayerScript> Players
    {
        get { return players; }
    }
}
