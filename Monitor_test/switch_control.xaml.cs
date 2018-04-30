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

namespace Monitor_test
{
    /// <summary>
    /// switch_control.xaml 的交互逻辑
    /// </summary>
    public partial class switch_control : Page
    {
        public switch_control()
        {
            InitializeComponent();
            Image image_on = new Image();
            image_on.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/switch_128px_1201392_easyicon.net.ico"));
            Image image_off = new Image();
            image_off.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/switch_128px_1201391_easyicon.net.ico"));
            Sql.Sql_Control.Control();
            if(Sql.Sql_Control.Con_Auto == true)
            {
                Switch_1.Content = image_on;
            }
            else
            {                
                Switch_1.Content = image_off;
                Switch_2.Visibility = Visibility.Visible;
                Label_Manual.Visibility = Visibility.Visible;
            }
            if(Sql.Sql_Control.Con_Switch == true)
            {
                Switch_2.Content = image_on;
            }
            else
            {
                Switch_2.Content = image_off;
            }

        }

        private void Switch_2_Click(object sender, RoutedEventArgs e)
        {
            if (Sql.Sql_Control.Con_Switch)
            {
                Sql.Sql_Control.Control_Change(3);
                Image image = new Image();
                image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/switch_128px_1201391_easyicon.net.ico"));
                Switch_1.Content = image;
                Sql.Sql_Control.Con_Switch = false;
            }
            else
            {
                Sql.Sql_Control.Control_Change(4);
                Image image = new Image();
                image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/switch_128px_1201392_easyicon.net.ico"));
                Switch_1.Content = image;
                Sql.Sql_Control.Con_Switch = true;
            }
        }

        private void Switch_1_Click(object sender, RoutedEventArgs e)
        {
            //根据数据库不同情况用if语句
            if (Sql.Sql_Control.Con_Auto)
            {
                Sql.Sql_Control.Control_Change(1);
                Label_Manual.Visibility = Visibility.Visible;
                Switch_2.Visibility = Visibility.Visible;
                Image image = new Image();
                image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/switch_128px_1201391_easyicon.net.ico"));
                Switch_1.Content = image;
                Sql.Sql_Control.Con_Auto = false;
            }
            else
            {
                Sql.Sql_Control.Control_Change(2);
                Label_Manual.Visibility = Visibility.Hidden;
                Switch_2.Visibility = Visibility.Hidden;
                Image image = new Image();
                image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/switch_128px_1201392_easyicon.net.ico"));
                Switch_1.Content = image;
                Sql.Sql_Control.Con_Auto = true;
            }
            
        }
    }
}
