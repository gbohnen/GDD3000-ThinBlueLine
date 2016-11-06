using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    public GameObject section2;
    public Button section2Button;
    public Text section2Name;
    public Image section2Avat;
    public Text section2Skill;
    public Text section2Bio;

    public GameObject section3;
    public Button section3Button;
    public Text section3Name;
    public Image section3Avat;
    public Text section3Skill;
    public Text section3Bio;

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
        GameLibrary.Instance.GetPlayerChoices();
    }

}
