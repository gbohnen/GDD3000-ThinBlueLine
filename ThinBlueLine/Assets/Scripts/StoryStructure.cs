using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StoryStructure : MonoBehaviour {

    // updates the story page. called by buttons and other "progress" keys
	
	public static StoryStructure instance = null;

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
    public Sprite newChar;

	void Start()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);

		totalPages = 23;

        PlayerPrefs.SetInt("currentPage", 1);
		if (currentPage == 0)
			currentPage = PlayerPrefs.GetInt ("currentPage");

		UpdateStoryPanel();
	}

    public void UpdateStoryPanel()
    {
        // add each dialogue option in a case below. additional cases are easily added. 
        // use the format described in case 1
        switch (currentPage)
        {
            case 1:
                headerText.text = "Chief Wiggum";
                activeText.text = "Welcome to an extremely rudimentary tutorial system. Today we're going to be talking about panels.";
                break;
            case 2:
                activeText.text = "Nicely done! YOu found the right button. You're a smart one, I can tell. Let's go meet your partner.";
                break;
            case 3:
                activeText.text = "Meet Officer Les Gettham. You'll be working closely together for your next assignment.";
                background.sprite = newBackground;
                //ChangeBackground(background, newBackground, .3f);
                break;
            case 4:
                headerText.text = "Officer Gettham";
                activeText.text = "Hi there! Hope you're ready to get your hands dirty. We've got some serious work ahead of us.";
                currChar.sprite = newChar;
                break;
            case 5:
                activeText.text = "Let's go see what's going on in our city.";
                break;
            case 6:
                SceneManager.LoadScene(2);
                break;
		default:		
			headerText.GetComponent<Text> ().text = "";
			activeText.GetComponent<Text> ().text = "";
			currentPage = 0;
			SceneManager.LoadScene (0);
			break;
        }

		PlayerPrefs.SetInt ("currentPage", currentPage);
    }
	
	public void ClickContinue()
	{
		if (currentPage < totalPages)
		{
			currentPage = PlayerPrefs.GetInt ("currentPage") + 1;
			UpdateStoryPanel();
		}
		else
			SceneManager.LoadScene(0);
		
	}
	
	public void ClickOption1()
	{
		currentPage = PlayerPrefs.GetInt ("currentPage") + 1;
		UpdateStoryPanel();
		choice1Button.SetActive(false);
		choice2Button.SetActive(false);
		continueButton.SetActive(true);
	}
	
	public void ClickOption2()
	{
		currentPage = PlayerPrefs.GetInt ("currentPage") + 2;
		UpdateStoryPanel();
		choice1Button.SetActive(false);
		choice2Button.SetActive(false);
		continueButton.SetActive(true);
	}

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
