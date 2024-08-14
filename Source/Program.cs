using System;
using System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Keysounds;

internal static class Program
{
    [STAThread]
    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "The topmost catch statement catches all unhandled exceptions to display a message box.")]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Services.AddSingleton<ApplicationContext, AppApplicationContext>()
            .AddSingleton<IAppNotifyIcon, AppNotifyIcon>();
        using IHost host = builder.Build();
        try
        {
            Application.Run(host.Services.GetRequiredService<ApplicationContext>());
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString(), "Keysounds: Unhandled Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
    }
}
