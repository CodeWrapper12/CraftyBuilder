using craftyBuilder.Domain.Interfaces.CheckOs;

namespace craftyBuilder.Application.CheckOs;

public class CheckOs : ICheckOs
{
    private string OsDetails { get; set; } = string.Empty;
    private void CheckOsType()
    {
        OperatingSystem os = Environment.OSVersion;
        OsDetails = $"Platform: {os.Platform},Version: {os.Version},Service Pack: {os.ServicePack}";
    }

    public string FindOs()
    {
        CheckOsType();
        return OsDetails;
    }
}
