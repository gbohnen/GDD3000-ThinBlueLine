using UnityEngine;
using System.Xml;
using System.Collections.Generic;
using Assets.Scripts;

/// <summary>
/// Class which handles Loading Game Data from XMLs
/// </summary>
public static class LoadGameData
{
    /// <summary>
    /// Struct for the Player XML
    /// </summary>
    public struct Player
    {
        public string name;
        public string desc;
        public int muscle;
        public int smarts;
        public int moxie;
        public string special;
        public string story;
        public string avatPath;
    }

    /// <summary>
    /// Struct for the Situation XML
    /// </summary>
    public struct Situation
    {
        public string name;
        public string desc;
        public string immEff;
        public string ongEff;
        public int cost;
        public float smMod;
        public float musMod;
        public float moxMod;
        public string posOut;
        public string negOut;
		public string immEffMeth;
		public string ongEffMeth;
		public string posEffMeth;
		public string negEffMeth;
    }

    /// <summary>
    /// Struct for the Mob Boss XML
    /// </summary>
    public struct MobBoss
    {
        public string name;
        public string lossCond;
        public string ongEff;
        public string mod;
        public string story;
    }

    /// <summary>
    /// Struct for the Major Crime XML
    /// </summary>
    public struct MajorCrime
    {
        public string name;
        public string mobBoss;
    }

    /// <summary>
    /// Loads in the players from the XML
    /// </summary>
    /// <returns>the players</returns>
    public static List<Player> LoadPlayers()
    {
        TextAsset playerFile = (TextAsset)Resources.Load(Constants.PLAYER_FILE_NAME);

        // instantiate necessary components
        XmlDocument playerDoc = new XmlDocument();                                      // blank xml doc
        playerDoc.LoadXml(playerFile.text);                                             // load player file
        XmlNodeList avatarList = playerDoc.GetElementsByTagName("avatar");              // get all tags labeled avatar

        List<Player> players = new List<Player>();                                      // list of player objects

        // iterate all "avatar" tags
        foreach (XmlNode node in avatarList)
        {
            // make a list of all child node (this is where the palyer data is stored)
            XmlNodeList playerData = node.ChildNodes;

            // empty player
            Player player = new Player();

            // iterate those nodes
            foreach (XmlNode childNode in playerData)
            {
                // load data into player based on child tag
                switch (childNode.Name)
                {
                    case "name":    player.name = childNode.InnerText; break;
                    case "desc":    player.desc = childNode.InnerText; break;
                    case "muscle":  player.muscle = int.Parse(childNode.InnerText); break;
                    case "smarts":  player.smarts = int.Parse(childNode.InnerText); break;
                    case "moxie":   player.moxie = int.Parse(childNode.InnerText); break;
                    case "special": player.special = childNode.InnerText; break;
                    case "story":   player.story = childNode.InnerText; break;
                    case "profpic": player.avatPath = childNode.InnerText; break;
                    default: break;
                }
            }

            // add child to the list
            players.Add(player);
        }

        // return list of all players
        return players;
    }

    /// <summary>
    /// Loads in the situations from the XML
    /// </summary>
    /// <returns>the situations</returns>
    public static List<Situation> LoadSituations()
    {
        TextAsset situationFile = (TextAsset)Resources.Load(Constants.SITUATIONS_FILE_NAME);

        // instantiate necessary components
        XmlDocument situationDoc = new XmlDocument();                                         // blank xml doc
        situationDoc.LoadXml(situationFile.text);                                             // load situation file
        XmlNodeList situationList = situationDoc.GetElementsByTagName("situation");           // get all tags labeled situation

        List<Situation> situations = new List<Situation>();                                   // list of situations

        // iterate all "situation" tags
        foreach (XmlNode node in situationList)
        {
            // make a list of all child node (this is where the situation data is stored)
            XmlNodeList situationData = node.ChildNodes;

            // empty situation
            Situation situation = new Situation();

            // iterate those nodes
            foreach (XmlNode childNode in situationData)
            {
                // load data into situation based on child tag
                switch (childNode.Name)
                {
                    case "name": 			situation.name = childNode.InnerText; break;
                    case "description": 	situation.desc = childNode.InnerText; break;
                    case "immediate": 		situation.immEff = childNode.InnerText; break;
                    case "ongoing": 		situation.ongEff = childNode.InnerText; break;
                    case "cost": 			situation.cost = int.Parse(childNode.InnerText); break;
                    case "smartsmod": 		situation.smMod = float.Parse(childNode.InnerText); break;
                    case "musclemod": 		situation.musMod = float.Parse(childNode.InnerText); break;
                    case "moxiemod": 		situation.moxMod = float.Parse(childNode.InnerText); break;
                    case "positive": 		situation.posOut = childNode.InnerText; break;
                    case "negative": 		situation.negOut = childNode.InnerText; break;
				case "immediateeffectmethod":
					situation.immEffMeth = childNode.InnerText;
					break;
				case "ongoingeffectmethod":
					situation.ongEffMeth = childNode.InnerText;
					break;
				case "positiveoutcomemethod":
					situation.posEffMeth = childNode.InnerText;
					break;
				case "negativeoutcomemethod":
					situation.negEffMeth = childNode.InnerText;
					break;
                    default: break;
                }
            }

			//situation.immEffMeth = "DebugLine:" + situation.name;

            // add child to the list
            situations.Add(situation);
        }

        // return list of all situations
        return situations;
    }

