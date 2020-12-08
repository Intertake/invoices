using System;
using System.Collections.Generic;
using System.Data;
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
using System.IO;

namespace fakturki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string pathdir = @"C:\Users\Filip\Documents\invoices\fakturki\companies.xml";
        public MainWindow()
        {
            InitializeComponent();
            //Application.Current.MainWindow.Height = SystemParameters.PrimaryScreenHeight;
            //Application.Current.MainWindow.Width = SystemParameters.PrimaryScreenWidth;
            Application.Current.MainWindow.Height = 1080;
            Application.Current.MainWindow.Width = 1920;
            


        }

        private void add_company_Click(object sender, RoutedEventArgs e)
        {
            var addcom = new AddCompany();
            addcom.Show();
           
            
           
        }

      

        private void datagrid1_Initialized(object sender, EventArgs e)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";



            //string sampleXmlFile = path;
            //DataSet dataSet = new DataSet();
            //dataSet.ReadXml(sampleXmlFile);
            //DataView dataView = new DataView(dataSet.Tables[0]);
            //datagrid1.ItemsSource = dataView;
        }
    }
}

