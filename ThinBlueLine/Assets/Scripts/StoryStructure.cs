using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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

    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        totalPages = 23;

        PlayerPrefs.SetInt("currentPage", 1);
        if (currentPage == 0)
            currentPage = PlayerPrefs.GetInt("currentPage");

        UpdateStoryPanel();
    }

    /// <summary>
    /// Updates the tutprial story panel
    /// </summary>
    public void UpdateStoryPanel()
    {
        // add each dialogue option in a case below. additional cases are easily added. 
        // use the format described in case 1
        switch (currentPage)
        {
            case 1:
                headerText.text = "Chief Bob Walsh";
                activeText.text = GameLibrary.instance.TutorialList[0].Page0;
                break;
            case 2:
                activeText.text = GameLibrary.instance.TutorialList[0].Page1;
                break;
            case 3:
                activeText.text = GameLibrary.instance.TutorialList[0].Page2;
                background.sprite = newBackground;
                break;
            case 4:
                activeText.text = GameLibrary.instance.TutorialList[0].Page3;
                break;
            case 5:
                activeText.text = GameLibrary.instance.TutorialList[0].Page4;
                break;
            case 6:
                activeText.text = GameLibrary.instance.TutorialList[0].Page5;
                break;
            case 7:
                activeText.text = GameLibrary.instance.TutorialList[0].Page6;
                break;
            case 8:
                activeText.text = GameLibrary.instance.TutorialList[0].Page7;
                break;
            case 9:
                activeText.text = GameLibrary.instance.TutorialList[0].Page8;
                break;
            case 10:
                activeText.text = GameLibrary.instance.TutorialList[0].Page9;
                break;
            case 11:
                SceneManager.LoadScene(2);
                break;
            default:
                headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "";
                currentPage = 0;
                SceneManager.LoadScene(0);
                break;
        }

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