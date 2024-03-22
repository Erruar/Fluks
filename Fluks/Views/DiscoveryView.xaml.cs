using System.Windows;
using System.Windows.Controls;

namespace Fluks.View
{
    /// <summary>
    /// Логика взаимодействия для DiscoveryView.xaml
    /// </summary>
    public partial class DiscoveryView : UserControl
    {
        private readonly Apply _apply = new Apply();
        public DiscoveryView()
        {
            InitializeComponent();
        }

        private void RevertCPU_OnClick(object sender, RoutedEventArgs e)
        {
            _apply.ApplyTweak("Scripts\\Revert","regedit.exe"," CPU.reg ");    
        }

        private void RevertGPU_OnClick(object sender, RoutedEventArgs e)
        {
            _apply.ApplyTweak("Scripts\\Revert","cmd.exe"," /k GPU.cmd ");
        }

        private void RevertNVMe_OnClick(object sender, RoutedEventArgs e)
        {
            _apply.ApplyTweak("Scripts\\Revert","cmd.exe"," /k Nvme.cmd ");
        }

        private void ClearDisplay_OnClick(object sender, RoutedEventArgs e)
        {
            //_apply.ApplyTweak("Scripts","regedit.exe"," Clear.reg ");    
        }
    }
}
