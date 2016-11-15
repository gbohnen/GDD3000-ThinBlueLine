namespace Assets.Scripts
{
    /// <summary>
    /// 
    /// </summary>
    public class TutorialScript
    {
        #region Fields

        string page0;
        string page1;
        string page2;
        string page3;
        string page4;
        string page5;
        string page6;
        string page7;
        string page8;
        string page9;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the page
        /// </summary>
        public string Page0
        {
            get { return page0; }
        }
        /// <summary>
        /// Gets the page
        /// </summary>
        public string Page1
        {
            get { return page1; }
        }

        /// <summary>
        /// Gets the page
        /// </summary>
        public string Page2
        {
            get { return page2; }
        }

        /// <summary>
        /// Gets the page
        /// </summary>
        public string Page3
        {
            get { return page3; }
        }
        /// <summary>
        /// Gets the page
        /// </summary>
        public string Page4
        {
            get { return page4; }
        }
        /// <summary>
        /// Gets the page
        /// </summary>
        public string Page5
        {
            get { return page5; }
        }
        /// <summary>
        /// Gets the page
        /// </summary>
        public string Page6
        {
            get { return page6; }
        }
        /// <summary>
        /// Gets the page
        /// </summary>
        public string Page7
        {
            get { return page7; }
        }
        /// <summary>
        /// Gets the page
        /// </summary>
        public string Page8
        {
            get { return page8; }
        }
        /// <summary>
        /// Gets the page
        /// </summary>
        public string Page9
        {
            get { return page9; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public TutorialScript(LoadGameData.Tutorial data)
        {
            page0 = data.page0;
            page1 = data.page1;
            page2 = data.page2;
            page3 = data.page3;
            page4 = data.page4;
            page5 = data.page5;
            page6 = data.page6;
            page7 = data.page7;
            page8 = data.page8;
            page9 = data.page9;
        }

        #endregion
    }
}