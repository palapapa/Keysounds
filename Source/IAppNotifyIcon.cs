using System;
using System.Windows.Forms;

namespace Keysounds;

/// <summary>
/// Represents the <see cref="NotifyIcon"/> this app uses. Used for dependency injection purposes to wrap around a <see cref="NotifyIcon"/> since is doesn't implement an <see langword="interface"/>.
/// </summary>
internal interface IAppNotifyIcon : IDisposable
{
    public NotifyIcon NotifyIcon { get; }
}
