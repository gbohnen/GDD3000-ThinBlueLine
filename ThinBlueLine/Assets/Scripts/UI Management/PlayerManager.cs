using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    // store the players avatar
    public Image avatThumb;

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

    public Image playerWAvat;
    public Image playerXAvat;
    public Image playerYAvat;
    public Image playerZAvat;

    public Image playerWindic;
    public Image playerXindic;
    public Image playerYindic;
    public Image playerZindic;

    // store the animation indicator
    public Animator indicatorAnimator;

    public void UpdateUI()
    {
        // update base stats
        // player one
        playerWName.text = GameLibrary.instance.Players[Players.Player1].Name;
        playerWSma.text = GameLibrary.instance.Players[Players.Player1].Smarts.ToString();
        playerWMox.text = GameLibrary.instance.Players[Players.Player1].Moxie.ToString();
        playerWMus.text = GameLibrary.instance.Players[Players.Player1].Muscle.ToString();

        playerWAvat.sprite = GameLibrary.instance.Players[Players.Player1].Avatar;
        playerWindic.sprite = GameLibrary.instance.Players[Players.Player1].Avatar;

        // player two
        playerXName.text = GameLibrary.instance.Players[Players.Player2].Name;
        playerXSma.text = GameLibrary.instance.Players[Players.Player2].Smarts.ToString();
        playerXMox.text = GameLibrary.instance.Players[Players.Player2].Moxie.ToString();
        playerXMus.text = GameLibrary.instance.Players[Players.Player2].Muscle.ToString();

        playerXAvat.sprite = GameLibrary.instance.Players[Players.Player2].Avatar;
        playerXindic.sprite = GameLibrary.instance.Players[Players.Player2].Avatar;

        // player three
        playerYName.text = GameLibrary.instance.Players[Players.Player3].Name;
        playerYSma.text = GameLibrary.instance.Players[Players.Player3].Smarts.ToString();
        playerYMox.text = GameLibrary.instance.Players[Players.Player3].Moxie.ToString();
        playerYMus.text = GameLibrary.instance.Players[Players.Player3].Muscle.ToString();

        playerYAvat.sprite = GameLibrary.instance.Players[Players.Player3].Avatar;
        playerYindic.sprite = GameLibrary.instance.Players[Players.Player3].Avatar;

        // player four
        playerZName.text = GameLibrary.instance.Players[Players.Player4].Name;
        playerZSma.text = GameLibrary.instance.Players[Players.Player4].Smarts.ToString();
        playerZMox.text = GameLibrary.instance.Players[Players.Player4].Moxie.ToString();
        playerZMus.text = GameLibrary.instance.Players[Players.Player4].Muscle.ToString();

        playerZAvat.sprite = GameLibrary.instance.Players[Players.Player4].Avatar;
        playerZindic.sprite = GameLibrary.instance.Players[Players.Player4].Avatar;

        // update current player avatar
        avatThumb.sprite = GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Avatar;
    }

    public void UpdateIndicator()
    {
        indicatorAnimator.SetInteger("Phase", (int)GameManager.Instance.CurrentPlayer);
    }
}
