namespace Assets.Scripts
{
    /// <summary>
    /// Script which handles the situations in the game
    /// </summary>
    public class SituationScript : MajorCrimeScript
    {
        #region Fields

        string description;
        string immEffect;
        string ongEffect;
        int cost;
        float smartsModifier;
        float muscleModifier;
        float moxieModifier;
        string positiveOutcome;
        string negativeOutcome;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the description
        /// </summary>
        public string Description
        {
            get { return description; }
        }

        /// <summary>
        /// Gets the immediate effect
        /// </summary>
        public string ImmediateEffect
        {
            get { return immEffect; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OngoingEffect
        {
            get { return ongEffect; }
        }

        /// <summary>
        /// Gets the costs
        /// </summary>
        public int Cost
        {
            get { return cost; }
        }

        /// <summary>
        /// Gets the smarts modifier
        /// </summary>
        public float SmartsModifier
        {
            get { return smartsModifier; }
        }

        /// <summary>
        /// Gets the muscle modifier
        /// </summary>
        public float MuscleModifier
        {
            get { return muscleModifier; }
        }

        /// <summary>
        /// Gets the moxie modifier
        /// </summary>
        public float MoxieModifier
        {
            get { return moxieModifier; }
        }

        /// <summary>
        /// Gets the positive outcome
        /// </summary>
        public string PositiveOutcome
        {
            get { return positiveOutcome; }
        }

        /// <summary>
        /// Gets the negative outcome
        /// </summary>
        public string NegativeOutcome
        {
            get { return negativeOutcome; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public SituationScript(LoadGameData.Situation data) 
            : base()
        {
            cardName = data.name;
            description = data.desc;
            immEffect = data.immEff;
            ongEffect = data.ongEff;

            cost = data.cost;
            smartsModifier = data.smMod;
            muscleModifier = data.musMod;
            moxieModifier = data.moxMod;

            positiveOutcome = data.posOut;
            negativeOutcome = data.negOut;
        }

        #endregion
    }
}