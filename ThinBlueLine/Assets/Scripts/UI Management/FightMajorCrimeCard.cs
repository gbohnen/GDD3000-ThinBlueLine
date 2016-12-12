using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;

public class FightMajorCrimeCard : MonoBehaviour
{

    // ui fields
    public Text smartsText;
    public Text moxieText;
    public Text muscleText;
    public Slider smartsSlider;
    public Slider moxieSlider;
    public Slider muscleSlider;

    public Text optionOneTitle;
    public Text optionTwoTitle;
    public Text optionOneCost;
    public Text optionTwoCost;
    public Text totalStatsSpent;

    public MajorCrimeTier tier;

    float totalThreshold = 3.0f;

    public void LoadCard(int i)
    {
        MajorCrimeTier tier = GameManager.Instance.majorCrime.CrimeTiers[i];

        optionOneTitle.text = tier.OptionOneText.Substring(0, tier.OptionOneText.IndexOf(':'));
        optionTwoTitle.text = tier.OptionTwoText.Substring(0, tier.OptionTwoText.IndexOf(':'));
        optionOneCost.text = "<color=#3232ffff>" + tier.OptionOneCosts.x + "</color> - <color=#327e15ff>" + tier.OptionOneCosts.y + "</color> - <color=#c13232ff>" + tier.OptionOneCosts.z + "</color>";
        optionTwoCost.text = "<color=#3232ffff>" + tier.OptionTwoCosts.x + "</color> - <color=#327e15ff>" + tier.OptionTwoCosts.y + "</color> - <color=#c13232ff>" + tier.OptionTwoCosts.z + "</color>";

        totalStatsSpent.text = "<color=#3232ffff>" + GameManager.Instance.CurrentCrimeStats.x + "</color> - <color=#327e15ff>" + GameManager.Instance.CurrentCrimeStats.y + "</color> - <color=#c13232ff>" + GameManager.Instance.CurrentCrimeStats.z + "</color>";

        smartsText.text = GameManager.Instance.CurrentPlayerObj.Smarts.ToString() + Constants.ARROW + (GameManager.Instance.CurrentPlayerObj.Smarts - smartsSlider.value).ToString();
        moxieText.text = GameManager.Instance.CurrentPlayerObj.Moxie.ToString() + Constants.ARROW + (GameManager.Instance.CurrentPlayerObj.Moxie - moxieSlider.value).ToString();
        muscleText.text = GameManager.Instance.CurrentPlayerObj.Muscle.ToString() + Constants.ARROW + (GameManager.Instance.CurrentPlayerObj.Muscle - muscleSlider.value).ToString();

        ResetButton();
    }

    public void SmartsSliderChanged()
    {
        if (SliderSum > totalThreshold || GameManager.Instance.CurrentPlayerObj.Smarts < smartsSlider.value)
            smartsSlider.value--;

        smartsText.text = GameManager.Instance.CurrentPlayerObj.Smarts.ToString() + Constants.ARROW + (GameManager.Instance.CurrentPlayerObj.Smarts - smartsSlider.value).ToString();

        UpdateCosts();
    }

    public void MoxieSliderChanged()
    {
        if (SliderSum > totalThreshold || GameManager.Instance.CurrentPlayerObj.Moxie < moxieSlider.value)
            moxieSlider.value--;

        moxieText.text = GameManager.Instance.CurrentPlayerObj.Moxie.ToString() + Constants.ARROW + (GameManager.Instance.CurrentPlayerObj.Moxie - moxieSlider.value).ToString();

        UpdateCosts();
    }

    public void StrengthSliderChanged()
    {
        if (SliderSum > totalThreshold || GameManager.Instance.CurrentPlayerObj.Muscle < muscleSlider.value)
            muscleSlider.value--;

        muscleText.text = GameManager.Instance.CurrentPlayerObj.Muscle.ToString() + Constants.ARROW + (GameManager.Instance.CurrentPlayerObj.Muscle - muscleSlider.value).ToString();

        UpdateCosts();
    }

    private float SliderSum
    {
        get { return smartsSlider.value + moxieSlider.value + muscleSlider.value; }
    }

    public void UpdateCosts()
    {
        totalStatsSpent.text = "<color=#3232ffff>" + (GameManager.Instance.CurrentCrimeStats.x + smartsSlider.value) + "</color> - <color=#327e15ff>" + (GameManager.Instance.CurrentCrimeStats.y + moxieSlider.value) + "</color> - <color=#c13232ff>" + (GameManager.Instance.CurrentCrimeStats.z + muscleSlider.value) + "</color>";
    }

    public void ResetButton()
    {
        smartsSlider.value = 0;
        moxieSlider.value = 0;
        muscleSlider.value = 0;

        UpdateCosts();
    }

    public void CommitChanges()
    {
        if (SliderSum <= totalThreshold && SliderSum > 0)
        {
            UIManager.instance.ChangeMajorCrimeCommit(new Vector3(smartsSlider.value, moxieSlider.value, muscleSlider.value));
        }
    }
}