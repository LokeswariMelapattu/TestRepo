using DUC.CMS.CustomerService.EventLogger.Enumerations;
using DUC.CMS.CustomerService.EventLogger.Interfaces;
using System;
using System.Diagnostics;
using DUC.CMS.CustomerService.BLL;

namespace DUC.CMS.CustomerService.EventLogger
{
    public class EventLogger : ILoggerFacade
    {
        private EventLog _eventLog;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventLogger"/> class.
        /// </summary>
        /// <param name="applicationName">Name of the application.</param>
        public EventLogger(string applicationName)
        {
            _eventLog = new EventLog(applicationName);
            _eventLog.Source = applicationName;
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Log(string message, LoggerEventType eventType)
        {
            switch (eventType)
            {
                case LoggerEventType.Error:
                    try
                    {
                        _eventLog.WriteEntry(message, EventLogEntryType.Error);
                    }
                    catch(Exception ex)
                    {
                        LogException(ex.InnerException !=null ? ex.InnerException.Message.ToString() + ", Message---->" + ex.Message.ToString() : "Message---->" + ex.Message.ToString());
                    }
                    LogException(message);
                    break;
                case LoggerEventType.Failure:
                    _eventLog.WriteEntry(message, EventLogEntryType.FailureAudit);
                    LogException(message);
                    break;
                case LoggerEventType.Info:
                    _eventLog.WriteEntry(message, EventLogEntryType.Information);
                    LogException(message);
                    break;
                case LoggerEventType.Success:
                   _eventLog.WriteEntry(message, EventLogEntryType.SuccessAudit);
                    LogException(message);
                    break;
            }
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void LogException(string messageToLog)
        {
            CustomerAppService _app = new CustomerAppService();
           // var messageToLog = string.Format("Message: {0}, Stack Trace: {1}, Inner Exception: {2}", ex.Message, ex.StackTrace, ex.InnerException != null ? ex.InnerException.StackTrace : string.Empty);
            _app.EventLog(DateTime.Now, System.Configuration.ConfigurationManager.AppSettings["ApplicationName"].ToString(), 1, messageToLog, messageToLog);
           // _eventLog.WriteEntry(messageToLog, EventLogEntryType.Error);
        }
    }
}
