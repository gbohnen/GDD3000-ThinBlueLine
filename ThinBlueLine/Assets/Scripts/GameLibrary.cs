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

    private static GameLibrary instance;

    List<PlayerScript> playerLib = new List<PlayerScript>();

    private Dictionary<Players, PlayerScript> players = new Dictionary<Players, PlayerScript>();

    bool init = false;

    //private List<Situation> situationDeck;
    //private List<MajorCrimes> crimeDeck;
    // etc.

    void Start()
    {
        DontDestroyOnLoad(this);
        Initialize();
    }

    public void Initialize()
    {
        // load players
        List<Player> avatars = LoadGameData.LoadPlayers();
        foreach (Player play in avatars)
        {
            playerLib.Add(new PlayerScript(play));
        }

        //situationDeck = LoadGameData.LoadSituations();
        //Shuffle(situationDeck);
        //crimeDeck = LoadGameData.LoadCrimes();
        //Shuffle(crimeDeck);

        init = true;
    }

    public static GameLibrary Instance
    {
        get
        {
            if (instance == null)
                instance = new GameLibrary();

            return instance;
        }
    }

    public List<PlayerScript> GetPlayerChoices()
    {
        if (init)
        {
            List<PlayerScript> choices = new List<PlayerScript>();

            int index;

            for (int i = 0; i < 3; i++)
            {
                do
                {
                    index = Random.Range(0, playerLib.Count);

                    if (!players.ContainsValue(playerLib[index]))
                    {
                        choices.Add(playerLib[index]);
                    }
                } while (!choices.Contains(playerLib[index]));
            }

            foreach (PlayerScript p in choices)
            {
                Debug.Log(p.Name);
            }

            return choices;
        }

        else
            return null;
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
