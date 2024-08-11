using System;
using System.Windows.Forms;

namespace Keysounds;

/// <summary>
/// Represents the <see cref="NotifyIcon"/> this app uses. Used for dependency injection purposes.
/// </summary>
internal interface IAppNotifyIcon : IDisposable
{
    public NotifyIcon NotifyIcon { get; }
}
