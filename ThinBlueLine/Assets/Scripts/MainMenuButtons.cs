using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject optionsPanel;

    /// <summary>
    /// performs startup actions for the menu system
    /// </summary>
    public void Awake()
    {
        // set starting page
        PlayerPrefs.SetInt("currentPage", 1);

        // disable credits panel
        creditsPanel.GetComponent<CanvasGroup>().interactable = false;
        creditsPanel.GetComponent<CanvasGroup>().alpha = 0;
        creditsPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

        // disable options panel
        optionsPanel.GetComponent<CanvasGroup>().interactable = false;
        optionsPanel.GetComponent<CanvasGroup>().alpha = 0;
        optionsPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    /// <summary>
    /// starts the game
    /// </summary>
	public void PlayButton()
    {
        SceneManager.LoadScene(Constants.TUTORIAL_SCENE);
    }

    /// <summary>
    /// enables the options menu
    /// </summary>
    public void OpenOptionsButton()
    {
        optionsPanel.GetComponent<CanvasGroup>().interactable = true;
        optionsPanel.GetComponent<CanvasGroup>().alpha = 1;
        optionsPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    /// <summary>
    /// disables the options menu
    /// </summary>
    public void CloseOptionsButton()
    {
        optionsPanel.GetComponent<CanvasGroup>().interactable = false;
        optionsPanel.GetComponent<CanvasGroup>().alpha = 0;
        optionsPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    /// <summary>
    /// enables the credits panel
    /// </summary>
    public void OpenCreditsButton()
    {
        creditsPanel.GetComponent<CanvasGroup>().interactable = true;
        creditsPanel.GetComponent<CanvasGroup>().alpha = 1;
        creditsPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    /// <summary>
    /// closes the credits panel
    /// </summary>
    public void CloseCreditsButton()
    {
        creditsPanel.GetComponent<CanvasGroup>().interactable = false;
        creditsPanel.GetComponent<CanvasGroup>().alpha = 0;
        creditsPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    /// <summary>
    /// quits the game
    /// </summary>
    public void QuitButton()
    {
        Application.Quit();
    }
}