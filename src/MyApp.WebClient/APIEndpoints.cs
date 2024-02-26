namespace MyApp.WebClient
{
    public class APIEndpoints
    {
        public readonly string ServerBaseAddress;

        public APIEndpoints(IConfiguration configuration)
        {
            ServerBaseAddress = configuration.GetValue<string>("ServerBaseAddress");
        }
    }
}
