using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts
{
    public class DrawSituationCard : MonoBehaviour {

        // UI fields
        public Text situationName;
        public Text cost;
        public Text smartsMod;
        public Text moxieMod;
        public Text musclesMod;
        public Text posResolution;
        public Text negResolution;
        public Text desc;
        public Text immEffect;
        public Text ongEffect;

        public Slider smartsSlider;
        public Slider moxieSlider;
        public Slider muscleSlider;

		SituationScript situation;

        float totalThreshold = 3.0f;

        public void Initialize(SituationScript sitch)
        {
            // set all ui fields based on the situation we were given
            situationName.text = sitch.Name;
            cost.text = "Cost:           " + sitch.Cost.ToString();
            smartsMod.text = "x " + sitch.SmartsModifier.ToString();
            moxieMod.text = "x " + sitch.MoxieModifier.ToString();
            musclesMod.text = "x " + sitch.MuscleModifier.ToString();
            posResolution.text = sitch.PositiveOutcome;
            negResolution.text = sitch.NegativeOutcome;
            desc.text = sitch.Description;
            immEffect.text = sitch.ImmediateEffect;
            ongEffect.text = sitch.OngoingEffect;

			situation = sitch;

            GameManager.Instance.LogAction("Situation Drawn");
        }

        private float SliderSum
        {
            get { return smartsSlider.value + moxieSlider.value + muscleSlider.value; }
        }

        public void SmartsSliderChanged()
        {
            if (SliderSum > totalThreshold)
                smartsSlider.value--;
        }

        public void MoxieSliderChanged()
        {
            if (SliderSum > totalThreshold)
                moxieSlider.value--;
        }

        public void StrengthSliderChanged()
        {
            if (SliderSum > totalThreshold)
                muscleSlider.value--;
        }

        public void ConfirmSituationDraw()
        {
            if (smartsSlider.value + moxieSlider.value + muscleSlider.value == totalThreshold)
            {
                GameManager.Instance.SituationDrawn(smartsSlider.value, moxieSlider.value, muscleSlider.value);

                smartsSlider.value = 0;
                moxieSlider.value = 0;
                muscleSlider.value = 0;

				if (situation.Cost <= 0) 
				{
					UIManager.instance.CloseSituation (situation.Name);
				}

				situation.TriggerImmediate ();

                UIManager.instance.CloseWindows();
            }
        }
    }
}
