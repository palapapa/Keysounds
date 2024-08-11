using Keysounds.Properties;
using System;
using System.Windows.Forms;

namespace Keysounds;

internal class AppNotifyIconImpl : IAppNotifyIcon
{
    public NotifyIcon NotifyIcon { get; private set; }

    public AppNotifyIconImpl() =>
        NotifyIcon = new()
        {
            Icon = Resources.NotifyIcon,
            ContextMenuStrip = new()
            {
                Items = { { "Exit", Resources.Exit, Exit } }
            },
            Visible = true
        };

    private void Exit(object? sender, EventArgs e) => Application.Exit();

    public void Dispose() => NotifyIcon.Dispose();
}
