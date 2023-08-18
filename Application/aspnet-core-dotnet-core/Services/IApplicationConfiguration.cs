namespace aspnet_core_dotnet_core.Services
{
    public interface IApplicationConfiguration
    {
        string Host { get; set; }
        string BackgroundColor { get; set; }
    }
}