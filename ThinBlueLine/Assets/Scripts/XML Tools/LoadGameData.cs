using UnityEngine;
using System.Collections;
using System.Xml;
using System;
using System.Collections.Generic;


public static class LoadGameData {
    
    public static List<Player> LoadPlayers()
    {
        TextAsset playerFile = (TextAsset)Resources.Load("Assets/XML Resources/AvatarData");

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
                    case "muscle":  player.muscle = Int32.Parse(childNode.InnerText); break;
                    case "smarts":  player.smarts = Int32.Parse(childNode.InnerText); break;
                    case "moxie":   player.moxie = Int32.Parse(childNode.InnerText); break;
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
}
