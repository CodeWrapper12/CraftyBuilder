
namespace craftyBuilder.Domain.Logging;

public interface ILogger
{
    void LogInformation(string message);
    void LogInformation(Exception ex, string message);
    void LogInformation(Exception ex, string message, params object[] values);
    void LogInformation<T>(string message, T propertyValue);
    void LogInformation<T>(Exception ex, string message, T propertyValue);
    void LogInformation<T0, T1>(string message, T0 propertyValue0, T1 propertyValue1);
    void LogInformation<T0, T1>(Exception ex, string message, T0 propertyValue0, T1 propertyValue1);
    void LogInformation<T0, T1, T2>(string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);
    void LogInformation<T0, T1, T2>(Exception ex, string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);

    void LogError(string message);
    void LogError(Exception ex, string message);
    void LogError(Exception ex, string message, params object[] values);
    public void LogError<T>(string message, T propertyValue);
    public void LogError<T>(Exception ex, string message, T propertyValue);
    public void LogError<T0, T1>(string message, T0 propertyValue0, T1 propertyValue1);
    public void LogError<T0, T1>(Exception ex, string message, T0 propertyValue0, T1 propertyValue1);
    public void LogError<T0, T1, T2>(string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);
    public void LogError<T0, T1, T2>(Exception ex, string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);

    public void Debug(string message);
    public void Debug(Exception ex, string message);

    public void Debug(string message, params object[] values);
    public void Debug(Exception ex, string message, params object[] values);
    public void Debug<T>(string message, T propertyValue);
    public void Debug<T>(Exception ex, string message, T propertyValue);
    public void Debug<T0, T1>(string message, T0 propertyValue0, T1 propertyValue1);

    public void Debug<T0, T1>(Exception ex, string message, T0 propertyValue0, T1 propertyValue1);
    public void Debug<T0, T1, T2>(string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);
    public void Debug<T0, T1, T2>(Exception ex, string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);
}

