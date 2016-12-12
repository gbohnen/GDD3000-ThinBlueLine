using System.Collections.Generic;

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

                    // if (drastic (>5) change in stat with greatest change, which should be calculated above)
                    // set temp to be drastic line 
                    // else
                    temp = neighborhood.Key.ToString() + ": " + dialogueOptions[Mood][index].Replace("@", "<b>" + stat + "</b>");
                }
                else
                {

                }

                dialogue.Add(temp);
            }

            return dialogue;
        }

        public List<string> BuildMajorCrimeReport(bool option)
        {
            List<string> result = new List<string>();

            string temp = string.Empty;

            if (option == true)
            {
                result.Add("Great choice! Lets take a look at the result: ");
                temp = GameManager.Instance.majorCrime.CrimeTiers[GameManager.Instance.majorCrime.CurrentTier].OptionOneResult;
            }
            else
            {
                result.Add("I like your style! Here's how it turned out: ");
                temp = GameManager.Instance.majorCrime.CrimeTiers[GameManager.Instance.majorCrime.CurrentTier].OptionTwoResult;
            }

            result.Add(temp);

            return result;
        }

        #endregion
    }
}