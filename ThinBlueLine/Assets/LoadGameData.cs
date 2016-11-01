using UnityEngine;
using System.Collections;
using System.Xml;
using System;

struct Player
{
    public string name;
    public string desc;
    public int muscle;
    public int smarts;
    public int moxie;
    public string special;
    public string story;
}


public class LoadGameData : MonoBehaviour {

    public TextAsset playerFile;
    Player player;

	// Use this for initialization
	void Start () {
        LoadPlayers();

        Debug.Log(player.name);
        Debug.Log(player.desc);
        Debug.Log(player.muscle);
        Debug.Log(player.smarts);
        Debug.Log(player.moxie);
        Debug.Log(player.special);
        Debug.Log(player.story);
        
	}

    void LoadPlayers()
    {
        XmlDocument playerDoc = new XmlDocument();
        playerDoc.LoadXml(playerFile.text);
        XmlNodeList avatarList = playerDoc.GetElementsByTagName("avatar");

        foreach (XmlNode node in avatarList)
        {
            XmlNodeList playerData = node.ChildNodes;

            foreach (XmlNode childNode in playerData)
            {
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
        }
    }
}
