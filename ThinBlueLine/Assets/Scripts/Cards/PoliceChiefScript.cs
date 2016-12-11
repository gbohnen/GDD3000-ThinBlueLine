namespace Assets.Scripts
{
    /// <summary>
    /// An enumeration for the different moods of the police chief
    /// </summary>
    public enum CurrentMood { Angry, Happy, Worried, Suspicious }

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
        int openSituations = 0;

        // mood weights
        float worriedWeight = 0.3f;
        float angryWeight = 0.5f;
        float suspisciousWeight = 0.7f;
        float happyWeight = 0.9f;

        int number = 0;

        CurrentMood mood = CurrentMood.Happy;

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

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public PoliceChiefScript() : base()
        { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Does nothing, play continues
        /// </summary>
        public void DoNothing()
        { }

        /// <summary>
        /// Reveals a situation to a random neighborhood
        /// </summary>
        public void RevealSituation()
        { }

        /// <summary>
        /// Increases random player(s) reputation within a random neighborhood
        /// </summary>
        public void GrantComm()
        { }

        /// <summary>
        /// Increases each players stats between specified amount (1 and 3)
        /// </summary>
        public void RewardInves()
        { }

        /// <summary>
        /// Investigates a random player, forcing that player to only take 1 Action
        /// </summary>
        public void IntAffairs()
        { }

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
            { suspicious++;}
            if (timesChangedNeigh < situationsResolved + situationsDrawn + timesLoweredCrime)
            { suspicious--; }

            // HAPPY
            if (overallStatLevel < 7 && overallCrimeLevel < 7 && openSituations < 7)
            { happy++; }
            if (overallStatLevel > 7 && overallCrimeLevel > 7 && openSituations > 7)
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
        
        #endregion
    }
}