    /// <summary>
    /// Loads in the mob boss XML
    /// </summary>
    /// <returns>the mob bosses</returns>
    public static List<MobBoss> LoadMobBosses()
    {
        TextAsset mobBossFile = (TextAsset)Resources.Load(Constants.MOB_BOSS_FILE_NAME);

        // instantiate necessary components
        XmlDocument mobBossDoc = new XmlDocument();                                        // blank xml doc
        mobBossDoc.LoadXml(mobBossFile.text);                                              // load situation file
        XmlNodeList mobBossList = mobBossDoc.GetElementsByTagName("mobBoss");              // get all tags labeled mob boss

        List<MobBoss> mobBosses = new List<MobBoss>();                                     // list of mob bosses

        // iterate all "mob boss" tags
        foreach (XmlNode node in mobBossList)
        {
            // make a list of all child node (this is where the mob boss data is stored)
            XmlNodeList mobBossData = node.ChildNodes;

            // empty mob boss
            MobBoss mobBoss = new MobBoss();

            // iterate those nodes
            foreach (XmlNode childNode in mobBossData)
            {
                // load data into mob boss based on child tag
                switch (childNode.Name)
                {
                    case "name": mobBoss.name = childNode.InnerText; break;
                    case "lossCondition": mobBoss.lossCond = childNode.InnerText; break;
                    case "ongoingEffect": mobBoss.ongEff = childNode.InnerText; break;
                    case "modifier": mobBoss.mod = childNode.InnerText; break;
                    case "story": mobBoss.story = childNode.InnerText; break;
                    default: break;
                }
            }
            // add child to the list
            mobBosses.Add(mobBoss);
        }

        // return list of all mob bosses
        return mobBosses;
    }

    /// <summary>
    /// Loads in the Major Crimes from the XML
    /// </summary>
    /// <returns>the major crimes</returns>
    public static MajorCrimeScript LoadMajorCrimes()
    {
        TextAsset majorCrimeFile = (TextAsset)Resources.Load(Constants.MAJOR_CRIMES_FILE_NAME);

        // instantiate necessary components
        XmlDocument majorCrimeDoc = new XmlDocument();                                           // blank xml doc
        majorCrimeDoc.LoadXml(majorCrimeFile.text);                                              // load major crime file
        XmlNodeList majorCrimeList = majorCrimeDoc.GetElementsByTagName("majorCrime");           // get all tags labeled major crime

        MajorCrimeScript majorCrime = new MajorCrimeScript();

        Debug.Log(majorCrime.Name);

        XmlNodeList nodeList = majorCrimeList[Random.Range(0, majorCrimeList.Count)].ChildNodes;

        foreach (XmlNode node in nodeList)
        {
            switch (node.Name)
            {
                case "name":        majorCrime.Name = node.InnerText; break;
                case "mobBoss":     majorCrime.MobBoss = node.InnerText; break;
                default:
                    MajorCrimeTier tier = new MajorCrimeTier();
                    XmlNodeList childList = node.ChildNodes;
                    foreach (XmlNode childNode in childList)
                    {
                        switch (childNode.Name)
                        {
                            case "crimeEffect":     tier.CrimeEffectText = childNode.InnerText; break;
                            case "choiceOne":       tier.OptionOneText = childNode.InnerText; break;
                            //case "choiceOneStats":  tier.OptionTwoCosts = ParseStats(childNode.InnerText); break;
                            case "choiceTwo":       tier.OptionTwoText = childNode.InnerText; break;
                            //case "choiceTwoStats":  tier.OptionOneCosts = ParseStats(childNode.InnerText); break;
                        }
                    }
                    majorCrime.CrimeTiers.Add(tier);
                    break;
            }
        }

        Debug.Log(majorCrime.Name);

        // return list of all major crimes
        return majorCrime;
    }

    /// <summary>
    /// Loads in the tutorial from the XML
    /// </summary>
    /// <returns>the tutorial</returns>
    public static  List<string> LoadTutorial()
    {
        TextAsset tutorialFile = (TextAsset)Resources.Load(Constants.TUTORIAL_FILE_NAME);

        // instantiate necessary components
        XmlDocument tutorialDoc = new XmlDocument();                                           // blank xml doc
        tutorialDoc.LoadXml(tutorialFile.text);                                                // load tutorial file
        XmlNodeList tutorialList = tutorialDoc.GetElementsByTagName("tutorialpages");          // get all tags labeled tutorial

        List<string> tutorial = new List<string>();                                        // list of tutorial info

        // iterate all "tutorial" tags
        foreach (XmlNode node in tutorialList)
        {
            // make a list of all child node (this is where the tutorial data is stored)
            XmlNodeList tutorialData = node.ChildNodes;

            // iterate those nodes
            foreach (XmlNode childNode in tutorialData)
            {
				if (childNode.Name == "page") {
					tutorial.Add(childNode.InnerText);
				}
            }
        }

        // return list of tutorial info
        return tutorial;
    }

    //public static Vector3 ParseStats(string str)
    //{
    //    Vector3 vect = new Vector3();

    //    return vect;
    //}
}