using System;
using System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Keysounds;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Services.AddSingleton<ApplicationContext, AppApplicationContext>()
            .AddSingleton<IAppNotifyIcon, AppNotifyIcon>();
        using IHost host = builder.Build();
        Application.Run(host.Services.GetRequiredService<ApplicationContext>());
    }
}
