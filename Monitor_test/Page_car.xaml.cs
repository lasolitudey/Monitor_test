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
    /// Car.xaml 的交互逻辑
    /// </summary>
    public partial class Car : Page
    {
        public Car()
        {
            InitializeComponent();
            switch (Car_Now.Car_Number)
            {
                case 1:
                    Car1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF36C77B"));
                    break;
                case 2:
                    Car2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF36C77B"));
                    break;
                case 3:
                    Car3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF36C77B"));
                    break;
            }
        }

        private void Car1_Click(object sender, RoutedEventArgs e)
        {
            Car_Now.Car_Number = 1;
            Car1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF36C77B"));
            Car2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFB5240"));
            Car3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFB5240"));
        }

        private void Car2_Click(object sender, RoutedEventArgs e)
        {
            Car_Now.Car_Number = 2;
            Car2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF36C77B"));
            Car1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFB5240"));
            Car3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFB5240"));
        }

        private void Car3_Click(object sender, RoutedEventArgs e)
        {
            Car_Now.Car_Number = 3;
            Car3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF36C77B"));
            Car1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFB5240"));
            Car2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFB5240"));
        }
    }

}
