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

namespace fakturki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Application.Current.MainWindow.Height = SystemParameters.PrimaryScreenHeight;
            //Application.Current.MainWindow.Width = SystemParameters.PrimaryScreenWidth;
            Application.Current.MainWindow.Height = 1080;
            Application.Current.MainWindow.Width = 1920;


        }




    }
}

