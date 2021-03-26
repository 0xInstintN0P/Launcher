using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string path = @"S4Client.exe";

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("S4Client.exe", "-rc:eu -lac:eng -auth_server_ip:127.0.0.1");
            label1.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility;
            button1.Visibility = Visibility.Hidden;
            WindowCloseTimer();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("This file S4Client.exe not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            else
            {
                
            }
        }

        private void WindowCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(8d);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            Close();
        }
    }
}
