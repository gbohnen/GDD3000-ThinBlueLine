using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets.Scripts;

public class PlayerSelect : MonoBehaviour {

    #region Fields

    // player UI fields
    public Text playerWName;
    public Text playerWSma;
    public Text playerWMox;
    public Text playerWMus;

    public Text playerXName;
    public Text playerXSma;
    public Text playerXMox;
    public Text playerXMus;

    public Text playerYName;
    public Text playerYSma;
    public Text playerYMox;
    public Text playerYMus;

    public Text playerZName;
    public Text playerZSma;
    public Text playerZMox;
    public Text playerZMus;

    // section UI fields
    public GameObject section1;
    public Button section1Button;
    public Text section1Name;
    public Image section1Avat;
    public Text section1Skill;
    public Text section1Bio;
    public Text section1Smarts;
    public Text section1Moxie;
    public Text section1Strength;

    public GameObject section2;
    public Button section2Button;
    public Text section2Name;
    public Image section2Avat;
    public Text section2Skill;
    public Text section2Bio;
    public Text section2Smarts;
    public Text section2Moxie;
    public Text section2Strength;

    public GameObject section3;
    public Button section3Button;
    public Text section3Name;
    public Image section3Avat;
    public Text section3Skill;
    public Text section3Bio;
    public Text section3Smarts;
    public Text section3Moxie;
    public Text section3Strength;

    #endregion

    void Start()
    {
        // set names
        playerWName.text = "Player 1";
        playerXName.text = "Player 2";
        playerYName.text = "Player 3";
        playerZName.text = "Player 4";


        LoadChoices();
        

    }

    void LoadChoices()
    {
        List<PlayerScript> trio = GameLibrary.instance.GetPlayerChoices();

        // load first section
        section1Name.text = trio[0].Name;
        section1Skill.text = trio[0].Special;
        section1Bio.text = trio[0].Bio;
        section1Smarts.text = trio[0].Smarts.ToString();
        section1Moxie.text = trio[0].Smarts.ToString();
        section1Strength.text = trio[0].Smarts.ToString();

        // load second section
        section2Name.text = trio[1].Name;
        section2Skill.text = trio[1].Special;
        section2Bio.text = trio[1].Bio;
        section2Smarts.text = trio[1].Smarts.ToString();
        section2Moxie.text = trio[1].Smarts.ToString();
        section2Strength.text = trio[1].Smarts.ToString();

        // load third section
        section3Name.text = trio[2].Name;
        section3Skill.text = trio[2].Special;
        section3Bio.text = trio[2].Bio;
        section3Smarts.text = trio[2].Smarts.ToString();
        section3Moxie.text = trio[2].Smarts.ToString();
        section3Strength.text = trio[2].Smarts.ToString();
    }

    

}
