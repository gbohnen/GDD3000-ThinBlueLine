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

            GameManager.Instance.LogAction("Situation Drawn");
        }
    }
}
