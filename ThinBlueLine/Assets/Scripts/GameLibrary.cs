using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;

public enum Players { Player1 = 0, Player2 = 1, Player3 = 2, Player4 = 3 }

public class GameLibrary : MonoBehaviour {

    public static GameLibrary instance;

    List<PlayerScript> playerLib = new List<PlayerScript>();
    List<SituationScript> situationLib = new List<SituationScript>();
    List<MobBossScript> mobBossLib = new List<MobBossScript>();

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
        List<LoadGameData.Player> avatars = LoadGameData.LoadPlayers();
        foreach (LoadGameData.Player play in avatars)
        {
            playerLib.Add(new PlayerScript(play));
        }

        List<LoadGameData.Situation> situations = LoadGameData.LoadSituations();
        foreach (LoadGameData.Situation sit in situations)
        {
            situationLib.Add(new SituationScript(sit));
        }

        List<LoadGameData.MobBoss> mobBosses = LoadGameData.LoadMobBosses();
        foreach (LoadGameData.MobBoss mobBoss in mobBosses)
        {
            mobBossLib.Add(new MobBossScript(mobBoss));
        }

        //Debug.Log(playerLib.Count);
        //Debug.Log(situationLib.Count);
        //Debug.Log(mobBossLib.Count);
    }

    public List<PlayerScript> GetPlayerChoices()
    {
        List<PlayerScript> choices = new List<PlayerScript>();

        int index;

        for (int i = 0; i < 3; i++)
        {
            do
            {
                index = Random.Range(0, playerLib.Count);                
            } while (choices.Contains(playerLib[index]) || players.ContainsValue(playerLib[index]));

            choices.Add(playerLib[index]);
        }

        return choices;
    }

    public SituationScript GetNewSituation()
    {
        int i = Random.Range(0, situationLib.Count);
        SituationScript sitch = situationLib[i];
        situationLib.RemoveAt(i);

        return sitch;
    }

    public List<PlayerScript> PlayerLib
    {
        get { return playerLib; }
    }

    public Dictionary<Players, PlayerScript> Players
    {
        get { return players; }
    }

    public List<SituationScript> SituationList
    {
        get { return situationLib; }
    }
}