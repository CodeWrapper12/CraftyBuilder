
using craftyBuilder.Domain.Logging;
namespace craftyBuider.Infrastructure.Ai;

public class Test(ILogger logger) : ITest
{
  private readonly ILogger logger1 = logger;

  public void printSomething()
  {
    logger1.LogInformation("Log information");
    logger1.LogError("LogError");
    logger1.LogInformation("Log information");
    logger1.LogError("LogError");
    logger1.LogInformation("Log information");

  }

}

