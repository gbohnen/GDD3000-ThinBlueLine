using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine.EventSystems;
using System;

public class PlayerSelect : MonoBehaviour
{

    #region Fields

    // animation
    private Animator section1animator;
    private Animator section2animator;
    private Animator section3animator;

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
    PlayerScript section1Player;

    public GameObject section2;
    public Button section2Button;
    public Text section2Name;
    public Image section2Avat;
    public Text section2Skill;
    public Text section2Bio;
    public Text section2Smarts;
    public Text section2Moxie;
    public Text section2Strength;
    PlayerScript section2Player;

    public GameObject section3;
    public Button section3Button;
    public Text section3Name;
    public Image section3Avat;
    public Text section3Skill;
    public Text section3Bio;
    public Text section3Smarts;
    public Text section3Moxie;
    public Text section3Strength;
    PlayerScript section3Player;

    List<PlayerScript> trio;

    Players currentPlayer = Players.Player1;

    #endregion

    void Awake()
    {
        section1animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        section2animator = gameObject.transform.GetChild(1).GetComponent<Animator>();
        section3animator = gameObject.transform.GetChild(2).GetComponent<Animator>();
    }

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
        trio = GameLibrary.instance.GetPlayerChoices();

        // load first section
        section1Name.text = trio[0].Name;
        section1Skill.text = trio[0].Special;
        section1Bio.text = trio[0].Bio;
        section1Smarts.text = trio[0].Smarts.ToString();
        section1Moxie.text = trio[0].Smarts.ToString();
        section1Strength.text = trio[0].Smarts.ToString();
        section1Player = trio[0];

        // load second section
        section2Name.text = trio[1].Name;
        section2Skill.text = trio[1].Special;
        section2Bio.text = trio[1].Bio;
        section2Smarts.text = trio[1].Smarts.ToString();
        section2Moxie.text = trio[1].Smarts.ToString();
        section2Strength.text = trio[1].Smarts.ToString();
        section2Player = trio[1];

        // load third section
        section3Name.text = trio[2].Name;
        section3Skill.text = trio[2].Special;
        section3Bio.text = trio[2].Bio;
        section3Smarts.text = trio[2].Smarts.ToString();
        section3Moxie.text = trio[2].Smarts.ToString();
        section3Strength.text = trio[2].Smarts.ToString();
        section3Player = trio[2];
    }

    public void ButtonSelect()
    {
        // get player based on first char of button name
        SetPlayer(trio[Int32.Parse(EventSystem.current.currentSelectedGameObject.name.Substring(0, 1)) - 1]);

        CloseAnim();
        
        Invoke("LoadChoices", 1);
        Invoke("OpenAnim", 1);
    }

    private void SetPlayer(PlayerScript choice)
    {
        switch (currentPlayer)
        {
            case Players.Player1:
                GameLibrary.instance.Players[Players.Player1] = choice;
                playerWName.text = choice.Name;
                playerWSma.text = choice.Smarts.ToString();
                playerWMox.text = choice.Moxie.ToString();
                playerWMus.text = choice.Moxie.ToString();
                break;

            case Players.Player2:
                GameLibrary.instance.Players[Players.Player2] = choice;
                playerXName.text = choice.Name;
                playerXSma.text = choice.Smarts.ToString();
                playerXMox.text = choice.Moxie.ToString();
                playerXMus.text = choice.Moxie.ToString();
                break;
            case Players.Player3:

                GameLibrary.instance.Players[Players.Player3] = choice;
                playerYName.text = choice.Name;
                playerYSma.text = choice.Smarts.ToString();
                playerYMox.text = choice.Moxie.ToString();
                playerYMus.text = choice.Moxie.ToString();
                break;

            case Players.Player4:
                GameLibrary.instance.Players[Players.Player4] = choice;
                playerZName.text = choice.Name;
                playerZSma.text = choice.Smarts.ToString();
                playerZMox.text = choice.Moxie.ToString();
                playerZMus.text = choice.Moxie.ToString();
                break;
            default:
                break;
        }

        currentPlayer++;
    }

    private void CloseAnim()
    {
        section1animator.SetBool("open", false);
        section2animator.SetBool("open", false);
        section3animator.SetBool("open", false);
    }

    private void OpenAnim()
    {
        section1animator.SetBool("open", true);
        section2animator.SetBool("open", true);
        section3animator.SetBool("open", true);
    }
}