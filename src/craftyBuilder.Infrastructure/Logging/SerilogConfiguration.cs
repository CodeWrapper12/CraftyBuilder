namespace craftyBuider.Infrastructure.Logging;
public class SerilogConfiguration
{
  public string? MinimumLevel { get; set; }
  public SinkConfiguration[]? WriteTo { get; set; }
}

public class SinkConfiguration
{
  public string? Name { get; set; }
  public ArgsConfiguration? Args { get; set; }
}

public class ArgsConfiguration
{
  public string? Path { get; set; }
  public string? RollingInterval { get; set; }
}
