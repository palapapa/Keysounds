using System;
using System.Windows.Forms;

namespace Keysounds;

/// <summary>
/// Represents the <see cref="System.Windows.Forms.NotifyIcon"/> this app uses. Used for dependency injection purposes to wrap around a <see cref="System.Windows.Forms.NotifyIcon"/> since is doesn't implement an <see langword="interface"/>.
/// </summary>
internal interface IAppNotifyIcon : IDisposable
{
    public NotifyIcon NotifyIcon { get; }
}
