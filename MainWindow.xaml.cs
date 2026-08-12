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

        // 通用进程启动方法
        private void RunCmd(string fileName, string arguments = "")
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    UseShellExecute = true
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

        // 2. 经典版 设备和打印机
        private void BtnPrinters_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c start shell:::{A8A91A66-3A7D-4424-8D24-04E180695C7A}",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开失败: " + ex.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // 3. 网络连接 (ncpa.cpl)
        private void BtnNetwork_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("ncpa.cpl");
        }

        // 4. 设备管理器 (devmgmt.msc)
        private void BtnDevMgmt_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("devmgmt.msc");
        }

        // 5. 声音设置 (mmsys.cpl)
        private void BtnSound_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("mmsys.cpl");
        }

        // 6. 经典电源选项 (powercfg.cpl)
        private void BtnPower_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("powercfg.cpl");
        }

        // 7. 高级安全防火墙 (wf.msc)
        private void BtnFirewall_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("wf.msc");
        }

        // 8. 计算机管理 (compmgmt.msc)
        private void BtnCompMgmt_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("compmgmt.msc");
        }

        // 9. 组策略编辑器 (gpedit.msc)
        private void BtnGroupPolicy_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("gpedit.msc");
        }

        // 10. BitLocker 驱动器加密 - 新增
        private void BtnBitLocker_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("control.exe", "/name Microsoft.BitLockerDriveEncryption");
        }

        // 11. 程序和功能/卸载 (appwiz.cpl) - 新增凑整
        private void BtnAppWiz_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("appwiz.cpl");
        }

        // 12. 任务管理器
        private void BtnTaskMgr_Click(object sender, RoutedEventArgs e)
        {
            RunCmd("taskmgr.exe");
        }
    }
}
