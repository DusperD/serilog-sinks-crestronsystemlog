using Crestron.SimplSharp;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using System;

namespace serilog_sinks_crestronsystemlog
{
    public class CrestronSystemSink : ILogEventSink
    {
        private readonly ITextFormatter _formatter;

        public CrestronSystemSink(ITextFormatter formatter)
        {
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }
        public void Emit(LogEvent logEvent)
        {
            using (var buffer = new System.IO.StringWriter())
            {
                _formatter.Format(logEvent, buffer);
                if (logEvent.Level == LogEventLevel.Debug)
                {
                    ErrorLog.Notice(buffer.ToString());

                }
                else if (logEvent.Level == LogEventLevel.Information)
                {
                    ErrorLog.Notice(buffer.ToString());

                }
                else if (logEvent.Level == LogEventLevel.Warning)
                {
                    ErrorLog.Warn(buffer.ToString());

                }
                else if (logEvent.Level == LogEventLevel.Error)
                {
                    ErrorLog.Error(buffer.ToString());

                }
                else if (logEvent.Level == LogEventLevel.Fatal)
                {
                    ErrorLog.Error(buffer.ToString());

                }
                else if (logEvent.Level == LogEventLevel.Verbose)
                {
                    ErrorLog.Error(buffer.ToString());

                }

            }





        }
    }
}
