using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// Script which handles tool tips in the game
    /// </summary>
    public class ToolTipScript : MonoBehaviour
    {
        #region Fields

        // store the text on the tip display
        Text tipDisplay;

        // store the tips canvas group
        CanvasGroup canvasGroup;
        public GameObject toolTipCanvas;

        // timers for the tips display
        Timer tipDisplayDelay;
        Timer tipSwitchDelay;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the general tip
        /// </summary>
        public string GeneralTip
        { get; set; }

        /// <summary>
        /// Gets or sets the descriptive tip
        /// </summary>
        public string DescriptiveTip
        { get; set; }

        /// <summary>
        /// Gets or sets the scale of the tool tip
        /// </summary>
        public Vector2 Scale
        {
            get { return transform.localScale; }
            set { transform.localScale = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes the tool tip thats diplayed on MouseOver
        /// </summary>
        /// <param name="objectToDescribe">the object the tool tip describes</param>
        /// <param name="generalTip">the general tip</param>
        /// <param name="descriptiveTip">the descriptive tip</param>
        public void Initialize(RectTransform objectToDescribe, string generalTip, string descriptiveTip)
        {
            // set the world camera
            GetComponent<Canvas>().worldCamera = Camera.main;

            // initialize the delay timers
            tipDisplayDelay = new Timer(Constants.GENERAL_TIP_DELAY);
            tipSwitchDelay = new Timer(Constants.DESCRIPTIVE_TIP_DELAY);

            // register the timers the correct events
            tipDisplayDelay.Register(DisplayToolTip);
            tipSwitchDelay.Register(DisplayDescriptiveTip);

            transform.SetParent(objectToDescribe, false);
            Image descriptionImage = objectToDescribe.GetComponent<Image>();
            GetComponent<RectTransform>().anchoredPosition = descriptionImage ?
                new Vector2(0.0f, descriptionImage.sprite.bounds.extents.y * 2) :
                new Vector2(0.0f, objectToDescribe.sizeDelta.y * 0.15f);

            // set the tips
            GeneralTip = generalTip;
            DescriptiveTip = descriptiveTip;

            // grab the text & canvas group components
            tipDisplay = GetComponent<Text>();
            canvasGroup = GetComponent<CanvasGroup>();

            // set the text of the tip
            tipDisplay.text = generalTip;

            // start the tip delay timer
            tipDisplayDelay.StartTimer();
        }

        /// <summary>
        /// Initializes the tool tip thats displayed on MouseOver
        /// </summary>
        /// <param name="generalTip">the general tip</param>
        /// <param name="descriptiveTip">the descriptive tip</param>
        public virtual void Initialize(string generalTip, string descriptiveTip)
        {
            // set the world camera
            GetComponent<Canvas>().worldCamera = Camera.main;

            // initialize the delay timers
            tipDisplayDelay = new Timer(Constants.GENERAL_TIP_DELAY);
            tipSwitchDelay = new Timer(Constants.DESCRIPTIVE_TIP_DELAY);

            // register the timers the correct events
            tipDisplayDelay.Register(DisplayToolTip);
            tipSwitchDelay.Register(DisplayDescriptiveTip);

            // set the parent of the tip
            transform.SetParent(toolTipCanvas.transform, false);

            // get the position of the mouse
            Vector3 position = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            // grab the rect from the canvas
            Rect rect = toolTipCanvas.GetComponent<RectTransform>().rect;

            // set position
            position = new Vector3(position.x * rect.width - 0.5f * rect.width,
                                   position.y * rect.height - rect.height, 0.0f);

            // grab the rect transforms anchored position and set it
            GetComponent<RectTransform>().anchoredPosition = position;

            // set the tips
            GeneralTip = generalTip;
            DescriptiveTip = descriptiveTip;

            // grab the text & canvas group components
            tipDisplay = GetComponent<Text>();
            canvasGroup = GetComponent<CanvasGroup>();

            // set the text of the tip
            tipDisplay.text = generalTip;

            // start the tip delay timer
            tipDisplayDelay.StartTimer();
        }

        /// <summary>
        /// Initializes the tool tip
        /// </summary>
        /// <param name="objectToDescribe">the object the tool tip describes</param>
        public void Initialize(RectTransform objectToDescribe)
        {
            // grab the canvas group component
            canvasGroup = GetComponent<CanvasGroup>();

            // initialize the delay timers
            tipDisplayDelay = new Timer(Constants.GENERAL_TIP_DELAY);
            tipSwitchDelay = new Timer(Constants.DESCRIPTIVE_TIP_DELAY);

            // register the timers the correct events
            tipDisplayDelay.Register(DisplayToolTip);
            tipSwitchDelay.Register(DisplayDescriptiveTip);

            // set the parent of the transform and position of tool tip
            transform.SetParent(objectToDescribe, false);
            GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f,
                objectToDescribe.GetComponent<Image>().sprite.bounds.extents.y);
        }

        /// <summary>
        /// Displays the tool tip
        /// </summary>
        public virtual void DisplayToolTip()
        {
            // starts the coroutine to fade in the tool tip, start the switch delay timer
            StartCoroutine(FadeInToolTip());
            tipSwitchDelay.StartTimer();
        }

        /// <summary>
        /// Stops the display of the tool tip
        /// </summary>
        public void StopDisplay()
        {
            // stop the display delay timer
            tipDisplayDelay.StopTimer();
        }

        /// <summary>
        /// Updates the delay timer
        /// </summary>
        public void Update()
        {
            // if the tip display delay is not null, update the tip
            if (tipDisplayDelay != null)
            { tipDisplayDelay.Update(); }
            // if the tip switch delay is not null, update the tip
            if (tipSwitchDelay != null)
            { tipSwitchDelay.Update(); }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Displays the descriptive tool tip
        /// </summary>
        private void DisplayDescriptiveTip()
        {
            // starts the coroutine to display the tool tip
            StartCoroutine(ModifyToolTip());
        }

        #endregion

        #region Coroutines

        /// <summary>
        /// Modifies the tool tip to display the correct tip
        /// </summary>
        public virtual IEnumerator ModifyToolTip()
        {
            // if descriptive tip is not empty
            if (DescriptiveTip != string.Empty)
            {
                // fade out the tool tip
                yield return FadeOutToolTip();

                // set the text of the tip
                tipDisplay.text = DescriptiveTip;

                // fade in the tool tip
                yield return FadeInToolTip();
            }
            // descriptive tip is empty
            else
            { yield return null; }
        }

        /// <summary>
        /// Fades the tool tip in
        /// </summary>
        protected IEnumerator FadeInToolTip()
        {
            // while the tips alpha is less than the threshold
            while (canvasGroup.alpha < Constants.TOOL_TIP_FADE_IN_THRESHOLD)
            {
                // set alpha
                canvasGroup.alpha += Constants.TOOL_TIP_FADE_TIME * Time.deltaTime;
                yield return null;
            }

            // set alpha
            canvasGroup.alpha = 1.0f;
        }

        /// <summary>
        /// Fades the tool tip out
        /// </summary>
        protected IEnumerator FadeOutToolTip()
        {
            // while the tips alpha is greater than the threshold
            while (canvasGroup.alpha > Constants.TOOL_TIP_FADE_OUT_THRESHOLD)
            {
                // set alpha
                canvasGroup.alpha -= Constants.TOOL_TIP_FADE_TIME * Time.deltaTime;
                yield return null;
            }

            // set alpha
            canvasGroup.alpha = 0.0f;
        }

        #endregion
    }
}