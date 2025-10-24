using System;
using System.Windows.Forms;
using Autotrophe;

namespace SysAutoCorrect
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new TrayApplicationContext());
        }
    }
}