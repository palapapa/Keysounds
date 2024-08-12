using Keysounds.Properties;
using System;
using System.Windows.Forms;

namespace Keysounds;

/// <summary>
/// Default implementation of <see cref="IAppNotifyIcon"/> that adds the <see cref="System.Windows.Forms.NotifyIcon"/> the user of this app is going to use to access features.
/// </summary>
internal class AppNotifyIcon : IAppNotifyIcon
{
    public NotifyIcon NotifyIcon { get; private set; }

    public AppNotifyIcon() =>
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
