using ServiceStack;

[assembly: HostingStartup(typeof(TennisTraining.ConfigureCors))]

namespace TennisTraining
{
    public class ConfigureCors : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder
            .ConfigureAppHost(appHost =>
            {
                appHost.Plugins.Add(new CorsFeature(allowOriginWhitelist: new[]{
                   "http://localhost:5000",
                   "http://localhost:3000",
                   "https://localhost:5001",
                   "https://178.128.138.18/",
                   "http://178.128.138.18/",
                   "https://webapp.webhut.ml",
                   "https://" + Environment.GetEnvironmentVariable("DEPLOY_CDN")
                },
                allowCredentials: true));
                //appHost.Plugins.Add(new CorsFeature());
            }
        );
    }
}