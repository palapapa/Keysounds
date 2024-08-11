using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;

namespace Keysounds;

internal class TaskTrayApplicationContext(IAppNotifyIcon appNotifyIcon) : ApplicationContext
{
    [SuppressMessage("Performance", "CA1823:Avoid unused private fields", Justification = "This field is injected because its constructor has a side effect.")]
    [SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "This field is injected because its constructor has a side effect.")]
    private readonly IAppNotifyIcon appNotifyIcon = appNotifyIcon;
}
