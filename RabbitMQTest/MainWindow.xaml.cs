using EasyNetQ.Logging;
using EasyNetQ;
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

namespace RabbitMQTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var connectionString = tf_Connection.Text;
            using (var bus = RabbitHutch.CreateBus(connectionString))
            {
                tf_Result.Text = $"{DateTime.Now} Verbunden = {bus.IsConnected} \n{tf_Result.Text}";
                if (bus.IsConnected)
                {
                    try

                    {
                        bus.Publish<string>($"Hallo {DateTime.Now}");
                    }
                    catch (Exception ex)
                    {
                        tf_Result.Text = $"{DateTime.Now} Fehler  {ex.Message} \n{tf_Result.Text}";
                    }
                }

            }
        }
    }
}
