
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace craftyBuilder.Infrastructure.Logging;
public class SerilogLogger : Domain.Logging.ILogger, IDisposable
{

    public SerilogLogger(IConfiguration config)
    {

        Log.Logger = new LoggerConfiguration()
         .WriteTo.Console()
         .WriteTo.Logger(lc => lc
             .WriteTo.File("log.txt"))
         .CreateLogger();
    }
    public void Write(LogEventLevel level, Exception? ex, string message, params object?[]? propertyValues)
    {
        Serilog.Log.Write(level, ex, message, propertyValues);
    }
    public void Write(LogEvent logEvent)
    {

    }
    public void Write(LogEventLevel level, string message)
    {
        Serilog.Log.Write(level, message);
    }

    public void Write<T>(LogEventLevel level, string message, T propertyValue)
    {
        Serilog.Log.Write(level, message, propertyValue);
    }

    public void Write<T0, T1, T2>(LogEventLevel level, string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Serilog.Log.Write(level, message, propertyValue0, propertyValue1, propertyValue2);
    }
    public void Write(LogEventLevel level, string message, params object?[]? values)
    {
        Serilog.Log.Write(level, message, values);
    }
    public void Write<T>(LogEventLevel level, Exception? ex, string message, T values)
    {
        Serilog.Log.Write(level, message, values);
    }
    public void Write<T0, T1>(LogEventLevel level, Exception? ex, string message, T0 propertyValue0, T1 propertyValue1)
    {
        Serilog.Log.Write(level, ex, message, propertyValue0, propertyValue1);
    }
    public void Write<T0, T1, T2>(LogEventLevel level, Exception? ex, string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Serilog.Log.Write(level, ex, message, propertyValue0, propertyValue1, propertyValue2);
    }

    public void Write<T0, T1>(LogEventLevel level, string message, T0 propertyValue0, T1 propertyValue1)
    {
        Serilog.Log.Write(level, message, propertyValue0, propertyValue1);
    }
    public void Write(LogEventLevel level, Exception? ex, string message)
    {
        Serilog.Log.Write(level, message);
    }

    /// <summary>
    /// Method to log information
    /// </summary>
    /// <param name="message"></param>
    public void LogInformation(string message)
    {
        Serilog.Log.Information(message);
    }

    /// <summary>
    /// Method to log information
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    public void LogInformation(Exception ex, string message)
    {
        Serilog.Log.Information(ex, message);
    }

    /// <summary>
    /// Method to log information
    /// </summary>
    /// <param name="message"></param>
    /// <param name="values"></param>
    public void LogInformation(string message, params object[] values)
    {
        Serilog.Log.Information(message, values);
    }

    /// <summary>
    /// Method to log information
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="values"></param>
    public void LogInformation(Exception ex, string message, params object[] values)
    {
        Serilog.Log.Information(ex, message, values);
    }

    /// <summary>
    /// Method to log information
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="propertyValue"></param>
    public void LogInformation<T>(string message, T propertyValue)
    {
        Serilog.Log.Information(message, propertyValue);
    }

    /// <summary>
    /// Method to log information
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="propertyValue"></param>
    public void LogInformation<T>(Exception ex, string message, T propertyValue)
    {
        Serilog.Log.Information(ex, message, propertyValue);
    }

    /// <summary>
    /// Method to log information
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <param name="message"></param>
    /// <param name="propertyValue0"></param>
    /// <param name="propertyValue1"></param>
    public void LogInformation<T0, T1>(string message, T0 propertyValue0, T1 propertyValue1)
    {
        Serilog.Log.Information(message, propertyValue0, propertyValue1);
    }

    /// <summary>
    /// Method to log information
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="propertyValue0"></param>
    /// <param name="propertyValue1"></param>
    public void LogInformation<T0, T1>(Exception ex, string message, T0 propertyValue0, T1 propertyValue1)
    {
        Serilog.Log.Information(ex, message, propertyValue0, propertyValue1);
    }

    /// <summary>
    /// Method to log information
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="message"></param>
    /// <param name="propertyValue0"></param>
    /// <param name="propertyValue1"></param>
    /// <param name="propertyValue2"></param>
    public void LogInformation<T0, T1, T2>(string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Serilog.Log.Information(message, propertyValue0, propertyValue1, propertyValue2);
    }

    /// <summary>
    /// Method to log information
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="propertyValue0"></param>
    /// <param name="propertyValue1"></param>
    /// <param name="propertyValue2"></param>
    public void LogInformation<T0, T1, T2>(Exception ex, string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Serilog.Log.Information(ex, message, propertyValue0, propertyValue1, propertyValue2);
    }

    /// <summary>
    /// Method to log Error
    /// </summary>
    /// <param name="message"></param>
    public void LogError(string message)
    {
        Serilog.Log.Error(message);
    }
    /// <summary>
    /// Method to log Error
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    public void LogError(Exception ex, string message)
    {
        Serilog.Log.Error(ex, message);
    }

