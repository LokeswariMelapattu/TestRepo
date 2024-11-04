namespace DUC.CMS.CustomerService.EventLogger.Interfaces
{
    using Enumerations;

    public interface ILoggerFacade
    {
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="eventType">Type of the event.</param>
        void Log(string message, LoggerEventType eventType);

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        void LogException(string ex);
    }
}
