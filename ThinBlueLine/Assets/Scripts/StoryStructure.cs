using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class StoryStructure : MonoBehaviour
{

    // updates the story page. called by buttons and other "progress" keys

    public static StoryStructure Instance = null;

    static int totalPages;                  		// total pages in current level
    public static int currentPage;                  // currently displayed page

    public Text headerText;                         // element that displays the current character
    public Text activeText;                         // element that displays the current story
    string supplies;                                // deprecated

    // buttons and sundry
    public Image background;
    public Image currChar;
    public GameObject continueButton;
    public GameObject choice1Button;
    public Text choice1Text;
    public GameObject choice2Button;
    public Text choice2Text;

    public Sprite newBackground;
    //public Sprite newChar;

	List<string> tutorialText;

    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        PlayerPrefs.SetInt("currentPage", 0);
        if (currentPage == 0)
            currentPage = PlayerPrefs.GetInt("currentPage");

		tutorialText = LoadGameData.LoadTutorial ();
		totalPages = tutorialText.Count;

		headerText.text = "Chief Walsh";

        UpdateStoryPanel();
    }

    /// <summary>
    /// Updates the tutprial story panel
    /// </summary>
    public void UpdateStoryPanel()
    {
		if (currentPage >= tutorialText.Count)
        {
			SceneManager.LoadScene (Constants.PLAYER_SELECTION_SCENE);
		}

		activeText.GetComponent<Text>().text = tutorialText [currentPage];

        PlayerPrefs.SetInt("currentPage", currentPage);
    }

    public void ClickContinue()
    {
        if (currentPage < totalPages)
        {
            currentPage = PlayerPrefs.GetInt("currentPage") + 1;
            UpdateStoryPanel();
        }
        else
            SceneManager.LoadScene(0);

    }

    public void ClickOption1()
    {
        currentPage = PlayerPrefs.GetInt("currentPage") + 1;
        UpdateStoryPanel();
        choice1Button.SetActive(false);
        choice2Button.SetActive(false);
        continueButton.SetActive(true);
    }

    public void ClickOption2()
    {
        currentPage = PlayerPrefs.GetInt("currentPage") + 2;
        UpdateStoryPanel();
        choice1Button.SetActive(false);
        choice2Button.SetActive(false);
        continueButton.SetActive(true);
    }

    /// <summary>
    /// Changes the backgrouund
    /// </summary>
    /// <param name="back">the background image</param>
    /// <param name="target">the target sprite</param>
    /// <param name="time">the time</param>
    IEnumerator ChangeBackground(Image back, Sprite target, float time)
    {
        float currentTime = 0f;

        do
        {
            Debug.Log(currentTime);
            Debug.Log(back.color.a);
            back.color = new Color(1, 1, 1, currentTime / time);
            currentTime += Time.deltaTime;
        } while (currentTime <= time);

        back.sprite = target;
        currentTime = 0f;

        do
        {
            back.color = new Color(1, 1, 1, currentTime / time);
            currentTime += Time.deltaTime;
        } while (currentTime <= time);

        yield return null;
    }
}