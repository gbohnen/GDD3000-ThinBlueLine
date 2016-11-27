using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;

public class TierObject : MonoBehaviour {

    public Text header;
    public Text blurb;
    public Text immediateEffect;
    public Text optionOne;
    public Text optionOneCost;
    public Text optionOneDesc;
    public Text optionTwo;
    public Text optionTwoCost;
    public Text optionTwoDesc;

    public void LoadTier(MajorCrimeTier data)
    {
        // header = data.header
        immediateEffect.text = data.CrimeEffectText;
        // optionOne = data.
        //optionOneCost.text = new string();
        optionOneDesc.text = data.OptionOneText;
        // optionTwo = data.
        //optionTwoCost.text = new string();
        optionTwoDesc.text = data.OptionTwoText;
    }

}
