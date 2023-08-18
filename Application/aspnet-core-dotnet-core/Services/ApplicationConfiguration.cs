namespace aspnet_core_dotnet_core.Services
{
    public class ApplicationConfiguration: IApplicationConfiguration
    {
        public string Host { get; set; }
        public string BackgroundColor { get; set; }
    }
}