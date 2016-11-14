using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;

public class ResolveSituationCard : MonoBehaviour {

    // ui fields
    public Text smartsText;
    public Text moxieText;
    public Text muscleText;
    public Slider smartsSlider;
    public Slider moxieSlider;
    public Slider muscleSlider;

    // caluclation fields
    public Text currentCost;
    public Text smartsInp;
    public Text smartsMod;
    public Text smartsRes;
    public Text moxieInp;
    public Text moxieMod;
    public Text moxieRes;
    public Text muscleInp;
    public Text muscleMod;
    public Text muscleRes;
    public Text futureCost;

    float totalThreshold = 3.0f;
    string arrow = " -> ";

    SituationScript situation;

    public void LoadSituation(SituationScript sitch)
    {
        situation = sitch;

        smartsText.text = GameManager.Instance.CurrentPlayerObj.Smarts.ToString() + arrow + GameManager.Instance.CurrentPlayerObj.Smarts.ToString();
        moxieText.text = GameManager.Instance.CurrentPlayerObj.Moxie.ToString() + arrow + GameManager.Instance.CurrentPlayerObj.Moxie.ToString();
        muscleText.text = GameManager.Instance.CurrentPlayerObj.Strength.ToString() + arrow + GameManager.Instance.CurrentPlayerObj.Strength.ToString();

        ResetButton();
    }

    public void SmartsSliderChanged()
    {
        if (SliderSum > totalThreshold || GameManager.Instance.CurrentPlayerObj.Smarts < smartsSlider.value)
            smartsSlider.value--;

        smartsText.text = GameManager.Instance.CurrentPlayerObj.Smarts.ToString() + arrow + (GameManager.Instance.CurrentPlayerObj.Smarts - smartsSlider.value).ToString();

        UpdateCalculations();
    }

    public void MoxieSliderChanged()
    {
        if (SliderSum > totalThreshold || GameManager.Instance.CurrentPlayerObj.Moxie < moxieSlider.value)
            moxieSlider.value--;

        moxieText.text = GameManager.Instance.CurrentPlayerObj.Moxie.ToString() + arrow + (GameManager.Instance.CurrentPlayerObj.Moxie - moxieSlider.value).ToString();

        UpdateCalculations();
    }

    public void StrengthSliderChanged()
    {
        if (SliderSum > totalThreshold || GameManager.Instance.CurrentPlayerObj.Strength < muscleSlider.value)
            muscleSlider.value--;

        muscleText.text = GameManager.Instance.CurrentPlayerObj.Strength.ToString() + arrow + (GameManager.Instance.CurrentPlayerObj.Strength - muscleSlider.value).ToString();

        UpdateCalculations();
    }

    private float SliderSum
    {
        get { return smartsSlider.value + moxieSlider.value + muscleSlider.value; }
    }

    private void UpdateCalculations()
    {
        currentCost.text = "Current Cost: " + situation.Cost;

        smartsInp.text = smartsSlider.value.ToString();
        smartsMod.text = "x " + situation.SmartsModifier.ToString();
        smartsRes.text = (smartsSlider.value * situation.SmartsModifier).ToString();

        moxieInp.text = moxieSlider.value.ToString();
        moxieMod.text = "x " + situation.MoxieModifier.ToString();
        moxieRes.text = (moxieSlider.value * situation.MoxieModifier).ToString();

        muscleInp.text = muscleSlider.value.ToString();
        muscleMod.text = "x " + situation.MoxieModifier.ToString();
        muscleRes.text = (muscleSlider.value * situation.MuscleModifier).ToString();

        futureCost.text = "New Cost: " + (situation.Cost - CostReduction()).ToString();
    }

    private float CostReduction()
    {        
        float i = smartsSlider.value * situation.SmartsModifier + moxieSlider.value * situation.MoxieModifier + muscleSlider.value * situation.MuscleModifier;

        if (i < 0)
            i = 0;

        return i;
    }

    public void ResetButton()
    {
        smartsSlider.value = 0;
        moxieSlider.value = 0;
        muscleSlider.value = 0;

        UpdateCalculations();
    }

    public void CommitChanges()
    {
        if (SliderSum <= totalThreshold)
        {
            GameManager.Instance.SituationResolved(smartsSlider.value, moxieSlider.value, muscleSlider.value);

            UIManager.instance.ReduceSituation(CostReduction());
            UIManager.instance.CloseWindows();

            GameManager.Instance.LogAction("Situation Resolved");
        }
    }
}