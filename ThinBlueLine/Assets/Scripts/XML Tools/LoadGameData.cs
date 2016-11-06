﻿using UnityEngine;
using System.Collections;
using System.Xml;
using System;
using System.Collections.Generic;
using Assets.Scripts;

public static class LoadGameData {

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
        public int smMod;
        public int musMod;
        public int moxMod;
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
                    case "name":    player.name = childNode.InnerText; break;
                    case "desc":    player.desc = childNode.InnerText; break;
                    case "muscle":  player.muscle = int.Parse(childNode.InnerText); break;
                    case "smarts":  player.smarts = int.Parse(childNode.InnerText); break;
                    case "moxie":   player.moxie = int.Parse(childNode.InnerText); break;
                    case "special": player.special = childNode.InnerText; break;
                    case "story":   player.story = childNode.InnerText; break;
                    default:        break;
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
        XmlNodeList situationList = situationDoc.GetElementsByTagName("situation");           // get all tags labeled situaiton

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
                    case "cost": situation.cost = int.Parse(childNode.InnerText); break;
                    case "smartsmod": situation.smMod = int.Parse(childNode.InnerText); break;
                    case "musclemod": situation.musMod = int.Parse(childNode.InnerText); break;
                    case "moxiemod": situation.moxMod = int.Parse(childNode.InnerText); break;
                    case "positive": situation.posOut = childNode.InnerText; break;
                    case "negative": situation.negOut = childNode.InnerText; break;
                    default: break;
                }
            }
            situations.Add(situation);
        }
        return situations;
    }

    //public static List<MobBosses> LoadMobBosses()
    //{ }

    //public static List<MajorCrimes> LoadMajorCrimes()
    //{ }
}