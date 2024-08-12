using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;

namespace Keysounds;

/// <summary>
/// The <see cref="ApplicationContext"/> used in this app. This is used to start the app without a <see cref="Form"/>.
/// </summary>
/// <param name="appNotifyIcon">The <see cref="IAppNotifyIcon"/> to inject.</param>
internal class AppApplicationContext(IAppNotifyIcon appNotifyIcon) : ApplicationContext
{
    [SuppressMessage("Performance", "CA1823:Avoid unused private fields", Justification = "This field is injected because its constructor has a side effect.")]
    [SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "This field is injected because its constructor has a side effect.")]
    private readonly IAppNotifyIcon appNotifyIcon = appNotifyIcon;
}
