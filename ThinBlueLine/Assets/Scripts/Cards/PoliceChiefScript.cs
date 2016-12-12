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

        // store mood stuff
        int situationsDrawn = 0;
        int situationsResolved = 0;
        int timesLoweredCrime = 0;
        int timesChangedNeigh = 0;
        int unresolvedSituations = 0;
        int currentMajorCrimeTier = 0;
        int overallStatLevel = 0;
        int overallCrimeLevel = 0;

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
            if (situationsDrawn > 2 * (situationsResolved + 2))
            { angry++; }
            if (situationsDrawn == situationsResolved)
            { angry--; }

            // SUSPISCIOUS
            if (timesChangedNeigh > situationsResolved + situationsDrawn + timesLoweredCrime)
            { suspicious++; }
            if (timesChangedNeigh < situationsResolved + situationsDrawn + timesLoweredCrime)
            { suspicious--; }

            // HAPPY
            if (overallStatLevel < 7 && overallCrimeLevel < 7 && unresolvedSituations < 7)
            { happy++; }
            if (overallStatLevel > 7 && overallCrimeLevel > 7 && unresolvedSituations > 7)
            { happy--; }

            // WORRIED
            if (unresolvedSituations > 10 && currentMajorCrimeTier > 3)
            { worried++; }
            if (unresolvedSituations < 10 && currentMajorCrimeTier < 3)
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

                    temp = neighborhood.Key.ToString() + ": " + dialogueOptions[Mood][index].Replace("@", "<b>" + stat + "</b>");
                }
                else
                {

                }

                dialogue.Add(temp);
            }

            return dialogue;
        }

        #endregion
    }
}