using System;
using System.Windows.Forms;
using Bai6_2.GUI;

namespace Bai6_2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmNhanSu());
        }
    }
}