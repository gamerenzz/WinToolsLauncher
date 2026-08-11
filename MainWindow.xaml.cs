using System;
using System.Diagnostics;
using System.Windows;

namespace WinToolsLauncher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 封装启动进程的方法
        private void RunCmd(string fileName, string arguments = "")
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    UseShellExecute = true // 必须为 true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开失败: " + ex.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // 1. 控制面板
        private void BtnControlPanel_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("control.exe");
        }

        // 2. 设备和打印机（已修复报错）
        private void BtnPrinters_Click(object sender, RoutedEventArgs e)
        {
            // 使用 control.exe 的规范名称打开，兼容 Win10/Win11 且不会报错
            RunCmd("control.exe", "/name Microsoft.DevicesAndPrinters");
        }

        // 3. 网络连接 (ncpa.cpl)
        private void BtnNetwork_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("ncpa.cpl");
        }

        // 4. 设备管理器
        private void BtnDevMgmt_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("devmgmt.msc");
        }

        // 5. Win10 UWP 设置
        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("ms-settings:");
        }

        // 6. 任务管理器
        private void BtnTaskMgr_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("taskmgr.exe");
        }
    }
}
