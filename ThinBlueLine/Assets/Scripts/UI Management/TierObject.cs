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

    public MajorCrimeTier data;
    public int level;

    public void LoadTier(int i)
    {
        data = GameManager.Instance.majorCrime.CrimeTiers[i];

        level = i;

        if (data.TierName != null)
            header.text = data.TierName;
        if (data.TierDescription != null)
            blurb.text = data.TierDescription;
        immediateEffect.text = data.CrimeEffectText;

        optionOneCost.text = "<color=#3232ffff>" + data.OptionOneCosts.x + "</color> - <color=#327e15ff>" + data.OptionOneCosts.y + "</color> - <color=#c13232ff>" + data.OptionOneCosts.z + "</color>";
        string[] option1 = data.OptionOneText.Split(new char[] { ':' });
        optionOne.text = option1[0];
        optionOneDesc.text = option1[1];

        if (i < 4)
        {
            optionTwoCost.text = "<color=#3232ffff>" + data.OptionTwoCosts.x + "</color> - <color=#327e15ff>" + data.OptionTwoCosts.y + "</color> - <color=#c13232ff>" + data.OptionTwoCosts.z + "</color>";
            string[] option2 = data.OptionTwoText.Split(new char[] { ':' });
            optionTwo.text = option2[0];
            optionTwoDesc.text = option2[1];
        }
    }

    public void ClickTier()
    {
        UIManager.instance.ResolveTier(level);
    }

}
