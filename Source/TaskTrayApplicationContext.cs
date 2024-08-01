using Keysounds.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Keysounds;

class TaskTrayApplicationContext : ApplicationContext
{
    private readonly NotifyIcon notifyIcon;

    public TaskTrayApplicationContext()
    {
        notifyIcon = new()
        {
            Icon = Resources.NotifyIcon,
            ContextMenuStrip = new()
            {
                Items = { { "Exit", Resources.Exit, Exit } }
            },
            Visible = true
        };
        Application.ApplicationExit += (_, _) => notifyIcon.Dispose();
    }

    private void Exit(object? sender, EventArgs e)
    {
        notifyIcon.Dispose();
        Application.Exit();
    }
}