    /// <summary>
    /// Method to log Error
    /// </summary>
    /// <param name="message"></param>
    /// <param name="values"></param>
    public void LogError(string message, params object[] values)
    {
        Serilog.Log.Error(message, values);
    }
    /// <summary>
    /// Method to log Error
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="values"></param>
    public void LogError(Exception ex, string message, params object[] values)
    {
        Serilog.Log.Error(ex, message, values);
    }

    /// <summary>
    /// Method to log Error
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="propertyValue"></param>
    public void LogError<T>(string message, T propertyValue)
    {
        Serilog.Log.Error(message, propertyValue);
    }
    /// <summary>
    /// Method to log Error
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="propertyValue"></param>
    public void LogError<T>(Exception ex, string message, T propertyValue)
    {
        Serilog.Log.Error(ex, message, propertyValue);
    }
    /// <summary>
    /// Method to log Error
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <param name="message"></param>
    /// <param name="propertyValue0"></param>
    /// <param name="propertyValue1"></param>
    public void LogError<T0, T1>(string message, T0 propertyValue0, T1 propertyValue1)
    {
        Serilog.Log.Error(message, propertyValue0, propertyValue1);
    }
    /// <summary>
    /// Method to log Error
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="propertyValue0"></param>
    /// <param name="propertyValue1"></param>
    public void LogError<T0, T1>(Exception ex, string message, T0 propertyValue0, T1 propertyValue1)
    {
        Serilog.Log.Error(ex, message, propertyValue0, propertyValue1);
    }
    /// <summary>
    /// Method to log Error
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="message"></param>
    /// <param name="propertyValue0"></param>
    /// <param name="propertyValue1"></param>
    /// <param name="propertyValue2"></param>
    public void LogError<T0, T1, T2>(string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Serilog.Log.Error(message, propertyValue0, propertyValue1, propertyValue2);
    }
    /// <summary>
    /// Method to log Error
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="propertyValue0"></param>
    /// <param name="propertyValue1"></param>
    /// <param name="propertyValue2"></param>
    public void LogError<T0, T1, T2>(Exception ex, string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Serilog.Log.Error(ex, message, propertyValue0, propertyValue1, propertyValue2);
    }
    /// <summary>
    /// Method to log debug information
    /// </summary>
    /// <param name="message"></param>
    public void Debug(string message)
    {
        Serilog.Log.Debug(message);
    }
    /// <summary>
    /// Method to log debug information
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    public void Debug(Exception ex, string message)
    {
        Serilog.Log.Debug(ex, message);
    }
    /// <summary>
    /// Method to log debug information
    /// </summary>
    /// <param name="message"></param>
    /// <param name="values"></param>
    public void Debug(string message, params object[] values)
    {
        Serilog.Log.Debug(message, values);
    }
    /// <summary>
    /// Method to log debug information
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="values"></param>
    public void Debug(Exception ex, string message, params object[] values)
    {
        Serilog.Log.Debug(ex, message, values);
    }
    /// <summary>
    /// Method to log debug information
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="propertyValue"></param>
    public void Debug<T>(string message, T propertyValue)
    {
        Serilog.Log.Debug(message, propertyValue);
    }
    /// <summary>
    /// Method to log debug information
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="propertyValue"></param>
    public void Debug<T>(Exception ex, string message, T propertyValue)
    {
        Serilog.Log.Debug(ex, message, propertyValue);
    }
    /// <summary>
    /// Method to log debug information
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <param name="message"></param>
    /// <param name="propertyValue0"></param>
    /// <param name="propertyValue1"></param>
    public void Debug<T0, T1>(string message, T0 propertyValue0, T1 propertyValue1)
    {
        Serilog.Log.Debug(message, propertyValue0, propertyValue1);
    }
    /// <summary>
    /// Method to log debug information
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="propertyValue0"></param>
    /// <param name="propertyValue1"></param>
    public void Debug<T0, T1>(Exception ex, string message, T0 propertyValue0, T1 propertyValue1)
    {
        Serilog.Log.Debug(ex, message, propertyValue0, propertyValue1);
    }
    /// <summary>
    /// Method to log debug information
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="message"></param>
    /// <param name="propertyValue0"></param>
    /// <param name="propertyValue1"></param>
    /// <param name="propertyValue2"></param>
    public void Debug<T0, T1, T2>(string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Serilog.Log.Debug(message, propertyValue0, propertyValue1, propertyValue2);
    }

    /// <summary>
    /// Method to log debug information
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="propertyValue0"></param>
    /// <param name="propertyValue1"></param>
    /// <param name="propertyValue2"></param>
    public void Debug<T0, T1, T2>(Exception ex, string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Serilog.Log.Debug(ex, message, propertyValue0, propertyValue1, propertyValue2);
    }

    public void CloseAndFlush()
    {
        Serilog.Log.CloseAndFlush();
    }

    protected virtual void Dispose(bool dispossing)
    {
        if (dispossing)
        {
            CloseAndFlush();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

