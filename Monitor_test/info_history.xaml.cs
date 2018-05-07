﻿using System;
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
using System.Data;
using MySql.Data.MySqlClient;

namespace Monitor_test
{
    /// <summary>
    /// info_history.xaml 的交互逻辑
    /// </summary>
    public partial class info_history : Page
    {
        public info_history()
        {
            InitializeComponent();
           
            History_Chart.ItemsSource = Sql.Sql_DataGrid(Car_Now.Car_Number).Tables[0].DefaultView;
        }
    }
}
