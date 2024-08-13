using System.Diagnostics;
using System.Windows.Forms;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;
using System.Diagnostics.CodeAnalysis;
using static Windows.Win32.PInvoke;
using System.Runtime.InteropServices;

namespace Keysounds;

/// <summary>
/// The <see cref="ApplicationContext"/> used in this app. This is used to start the app without a <see cref="Form"/>.
/// </summary>
internal class AppApplicationContext : ApplicationContext
{
    [SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "This field doesn't need to be read to function.")]
    private readonly IAppNotifyIcon appNotifyIcon;

    private readonly UnhookWindowsHookExSafeHandle LowLevelKeyboardHook;

    public AppApplicationContext(IAppNotifyIcon appNotifyIcon)
    {
        this.appNotifyIcon = appNotifyIcon;
        using Process currentProcess = Process.GetCurrentProcess();
        // MainModule shouldn't be null because we are just getting the current module.
        using ProcessModule currentModule = currentProcess.MainModule!;
        // GetModuleHandle returns a FreeLibrarySafeHandle whose OwnsHandle is false, so its Dispose won't call FreeLibrary, which it shouldn't.
        using FreeLibrarySafeHandle currentModuleHandle = GetModuleHandle(currentModule.ModuleName);
        LowLevelKeyboardHook = SetWindowsHookEx(WINDOWS_HOOK_ID.WH_KEYBOARD_LL, LowLevelKeyboardProc, currentModuleHandle, 0);
    }

    private LRESULT LowLevelKeyboardProc(int nCode, WPARAM wParam, LPARAM lParam)
    {
        if (nCode >= 0)
        {
            KBDLLHOOKSTRUCT keyInfo = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);
            Debug.WriteLine(keyInfo.vkCode);
        }
        return CallNextHookEx(null, nCode, wParam, lParam);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (disposing)
        {
            LowLevelKeyboardHook.Dispose();
        }
    }
}
