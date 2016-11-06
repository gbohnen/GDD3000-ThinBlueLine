using UnityEngine;
using System.Xml;
using System;
using System.Collections.Generic;
using Assets.Scripts;

public static class LoadGameData
{
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
    }

    public struct MobBoss
    {
        public string name;
        public string lossCond;
        public string ongEff;
        public string mod;
        public string story;
    }

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
                    case "name": player.name = childNode.InnerText; break;
                    case "desc": player.desc = childNode.InnerText; break;
                    case "muscle": player.muscle = Int32.Parse(childNode.InnerText); break;
                    case "smarts": player.smarts = Int32.Parse(childNode.InnerText); break;
                    case "moxie": player.moxie = Int32.Parse(childNode.InnerText); break;
                    case "special": player.special = childNode.InnerText; break;
                    case "story": player.story = childNode.InnerText; break;
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
                    case "name": situation.name = childNode.InnerText; break;
                    case "description": situation.desc = childNode.InnerText; break;
                    case "immediate": situation.immEff = childNode.InnerText; break;
                    case "ongoing": situation.ongEff = childNode.InnerText; break;
                    case "cost": situation.cost = Int32.Parse(childNode.InnerText); break;
                    case "smartsmod": situation.smMod = float.Parse(childNode.InnerText); break;
                    case "musclemod": situation.musMod = float.Parse(childNode.InnerText); break;
                    case "moxiemod": situation.moxMod = float.Parse(childNode.InnerText); break;
                    case "positive": situation.posOut = childNode.InnerText; break;
                    case "negative": situation.negOut = childNode.InnerText; break;
                    default: break;
                }
            }

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
    public static List<MajorCrime> LoadMajorCrimes()
    {
        TextAsset majorCrimeFile = (TextAsset)Resources.Load(Constants.MAJOR_CRIMES_FILE_NAME);

        // instantiate necessary components
        XmlDocument majorCrimeDoc = new XmlDocument();                                           // blank xml doc
        majorCrimeDoc.LoadXml(majorCrimeFile.text);                                              // load major crime file
        XmlNodeList majorCrimeList = majorCrimeDoc.GetElementsByTagName("majorCrime");           // get all tags labeled major crime

        List<MajorCrime> majorCrimes = new List<MajorCrime>();                                   // list of major crimes

        // iterate all "mob boss" tags
        foreach (XmlNode node in majorCrimeList)
        {
            // make a list of all child node (this is where the major crime data is stored)
            XmlNodeList majorCrimeData = node.ChildNodes;

            // empty major crime
            MajorCrime majorCrime = new MajorCrime();

            // iterate those nodes
            foreach (XmlNode childNode in majorCrimeData)
            {
                // make a list of all child node (this is where the major crime child data is stored)
                XmlNodeList majorCrimeDataChild = childNode.ChildNodes;

                // load data into major crime based on child tag
                switch (childNode.Name)
                {
                    case "name": majorCrime.name = childNode.InnerText; break;
                    case "mobBoss": majorCrime.mobBoss = childNode.InnerText; break;
                    default: break;
                }

                //// 
                //foreach (XmlNode childChildNode in majorCrimeDataChild)
                //{
                //    switch (childNode.Name)
                //    {
                //        default:
                //            break;
                //    }
                //}
            }

            // add child to the list
            majorCrimes.Add(majorCrime);
        }

        // return list of all major crimes
        return majorCrimes;
    }
}