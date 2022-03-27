using Funq;
using ServiceStack;
using TennisTraining.ServiceInterface;

[assembly: HostingStartup(typeof(TennisTraining.AppHost))]

namespace TennisTraining;

public class AppHost : AppHostBase, IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices((context, services) => {
            services.ConfigureNonBreakingSameSiteCookies(context.HostingEnvironment);
        });

    public AppHost() : base("TennisTraining", typeof(MyServices).Assembly) {}

    public override void Configure(Container container)
    {
        //Permit modern browsers (e.g. Firefox) to allow sending of any HTTP Method
        SetConfig(new HostConfig
        {
            //     GlobalResponseHeaders = {
            //   { "Access-Control-Allow-Origin", "*" },
            //   { "Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS" },
            //   { "Access-Control-Allow-Headers", "Content-Type" },
            // },
        });

        Plugins.Add(new SpaFeature {
            EnableSpaFallback = true
        });

        ConfigurePlugin<UiFeature>(feature => {
            feature.Info.BrandIcon.Uri = "/assets/img/logo.svg";
            feature.Info.BrandIcon.Cls = "inline-block w-8 h-8 mr-2";
        });
    }
}
