using System;
using System.Collections.Generic;
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
using System.Threading;
using MySql.Data.MySqlClient;
using System.Windows.Threading;

namespace Monitor_test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Sql.Sql_Connect();
                info page = new info();
                Frame frame_info = new Frame()
                {
                    Content = page
                };
                Main_Content.Content = frame_info;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            Last.Visibility = Visibility.Visible;
            Next.Visibility = Visibility.Visible;
            Last_1.Visibility = Visibility.Hidden;
            Next_1.Visibility = Visibility.Hidden;           
            List_1.Visibility = Visibility.Hidden;
        }

        private void Button_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void Top_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            T_Stop.run = false;
            switch_control page_switch = new switch_control();
            Frame frame_switch = new Frame()
            {
                Content = page_switch
            };
            Main_Content.Content = frame_switch;
            Next.Visibility = Visibility.Hidden;
            Next_1.Visibility = Visibility.Hidden;
            Last.Visibility = Visibility.Hidden;
            Last_1.Visibility = Visibility.Visible;
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            T_Stop.run = false;
            info_history page_history = new info_history();
            Frame frame_history = new Frame()
            {
                Content = page_history
            };
            Main_Content.Content = frame_history;
            Next.Visibility = Visibility.Hidden;
            Next_1.Visibility = Visibility.Visible;
            Last.Visibility = Visibility.Hidden;
            Last_1.Visibility = Visibility.Hidden;
        }

        private void Next_1_Click(object sender, RoutedEventArgs e)
        {
            T_Stop.run = true;
            Last.Visibility = Visibility.Visible;
            Next.Visibility = Visibility.Visible;
            Last_1.Visibility = Visibility.Hidden;
            Next_1.Visibility = Visibility.Hidden;
            info page = new info();
            Frame frame_info = new Frame()
            {
                Content = page
            };
            Main_Content.Content = frame_info;
        }

        private void Last_1_Click(object sender, RoutedEventArgs e)
        {
            T_Stop.run = true;
            Last.Visibility = Visibility.Visible;
            Next.Visibility = Visibility.Visible;
            Last_1.Visibility = Visibility.Hidden;
            Next_1.Visibility = Visibility.Hidden;
            info page = new info();
            Frame frame_info = new Frame()
            {
                Content = page
            };
            Main_Content.Content = frame_info;
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            T_Stop.run = false;
            Car page_car = new Car();
            Frame frame_car = new Frame()
            {
                Content = page_car
            };
            Main_Content.Content = frame_car;
            List.Visibility = Visibility.Hidden;
            List_1.Visibility = Visibility.Visible;
            Setup.Visibility = Visibility.Hidden;
        }

        private void Setup_Click(object sender, RoutedEventArgs e)
        {
            T_Stop.run = false;
            Page_setup page_setup = new Page_setup();
            Frame frame_setup = new Frame()
            {
                Content = page_setup
            };
            Main_Content.Content = frame_setup;
            List.Visibility = Visibility.Hidden;
            Setup.Visibility = Visibility.Hidden;
            List_1.Visibility = Visibility.Visible;
        }

        private void List_1_Click(object sender, RoutedEventArgs e)
        {
            T_Stop.run = true;
            info page = new info();
            Frame frame_info = new Frame()
            {
                Content = page
            };
            Main_Content.Content = frame_info;
            List_1.Visibility = Visibility.Hidden;
            List.Visibility = Visibility.Visible;
            Setup.Visibility = Visibility.Visible;
            Last.Visibility = Visibility.Visible;
            Next.Visibility = Visibility.Visible;
            Last_1.Visibility = Visibility.Hidden;
            Next_1.Visibility = Visibility.Hidden;
        }
    }

    public static class Car_Now
    {
        public static int Car_Number = 1 ;
    }
    public static class T_Stop
    {
        public static Boolean run = true;
    }


}
