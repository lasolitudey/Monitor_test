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
using System.Configuration;

namespace Monitor_test
{
    /// <summary>
    /// info.xaml 的交互逻辑
    /// </summary>
    public partial class info : Page
    {
        public info()
        {
            InitializeComponent();
            Thread T = new Thread(new ThreadStart(Connect));
            T.IsBackground = true;
            T.Start();

            void Connect()
            {
                while (true)
                {
                    String []Select = Sql.Sql_Select(Car_Now.Car_Number);
                    Dispatcher.BeginInvoke(new Action(delegate
                    {
                        Tem_bar.Value = (Convert.ToDouble(Select[0]) + 40) / 100;
                        Hum_bar.Value = (Convert.ToDouble(Select[1])) / 100;
                        Tem_Now.Content = Select[0];
                        Hum_Now.Content = Select[1];
                        Tem_Max.Content = Select[2] + "℃";
                        Hum_Max.Content = Select[3] + "%";
                        Tem_Min.Content = Select[4] + "℃";
                        Hum_Min.Content = Select[5] + "%";
                        Tem_Avg.Content = Select[6] + "℃";
                        Hum_Avg.Content = Select[7] + "%";

                    }));
                    Thread.CurrentThread.Join(1000);
                    if(T_Stop.run == false)
                    {
                        Thread.CurrentThread.Abort();
                    }
                }
            }
        }
    }

    public static class Sql
    {
        private static MySqlConnection mcon = new MySqlConnection();

        public static void Sql_Connect()
        {
            string connstr = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;                                 
            mcon = new MySqlConnection(connstr);
            mcon.Open();
        }

        public static void Sql_close()
        {
            mcon.Close();
        }

        public static String []Sql_Select(int Car_Num)
        {
            String[] Select = new String[8];
            switch (Car_Num)
            {
                case 1:
                    Select_Str(" router ");
                    return Select;

                case 2:
                    Select_Str(" enddevice_1 ");
                    return Select;
                    
                case 3:
                    Select_Str(" enddevice_2 ");
                    return Select;
                default:
                    MessageBox.Show("Error!");
                    return Select;
            void Select_Str(String car)
            {
                        string temp1 = "select temperature from" + car + "order by id desc limit 1";
                        string hum1 = "select humidity from" + car + "order by id desc limit 1";
                        string tempmax1 = "select max(temperature) from" + car + "order by id desc limit 1";
                        string hummax1 = "select max(humidity) from" + car + "order by id desc limit 1";
                        string tempmin1 = "select min(temperature) from" + car + "order by id desc limit 1";
                        string hummin1 = "select min(humidity) from " + car + " order by id desc limit 1";
                        string tempavg1 = "select avg(temperature) from" + car + "order by id desc limit 1";
                        string humavg1 = "select avg(humidity) from" + car + "order by id desc limit 1";
                        MySqlCommand ada1 = new MySqlCommand(temp1, mcon);
                        MySqlCommand ada2 = new MySqlCommand(hum1, mcon);
                        MySqlCommand ada3 = new MySqlCommand(tempmax1, mcon);
                        MySqlCommand ada4 = new MySqlCommand(hummax1, mcon);
                        MySqlCommand ada5 = new MySqlCommand(tempmin1, mcon);
                        MySqlCommand ada6 = new MySqlCommand(hummin1, mcon);
                        MySqlCommand ada7 = new MySqlCommand(tempavg1, mcon);
                        MySqlCommand ada8 = new MySqlCommand(humavg1, mcon);
                        MySqlDataReader dr1 = ada1.ExecuteReader();
                        if (dr1.Read())
                        {
                            Select[0] = dr1["temperature"].ToString();
                            dr1.Close();
                        }
                        MySqlDataReader dr2 = ada2.ExecuteReader();
                        if (dr2.Read())
                        {
                            Select[1] = dr2["humidity"].ToString();
                            dr2.Close();
                        }
                        MySqlDataReader dr3 = ada3.ExecuteReader();
                        if (dr3.Read())
                        {
                            Select[2] = dr3["max(temperature)"].ToString();
                            dr3.Close();
                        }
                        MySqlDataReader dr4 = ada4.ExecuteReader();
                        if (dr4.Read())
                        {
                            Select[3] = dr4["max(humidity)"].ToString();
                            dr4.Close();
                        }
                        MySqlDataReader dr5 = ada5.ExecuteReader();
                        if (dr5.Read())
                        {
                            Select[4] = dr5["min(temperature)"].ToString();
                            dr5.Close();
                        }
                        MySqlDataReader dr6 = ada6.ExecuteReader();
                        if (dr6.Read())
                        {
                            Select[5] = dr6["min(humidity)"].ToString();
                            dr6.Close();
                        }
                        MySqlDataReader dr7 = ada7.ExecuteReader();
                        if (dr7.Read())
                        {
                            Select[6] = String.Format("{0:F}", dr7["avg(temperature)"]);
                            dr7.Close();
                        }
                        MySqlDataReader dr8 = ada8.ExecuteReader();
                        if (dr8.Read())
                        {
                            Select[7] = String.Format("{0:F}", dr8["avg(humidity)"]);
                            dr8.Close();
                        }

                    }             
                
            }
        }

