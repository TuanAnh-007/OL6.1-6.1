using Bai6_1;
using Bai6_1.GUI; 
using System;
using System.Windows.Forms;

namespace Bai6_1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmBanHang()); // Khởi chạy frmBanHang
        }
    }
}