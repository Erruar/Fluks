using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

// ReSharper disable once CheckNamespace
namespace Fluks.View
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView
    {
        private Config _config = new Config();
        private readonly Apply _apply = new Apply();
        public HomeView()
        {
            InitializeComponent(); 
            InitPwrt(); 
        }
        private void InitPwrt()
        {
            ConfigLoad();
            Gtrrt.Text = _config.gtrr ? "Enable GTRR" : "Disable GTRR";
            PowerT.Text = _config.pwrt ? "Enable Power Throttling" : "Disable Power Throttling";
            Downfall.Text = _config.downfall ? "Enable Downfall" : "Disable Downfall";
            Saver.Text = _config.saver ? "Enable Power Saver" : "Disable Power Saver";
            Widgets.Text = _config.widgets ? "Enable Widgets" : "Disable Widgets";
        }

        private void ConfigSave()
        {
            try
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Fluks"));
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Fluks\\config.json", JsonConvert.SerializeObject(_config));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save config.json\n\n" + ex.Message);
            }
        }

        private void ConfigLoad()
        {
            try
            {
                _config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Fluks\\config.json"));
            }
            catch
            {
                // ignored
            }
        } 
        private void GTRR_Click(object sender, RoutedEventArgs e)
        {
            ConfigLoad();
            if (Gtrrt.Text == "Enable GTRR") { _config.gtrr = false; Gtrrt.Text = "Disable GTRR"; _apply.ApplyTweak("Scripts\\GTRR","regedit.exe"," ONGTRR.reg "); } else { _config.gtrr = true; Gtrrt.Text = "Enable GTRR"; _apply.ApplyTweak("Scripts\\GTRR","regedit.exe"," OFFGTRR.reg "); }
            ConfigSave();
        }

        private void PWRT_Click(object sender, RoutedEventArgs e)
        {
            ConfigLoad();
            if (PowerT.Text == "Enable Power Throttling") { _config.pwrt = false; PowerT.Text = "Disable Power Throttling";  _apply.ApplyTweak("Scripts\\Throttle","regedit.exe"," ONPOWERTHROTTLE.reg "); } else { _config.pwrt = true; PowerT.Text = "Enable Power Throttling"; _apply.ApplyTweak("Scripts\\Throttle","regedit.exe"," OFFPOWERTHROTTLE.reg "); }
            ConfigSave();
        }

        private void Downfall_OnClick(object sender, RoutedEventArgs e)
        {
            ConfigLoad();
            if (Downfall.Text == "Enable Downfall") { _config.downfall = false; Downfall.Text = "Disable Downfall"; _apply.ApplyTweak("Scripts\\Downfall","cmd.exe"," /k ONDownfall.cmd "); } else { _config.downfall = true; Downfall.Text = "Enable Downfall"; _apply.ApplyTweak("Scripts\\Downfall","cmd.exe"," /k OFFDownfall.cmd "); }
            ConfigSave();
        }

        private void Saver_OnClick(object sender, RoutedEventArgs e)
        {
            ConfigLoad();
            if (Saver.Text == "Enable Power Saver") { _config.saver = false; Saver.Text = "Disable Power Saver"; _apply.ApplyTweak("Scripts\\Saver","regedit.exe"," ONSAVER.reg "); } else { _config.saver = true; Saver.Text = "Enable Power Saver"; _apply.ApplyTweak("Scripts\\Saver","regedit.exe"," OFFSAVER.reg "); }
            ConfigSave();
        }

        private void Widget_OnClick(object sender, RoutedEventArgs e)
        {
            ConfigLoad();
            if (Widgets.Text == "Enable Widgets") { _config.widgets = false; Widgets.Text = "Disable Widgets"; _apply.ApplyTweak("Scripts\\Widgets","regedit.exe"," ONWIDGET.reg "); } else { _config.widgets = true; Widgets.Text = "Enable Widgets"; _apply.ApplyTweak("Scripts\\Widgets","regedit.exe"," OFFWIDGET.reg "); }
            ConfigSave();
        }

        private void GameBar_OnClick(object sender, RoutedEventArgs e)
        {
             _apply.ApplyTweak("Scripts","regedit.exe"," FSOBAR.reg ");
        }

        private void Moorespeed_OnClick(object sender, RoutedEventArgs e)
        {
            _apply.ApplyTweak("Scripts","regedit.exe"," MoreSpeed.reg ");
        }

        private void NVMETweak_OnClick(object sender, RoutedEventArgs e)
        {
            _apply.ApplyTweak("Scripts","cmd.exe"," /k Nvme.cmd ");
        }

        private void Downfall_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Suggest.Text = "Enable or disable Intel Downfall.\nThis vulnerability is related to Intel's \nmemory optimization feature, which \nallowing malicious software to access \ndata stored in other programs.";
        }

        private void Saver_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Suggest.Text = "Enable or disable Power Saver mode in Windows.\nThis feature designed to conserve energy by \nreducing system performance.";
        }

        private void Widget_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Suggest.Text = "Enable or disable weather, news, and other widgets in Windows.";
        }

        private void GameBar_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Suggest.Text = "Enable back windows Game Bar. You can't roll \nback this tweak!";
        }

        private void GTRR_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Suggest.Text = "Enable or disable unexpected 64 FPS limit when \nusing the default timer resolution. Enable\nGTRR should fix that issue";
        }

        private void Throttle_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Suggest.Text = "Enable or disables Power Throttling in Windows, \na feature designed to save energy by reducing \nthe CPU usage of background processes. ";
        }

        private void MoreSpeed_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Suggest.Text = "Get more speed for your CPU via reducing\nL-cashes load in windows.";
        }

        private void NVMe_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Suggest.Text = "Let windows use your NVMe drive more\nrationally and get speed boost.";
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Suggest.Text = "";
        }
    }
}
