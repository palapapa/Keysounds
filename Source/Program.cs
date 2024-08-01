using System;
using System.Windows.Forms;

namespace Keysounds;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new TaskTrayApplicationContext());
    }
}
