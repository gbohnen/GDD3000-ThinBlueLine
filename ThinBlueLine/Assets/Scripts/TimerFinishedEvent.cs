namespace Assets.Scripts
{
    /// <summary>
    /// The delegate for handling the event
    /// </summary>
    public delegate void TimerFinishedEventHandler();

    /// <summary>
    /// An event which indicates that a timer has finished
    /// </summary>
    class TimerFinishedEvent
    {
        // the event handler registered to the event
        event TimerFinishedEventHandler eventHandlers;

        #region Public Methods

        /// <summary>
        /// Register the given event handler
        /// </summary>
        /// <param name="handler">the event handler</param>
        public void Register(TimerFinishedEventHandler handler)
        {
            eventHandlers += handler;
        }

        /// <summary>
        /// Fire the event for all event handlers
        /// </summary>
        public void FireEvent()
        {
            // check if the handlers are null
            if (eventHandlers != null)
            { eventHandlers(); }
        }

        #endregion
    }
}