using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fluks
{
    public partial class MainWindow
    {
        private readonly Apply _apply;
        private Config _config = new Config();

        public bool MenuOpened = false;
        public MainWindow()
        {
            InitializeComponent();
            ConfigLoad();
            _config.Menuwind = false;
            ConfigSave();
            _apply = new Apply();
        }
        private void GPU_Click(object sender, RoutedEventArgs e)
        {
            _apply.ApplyTweak("Scripts","cmd.exe"," /k GPU.bat"); 
        }

        private void Z1E_Click(object sender, RoutedEventArgs e)
        {
            _apply.ApplyTweak("Scripts","regedit.exe"," Z1E.reg");  
        }

        private void R777_Click(object sender, RoutedEventArgs e)
        {
            _apply.ApplyTweak("Scripts","regedit.exe"," R777.reg ");   
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            var menuWindow = new Menu();
            ConfigLoad();
            if (_config.Menuwind) return;
            _config.Menuwind = true;
            menuWindow.Show();
            ConfigSave();
        }
        //Закрыть окно
        private void CloseApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                _config.Menuwind = false;
                ConfigSave();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Свернуть окно
        private void MinimizeApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //-------------Закрытие, сворачивание окна-------------\\
        private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            // ... Эллипсы закрытия и сворачивания окна
            if (!(sender is Ellipse ellipse)) return;
            ellipse.Fill = Brushes.DarkGray;
            ellipse.Opacity = 0.5;
        }

        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            // ... Эллипсы закрытия и сворачивания окна
            if (sender is Ellipse ellipse) ellipse.Fill = Brushes.Transparent;
        }
        //-------------Движение окна-------------\\
        private void MovingWin(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                //MainWindow.Window.DragMove();
                DragMove();
            }
        }
        //-------------JSON-------------\\
        private void JsonRepair(char file)
        {
            if (file != 'c') return;
            try
            {
                _config = new Config();
            }
            catch
            {
                Close();
            }
            if (_config != null)
            {
                try
                {
                    Directory.CreateDirectory(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Fluks"));
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Fluks\\config.json", JsonConvert.SerializeObject(_config));
                }
                catch
                {
                    MessageBox.Show("Can't rewrite corrupted config!");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Config file can't be opened!");
                try
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Fluks\\config.json");
                    MessageBox.Show("Corrupted config deleted!");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Can't delete corrupted file!");
                    Close();
                }
            }
        }

        private void ConfigSave()
        {
            try
            {
                Directory.CreateDirectory(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Fluks"));
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
                JsonRepair('c');
            }
        }

        private void Universal_OnClick(object sender, RoutedEventArgs e)
        {
            _apply.ApplyTweak("Scripts","regedit.exe"," UNIVERSAL.reg ");   
        }
    }
}
