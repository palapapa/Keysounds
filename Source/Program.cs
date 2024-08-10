using System;
using System.Windows.Forms;

namespace Keysounds;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        using TaskTrayApplicationContext context = new();
        Application.Run(context);
    }
}