        public static class Sql_Control
        {
            public static Boolean Con_Auto;
            public static Boolean Con_Switch;
            public static void Control()
            {
                string _Auto = "select XX from XX order by XX limit 1";
                string _Switch = "select XX from XX order by XX limit 1";
                MySqlCommand ada1 = new MySqlCommand(_Auto, mcon);
                MySqlCommand ada2 = new MySqlCommand(_Switch, mcon);
                MySqlDataReader dr9 = ada1.ExecuteReader();
                if (dr9.Read())
                {
                    Con_Auto = Convert.ToBoolean(dr9["XX"].ToString());
                    dr9.Close();
                }
                MySqlDataReader dr10 = ada2.ExecuteReader();
                if (dr10.Read())
                {
                    Con_Switch = Convert.ToBoolean(dr10["XX"].ToString());
                    dr10.Close();
                }
            }
            public static void Control_Change(int n)
            {
                
                switch (n)
                {
                    case 1:
                        Auto_On();
                        break;
                    case 2:
                        Auto_Off();
                        break;
                    case 3:
                        Switch_On();
                        break;
                    case 4:
                        Switch_Off();
                        break;

                }
                void Auto_On()
                {
                    string Auto_On_S = "";
                    MySqlCommand ada = new MySqlCommand(Auto_On_S, mcon);
                    ada.ExecuteNonQuery();
                }
                void Auto_Off()
                {
                    string Auto_Off_S = "";
                    MySqlCommand ada = new MySqlCommand(Auto_Off_S, mcon);
                    ada.ExecuteNonQuery();
                }
                void Switch_On()
                {
                    string Switch_On_S = "";
                    MySqlCommand ada = new MySqlCommand(Switch_On_S, mcon);
                    ada.ExecuteNonQuery();
                }
                void Switch_Off()
                {
                    string Switch_Off_S = "";
                    MySqlCommand ada = new MySqlCommand(Switch_Off_S, mcon);
                    ada.ExecuteNonQuery();
                }
                

            }
        }

        public static MySqlDataAdapter Sql_DataGrid(int Car_Num)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter();
            switch (Car_Num)
            {
                case 1:
                    view(" router");
                    return sda;
                case 2:
                    view(" enddevice_1");
                    return sda;
                case 3:
                    view(" enddevice_2");
                    return sda;
                default:
                    return sda;
            }
            void view(string car)
            {
                string sql = "select id as 'id',date_format(time,'%y/%m/%d-%h:%i:%s')as'time',temperature as 'temperature',humidity as 'humidity' from" + car;
                sda = new MySqlDataAdapter(sql, mcon);
            }
        }
    }

   
}
