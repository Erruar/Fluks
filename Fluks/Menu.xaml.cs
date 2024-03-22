using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;
namespace Fluks
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private Config config = new Config();
        public Menu()
        {
            InitializeComponent();
            ConfigLoad();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ConfigLoad();
            config.Menuwind = false;
            ConfigSave();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ConfigLoad();
            config.Menuwind = false;
            ConfigSave();
        }
        //Закрыть окно
        private void closeApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Свернуть окно
        private void minimizeApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
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
            var ellipse = sender as Ellipse;
            ellipse.Fill = Brushes.DarkGray;
            ellipse.Opacity = 0.5;
        }

        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            // ... Эллипсы закрытия и сворачивания окна
            var ellipse = sender as Ellipse;
            ellipse.Fill = Brushes.Transparent;
        }
        //-------------Движение окна-------------\\
        private void MovingWin(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                //MainWindow.Window.DragMove();
                this.DragMove();
            }
        }
        public void ConfigSave()
        {
            try
            {
                Directory.CreateDirectory(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Fluks"));
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Fluks\\config.json", JsonConvert.SerializeObject(config));
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Unable to save config.json\n\n" + ex.Message);
            }
        }

        public void ConfigLoad()
        {
            try
            {
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Fluks\\config.json"));
            }
            catch
            {
            }
        }
    }
}
