using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Sprite player1Avat;
    public Sprite player2Avat;
    public Sprite player3Avat;
    public Sprite player4Avat;

    public GameObject playerWWindow;
    public GameObject playerXWindow;
    public GameObject playerYWindow;
    public GameObject playerZWindow;

    public Image avatThumb;

    Color32 active = new Color32(50, 194, 255, 255);
    Color32 inactive = new Color32(255, 255, 255, 100);

    public void PlayerWClicked()
    {
        ResetPlayers();
        playerWWindow.GetComponent<Image>().color = active;
        playerWWindow.GetComponent<Button>().interactable = false;
        avatThumb.sprite = player1Avat;
    }

    public void PlayerXCLicked()
    {
        ResetPlayers();
        playerXWindow.GetComponent<Image>().color = active;
        playerXWindow.GetComponent<Button>().interactable = false;
        avatThumb.sprite = player2Avat;
    }

    public void PlayerYClicked()
    {
        ResetPlayers();
        playerYWindow.GetComponent<Image>().color = active;
        playerYWindow.GetComponent<Button>().interactable = false;
        avatThumb.sprite = player3Avat;
    }

    public void PlayerZClicked()
    {
        ResetPlayers();
        playerZWindow.GetComponent<Image>().color = active;
        playerZWindow.GetComponent<Button>().interactable = false;
        avatThumb.sprite = player4Avat;
    }

    void ResetPlayers()
    {
        playerWWindow.GetComponent<Image>().color = inactive;
        playerXWindow.GetComponent<Image>().color = inactive;
        playerYWindow.GetComponent<Image>().color = inactive;
        playerZWindow.GetComponent<Image>().color = inactive;

        playerWWindow.GetComponent<Button>().interactable = true;
        playerXWindow.GetComponent<Button>().interactable = true;
        playerYWindow.GetComponent<Button>().interactable = true;
        playerZWindow.GetComponent<Button>().interactable = true;
    }
}