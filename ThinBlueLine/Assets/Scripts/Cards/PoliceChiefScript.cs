using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// An enumeration for the different moods of the police chief
    /// </summary>
    public enum CurrentMood { Angry, Happy, Worried, Suspicious, Drastic }

    /// <summary>
    /// Script which handles the police chief
    /// </summary>
    public class PoliceChiefScript : CardScript
    {
        #region Fields

        // store the different moods the police chief holds
        float angry;
        float happy;
        float worried;
        float suspicious;

        // mood weights
        float worriedWeight = 0.3f;
        float angryWeight = 0.5f;
        float suspisciousWeight = 0.7f;
        float happyWeight = 0.9f;

        int number = 0;
        CurrentMood mood = CurrentMood.Happy;
        Dictionary<CurrentMood, List<string>> dialogueOptions;

        // stats array
        int[,] stats = new int[3, 6];

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current mood
        /// </summary>
        public CurrentMood Mood
        {
            get { return mood; }
            set { mood = value; }
        }

        #endregion

        #region Public Methods

        public PoliceChiefScript()
        {
            dialogueOptions = new Dictionary<CurrentMood, List<string>>();
            dialogueOptions = LoadGameData.LoadChiefAdvice();

            SetStats();
        }

        /// <summary>
        /// Calculates the mood of the police chief
        /// </summary>
        public void CalculateMood()
        {
            // ANGRY
            if (StatTracker.DrawnSituations(0) > 2 * (StatTracker.ResolvedSituations + 2))
            { angry++; }
            if (StatTracker.DrawnSituations(0) == StatTracker.ResolvedSituations)
            { angry--; }

            // SUSPISCIOUS
            if (StatTracker.TimesChangedNeighborhood(0) > StatTracker.ResolvedSituations + StatTracker.DrawnSituations(0) + StatTracker.TimesLoweredCrime(0))
            { suspicious++; }
            if (StatTracker.TimesChangedNeighborhood(0) < StatTracker.ResolvedSituations + StatTracker.DrawnSituations(0) + StatTracker.TimesLoweredCrime(0))
            { suspicious--; }

            // HAPPY
            if ( (GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Chaos + GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Corruption + GameLibrary.instance.Neighborhoods[Neighborhood.Overall].MafiaPresence) < 7 && StatTracker.UnresolvedSituations < 7)
            { happy++; }
            if ((GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Chaos + GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Corruption + GameLibrary.instance.Neighborhoods[Neighborhood.Overall].MafiaPresence) > 7 && StatTracker.UnresolvedSituations > 7)
            { happy--; }

            // WORRIED
            if (StatTracker.UnresolvedSituations > 10 && GameManager.Instance.majorCrime.CurrentTier > 3)
            { worried++; }
            if (StatTracker.UnresolvedSituations < 10 && GameManager.Instance.majorCrime.currentTier < 3)
            { worried--; }

            // WORRIED
            int mood0 = (int)(worried * worriedWeight);
            if (mood0 > number)
            {
                number = mood0;
                Mood = CurrentMood.Worried;
            }

            // ANGRY
            int mood1 = (int)(angry * angryWeight);
            if (mood1 > number)
            {
                number = mood1;
                Mood = CurrentMood.Angry;
            }

            // SUSPICIOUS
            int mood2 = (int)(suspicious * suspisciousWeight);
            if (mood2 > number)
            {
                number = mood2;
                Mood = CurrentMood.Suspicious;
            }

            // HAPPY
            int mood3 = (int)(happy * happyWeight);
            if (mood3 > number)
            {
                number = mood3;
                Mood = CurrentMood.Happy;
            }
        }

        public List<string> BuildChiefReport()
        {
            CalculateMood();

            List<string> dialogue = new List<string>();

            dialogue.Add("Ongoing effects triggered...");
            
            // for each neighborhood
            foreach (KeyValuePair<Neighborhood, NeighborhoodData> neighborhood in GameLibrary.instance.Neighborhoods)
            {
                string temp = "";

                if (neighborhood.Key != Neighborhood.Overall)
                {
                    // choose line
                    int index = 0;
                    if (neighborhood.Value.Chaos + neighborhood.Value.Corruption + neighborhood.Value.MafiaPresence > 9)
                        index = 2;
                    else if (neighborhood.Value.Chaos + neighborhood.Value.Corruption + neighborhood.Value.MafiaPresence > 4)
                        index = 1;
                    else
                        index = 0;

                    // choose stat
                    string stat = "";
                    if (neighborhood.Value.Corruption >= neighborhood.Value.Chaos && neighborhood.Value.Corruption >= neighborhood.Value.MafiaPresence)
                        stat = "Corruption";
                    else if (neighborhood.Value.MafiaPresence >= neighborhood.Value.Chaos && neighborhood.Value.MafiaPresence >= neighborhood.Value.Corruption)
                        stat = "Mafia Presence";
                    else if (neighborhood.Value.Chaos >= neighborhood.Value.MafiaPresence && neighborhood.Value.Chaos >= neighborhood.Value.Corruption)
                        stat = "Chaos";

<<<<<<< HEAD
                    // corruption
                    if (neighborhood.Value.Corruption - stats[1, (int)neighborhood.Key] > 5)
                    {
                        temp = neighborhood.Key.ToString() + ": " + dialogueOptions[CurrentMood.Drastic][0].Replace("@", "<b>" + stat + "</b>").Replace("%", "<b>" + neighborhood.Key + "</b>");
                    }
                    else if (neighborhood.Value.Corruption - stats[1, (int)neighborhood.Key] < 5)
                    {
                        temp = neighborhood.Key.ToString() + ": " + dialogueOptions[CurrentMood.Drastic][1].Replace("@", "<b>" + stat + "</b>").Replace("%", "<b>" + neighborhood.Key + "</b>");
                    }
                    // chaos
                    if (neighborhood.Value.Chaos - stats[1, (int)neighborhood.Key] > 5)
                    {
                        temp = neighborhood.Key.ToString() + ": " + dialogueOptions[CurrentMood.Drastic][0].Replace("@", "<b>" + stat + "</b>").Replace("%", "<b>" + neighborhood.Key + "</b>");
                    }
                    else if (neighborhood.Value.Chaos - stats[1, (int)neighborhood.Key] < 5)
                    {
                        temp = neighborhood.Key.ToString() + ": " + dialogueOptions[CurrentMood.Drastic][1].Replace("@", "<b>" + stat + "</b>").Replace("%", "<b>" + neighborhood.Key + "</b>");
                    }
                    // mafia presence
                    if (neighborhood.Value.MafiaPresence - stats[1, (int)neighborhood.Key] > 5)
                    {
                        temp = neighborhood.Key.ToString() + ": " + dialogueOptions[CurrentMood.Drastic][0].Replace("@", "<b>" + stat + "</b>").Replace("%", "<b>" + neighborhood.Key + "</b>");
                    }
                    else if (neighborhood.Value.MafiaPresence - stats[1, (int)neighborhood.Key] < 5)
                    {
                        temp = neighborhood.Key.ToString() + ": " + dialogueOptions[CurrentMood.Drastic][1].Replace("@", "<b>" + stat + "</b>").Replace("%", "<b>" + neighborhood.Key + "</b>");
                    }
                    // else
                    else
                    {
                        temp = neighborhood.Key.ToString() + ": " + dialogueOptions[Mood][index].Replace("@", "<b>" + stat + "</b>");
                    }
=======
                    // if (drastic (>5) change in stat with greatest change, which should be calculated above)
                    // set temp to be drastic line 
                    // else
                    temp = neighborhood.Key.ToString() + ": " + dialogueOptions[Mood][index].Replace("@", "<b>" + stat + "</b>");
>>>>>>> origin/master
                }
                else
                { }

                dialogue.Add(temp);
            }

            SetStats();

            return dialogue;
        }

        /// <summary>
        /// Sets the stats
        /// </summary>
        public void SetStats()
        {
            // stony gate
            stats[0, 0] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.StonyGate].Corruption;
            stats[1, 0] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.StonyGate].Chaos;
            stats[2, 0] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.StonyGate].MafiaPresence;

            // suburbia
            stats[0, 1] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.Suburbia].Corruption;
            stats[1, 1] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.Suburbia].Chaos;
            stats[2, 1] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.Suburbia].MafiaPresence;

            // downtown
            stats[0, 2] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.Downtown].Corruption;
            stats[1, 2] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.Downtown].Chaos;
            stats[2, 2] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.Downtown].MafiaPresence;

            // boxes
            stats[0, 3] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.TheBoxes].Corruption;
            stats[1, 3] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.TheBoxes].Chaos;
            stats[2, 3] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.TheBoxes].MafiaPresence;

            // portside
            stats[0, 4] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.Portside].Corruption;
            stats[1, 4] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.Portside].Chaos;
            stats[2, 4] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.Portside].MafiaPresence;

            // overall
            stats[0, 5] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Corruption;
            stats[1, 5] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Chaos;
            stats[2, 5] = (int)GameLibrary.instance.Neighborhoods[Neighborhood.Overall].MafiaPresence;
        }

        public List<string> BuildMajorCrimeReport(bool option)
        {
            List<string> result = new List<string>();

            if (!option)
            {
				result.Add(GameManager.Instance.majorCrime.CrimeTiers[GameManager.Instance.CurrentCrimeTier].OptionOneText.Substring(0, GameManager.Instance.majorCrime.CrimeTiers[GameManager.Instance.CurrentCrimeTier].OptionOneText.IndexOf(':')));
                result.Add("Great choice! Lets take a look at the result: ");
				result.Add(GameManager.Instance.majorCrime.CrimeTiers[GameManager.Instance.CurrentCrimeTier].OptionOneResult);
            }
            else
			{
				result.Add(GameManager.Instance.majorCrime.CrimeTiers[GameManager.Instance.CurrentCrimeTier].OptionTwoText.Substring(0, GameManager.Instance.majorCrime.CrimeTiers[GameManager.Instance.CurrentCrimeTier].OptionTwoText.IndexOf(':')));
                result.Add("I like your style! Here's how it turned out: ");
				result.Add(GameManager.Instance.majorCrime.CrimeTiers[GameManager.Instance.CurrentCrimeTier].OptionTwoResult);
            }

            return result;
        }

        #endregion
    }
}